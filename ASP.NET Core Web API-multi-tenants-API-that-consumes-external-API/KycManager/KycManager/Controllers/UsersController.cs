using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Text;
using System.Globalization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using KycManager.Models;
using KycManager.TenantRepository;

namespace KycManager.Controllers
{
    // Instructions:
    // =============
    // 1. Please modify the connection string and change the Data Source with correct server name in the appsettings.json
    // 2. Please run the following EF commands before testing the application on Postman or browser.
    // 3. PM> Add-Migration initial (N.B.: 'initial' is example only. You can use your own migration name)
    //    PM> Update-Database
    // N.B.: Local upload directory is Customers/Documents

    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private string DocFront, DocBack;
        
        private readonly KycDbContext _context;
        private readonly ITenantProvider _provider;
        
        private string baseApiUrl = "https://dittomusic.getid.ee/api/v1/application/";
        
        private static string apiKey = "0f5d9381cce1535d2d599e7c822bd4aad39088b8093cee6b5cedd074e0ae7673";

        public UsersController(KycDbContext context, ITenantProvider provider)
        {
            _context = context;
            _provider = provider;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // Task 2: Have the API consume and easily find the KYC status of a user (Commit: 3)
        // N.B.: Immidiately called just after the Task 1 (i.e.: RegisterUser() )
        // GET: api/Users/kycusers/609b8d3dcaf2ce73167f59f1
        [HttpGet("KycUsers/{GetId}")]
        public IActionResult GetKycUser(string GetId)
        {
            User user = _context.Users.Where(k => k.GetId == GetId).FirstOrDefault();

            if (user == null)
            {
                return NotFound();
            }

            var status = (Status)user.Status;
            var KycUser = new { GetId = user.GetId, KycSatus = status.ToString() };

            return Ok(KycUser);
        }


        // Task 1: Register and complete KYC with GetId registration without front and back side documents (Commit: 2)
        // POST: api/Users/Register
        [HttpPost("Register")]
        public async Task<ActionResult<User>> RegisterUser([FromForm] UserViewModel uservm)
        {
            // Verifying the user already present on a tenant with incomplete KYC (Task 5)

            bool anyIncompleteKyc = GetIncompleteKyc(uservm.Email);

            if (anyIncompleteKyc)
            {
                User incompleteKyc = _context.Users.Where(k => k.Email == uservm.Email && (k.Status == Status.Failed || k.Status == Status.Declined)).FirstOrDefault();
                
                var iTenant = from u in _context.Users where u.Id == incompleteKyc.Id select u.Tenant;
                
                var iTenantId = iTenant.FirstOrDefault().Id;
                
                return BadRequest("Error: Already an incomplete profile with the Tenant ID: " + iTenantId);
            }


            // Uploading files to the local directory, Customers/Documents ...

            this.DocFront = this.DocBack = null;

            var fdoc = uservm.DocFrontFile;

            if (fdoc != null && fdoc.Length > 0)
            {
                if (!IsUploaded(fdoc, out this.DocFront))
                    return BadRequest("Please upload valid front side document.");
            }

            var bdoc = uservm.DocBackFile;

            if (bdoc != null && bdoc.Length > 0)
            {
                if (!IsUploaded(bdoc, out this.DocBack))
                    return BadRequest("Please upload valid back side document.");
            }

            // Registering user on GetId

            string GetId = CreateGetId(uservm);

            // Getting KYC status of the user...

            string status = GetKycStatus(GetId);    // This can be a valid status value or an error message. So, it's verified below:

            
            // Get KYC user status in title case for matching the values of Status (Enum)
            
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
            status = textInfo.ToTitleCase(status);

            if (!Enum.IsDefined(typeof(Status), status))
            {
                var statusObj = (JObject)JsonConvert.DeserializeObject(status);

                if (statusObj["error"] != null)
                    return Ok(status);
            }

            // Saving user to the local database...

            User user = new User();
            user.GetId = GetId;
            user.Tenant = _provider.GetTenant(uservm.TenantId);
            user.FirstName = uservm.FirstName;
            user.LastName = uservm.LastName;
            user.DateOfBirth = uservm.DateOfBirth;
            user.Email = uservm.Email;
            user.DocFront = this.DocFront;
            user.DocBack = this.DocBack;

            user.Status = (Status)Enum.Parse(typeof(Status), status);

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
             
            return CreatedAtAction(nameof(GetKycUser), new { GetId = user.GetId }, new { GetId = user.GetId, KycSatus = status.ToString() });
        }


        private string CreateGetId(UserViewModel uservm)
        {
            var getIdObj = new
            {

                application = new
                {

                    fields = new[] {
                                    new { category = "First name", content = uservm.FirstName, contentType = "string" },
                                    new { category = "Last name", content = uservm.LastName, contentType = "string" },
                                    new { category = "Date of birth", content = uservm.DateOfBirth.ToString("yyyy-MM-dd"), contentType = "date" },
                                    new { category = "Email", content = uservm.Email, contentType = "string" }
                                }
                }
            };

            var getIdJson = JsonConvert.SerializeObject(getIdObj);

            string api = baseApiUrl;

            string response = CreateGetIdByPost(getIdJson.Replace("\\", ""), api);

            JsonSerializerSettings settings = new JsonSerializerSettings();

            settings.MissingMemberHandling = MissingMemberHandling.Error;

            var responseData = (JObject)JsonConvert.DeserializeObject(response);

            int responseCode = responseData["responseCode"].Value<int>();

            string GetId = responseData["id"].Value<string>();

            return GetId;
        }

        // Task 3: Check if a user has completed KYC already by using our applications ‘int’ or GUID’
        // user primary key (Commit: 4)
        // GET: api/Users/status/609b8d3dcaf2ce73167f59f1
        [HttpGet("status/{GetId}")]
        public IActionResult GetKycStatusByGetId(string GetId)
        {
            bool isComplete = GetKycStatus(GetId) == "approved" ? true : (GetKycStatus(GetId) == "needs-review" ? true : false);
            var status = new { complete = isComplete, status = GetKycStatus(GetId) };

            return Ok(status);
        }

        private string GetKycStatus(string GetId)
        {
            string api = baseApiUrl + GetId;

            WebRequest request = WebRequest.Create(api);

            request.Credentials = CredentialCache.DefaultCredentials;            

            request.ContentType = "application/json";

            request.Headers["X-API-Key"] = apiKey;

            WebResponse response = request.GetResponse();

            string responseFromServer = "";

            using (Stream dataStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(dataStream);
                responseFromServer = reader.ReadToEnd();
            }

            response.Close();

            JsonSerializerSettings settings = new JsonSerializerSettings();

            settings.MissingMemberHandling = MissingMemberHandling.Error;

            var responseData = (JObject)JsonConvert.DeserializeObject(responseFromServer);

            string status;

            try
            {
                status = responseData["servicesResults"]["docCheck"]["status"].Value<string>();
            }
            catch(Exception error)
            {
                status = "{ \"error\" : " + error.Message + ", \"response\" : " + responseFromServer + " }";
            }

            return status;
        }

        private static string CreateGetIdByPost (string data, string URL)
        {
            data = data.Replace("\\", "");
            
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
            
            request.Method = "POST";
            
            request.Credentials = CredentialCache.DefaultCredentials;
            
            ((HttpWebRequest)request).UserAgent =
                              "Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 7.1; Trident/5.0)";
            
            request.Accept = "application/json";

            request.ContentType = "application/json";

            request.Headers["X-API-Key"] = apiKey;

            request.UseDefaultCredentials = true;
            
            request.Proxy.Credentials = System.Net.CredentialCache.DefaultCredentials;
            
            byte[] byteArray = Encoding.UTF8.GetBytes(data);
                        
            request.ContentLength = byteArray.Length;
            
            Stream dataStream = request.GetRequestStream();
            
            dataStream.Write(byteArray, 0, byteArray.Length);
            
            dataStream.Close();

            string responseFromServer = "";

            try
            {
                WebResponse response = request.GetResponse();
                
                dataStream = response.GetResponseStream();
                
                StreamReader reader = new StreamReader(dataStream);
                
                responseFromServer = reader.ReadToEnd();

                reader.Close();
                
                dataStream.Close();
                
                response.Close();
            }
            catch (Exception x)
            {
                responseFromServer = "{\"message \":" + "\"" + x.Message + "\"" + ", \"PostData\": " + data + ", \"URL\":" + "\""+ URL + "\"" + ", \"Headers\":" + JsonConvert.SerializeObject(request.Headers) + ", \"Content-Type\":" + "\"" + request.Headers["Content-Type"] + "\"" + "}";
            }

            return responseFromServer;
        }

        // Task 1: Register and complete KYC without GetId and demonstrated on Google Meet discussion (Commit: 1)
        // POST: api/Users
        [HttpPost]
        public async Task<ActionResult<User>> PostUser ([FromForm] UserViewModel uservm)         //  (User user)
        {

            bool anyIncompleteKyc = GetIncompleteKyc(uservm.Email);

            if (anyIncompleteKyc)
            {
                User incompleteKyc = _context.Users.Where(k => k.Email == uservm.Email && (k.Status == Status.Failed || k.Status == Status.Declined)).FirstOrDefault();
                
                var iTenant = from u in _context.Users where u.Id == incompleteKyc.Id select u.Tenant;
                
                var iTenantId = iTenant.FirstOrDefault().Id;
                
                return BadRequest("Error: Already an incomplete profile with the Tenant ID: " + iTenantId);
            }

            this.DocFront = this.DocBack = null;

            var fdoc = uservm.DocFrontFile;

            if (fdoc != null && fdoc.Length > 0)
            {
                if(!IsUploaded(fdoc, out this.DocFront))
                    return BadRequest("Please upload valid front side document.");
            }

            var bdoc = uservm.DocBackFile;

            if (bdoc != null && bdoc.Length > 0)
            {
                if (!IsUploaded(bdoc, out this.DocBack))
                    return BadRequest("Please upload valid back side document.");
            }

            User user = new User();
            user.Tenant = _provider.GetTenant(uservm.TenantId);
            user.FirstName = uservm.FirstName;
            user.LastName = uservm.LastName;
            user.DateOfBirth = uservm.DateOfBirth;
            user.Email = uservm.Email;
            user.DocFront = this.DocFront;
            user.DocBack = this.DocBack;

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
        }

        private bool GetIncompleteKyc (string Email)
        {
            return _context.Users.Any(e => e.Email == Email && (e.Status == Status.Failed || e.Status == Status.Declined));
        }

        private bool IsValidExtension (string fileExt)
        {
            string[] supported_exts = { ".jpg", ".jpeg", ".png", ".pdf" };
            bool IsValid = supported_exts.Contains(fileExt);
            
            return IsValid;
        }

        private bool IsUploaded (IFormFile doc, out string docName)
        {
            var filePath = Path.Combine("Customers/Documents", doc.FileName);
            string fileExt = Path.GetExtension(filePath);

            Random rnd = new Random();
            string fileNamePrefix = rnd.Next(1, 1000).ToString();
            string fileName = fileNamePrefix + fileExt;

            filePath = Path.Combine("Customers/Documents", fileName);

            docName = (Request.IsHttps ? "https://" : "http://") + Request.Host.ToUriComponent() + "/documents/" + fileName;

            if (!IsValidExtension(fileExt))
                return false;

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                doc.CopyTo(fileStream);
            }

            return true;
        }
    }
}
