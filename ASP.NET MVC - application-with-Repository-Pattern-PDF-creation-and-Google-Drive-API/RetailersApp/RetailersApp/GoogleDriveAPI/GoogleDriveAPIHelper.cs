using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;

namespace RetailersApp.GoogleDriveAPI
{
    public class GoogleDriveAPIHelper
    {
        //add scope
        public static string[] Scopes = { Google.Apis.Drive.v3.DriveService.Scope.Drive };

        //create Drive API service.
        public static DriveService GetService()
        {
            //get Credentials from client_secret.json file 
            UserCredential credential;
            //Root Folder of project
            var CSPath = System.Web.Hosting.HostingEnvironment.MapPath("~/");
            using (var stream = new FileStream(Path.Combine(CSPath, "credentials.json"), FileMode.Open, FileAccess.Read))
            {
                String FolderPath = System.Web.Hosting.HostingEnvironment.MapPath("~/"); ;
                String FilePath = Path.Combine(FolderPath, "DriveServiceCredentials.json");
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(FilePath, true)).Result;
            }
            //create Drive API service.
            DriveService service = new Google.Apis.Drive.v3.DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "RetailersApp",
            });
            return service;
        }

        //file Upload to the Google Drive root folder.
        public static void UplaodFileOnDrive(System.IO.FileStream file)
        {
            if (file != null && file.Length > 0)
            {
                //create service
                DriveService service = GetService();
                string path = Path.Combine(HttpContext.Current.Server.MapPath("~/GDrive"),
                Path.GetFileName(file.Name));
                //file.SaveAs(path);
                var FileMetaData = new Google.Apis.Drive.v3.Data.File();
                FileMetaData.Name = Path.GetFileName(file.Name);
                FileMetaData.MimeType = MimeMapping.GetMimeMapping(path);
                FilesResource.CreateMediaUpload request;
                file.Close();
                using (var stream = new System.IO.FileStream(path, System.IO.FileMode.Open))
                {
                    request = service.Files.Create(FileMetaData, stream, FileMetaData.MimeType);
                    request.Fields = "id";
                    request.Upload();
                    stream.Close();
                }

            }
        }


        // File upload in existing folder
        public static void FileUploadInFolder(string folderId, System.IO.FileStream file)
        {
            if (file != null && file.Length > 0)
            {
                Google.Apis.Drive.v3.DriveService service = GetService();
                string path = Path.Combine(HttpContext.Current.Server.MapPath("~/GDrive"),
                Path.GetFileName(file.Name));
                
                var FileMetaData = new Google.Apis.Drive.v3.Data.File()
                {
                    Name = Path.GetFileName(file.Name),
                    MimeType = MimeMapping.GetMimeMapping(path),
                    Parents = new List<string>
                    {
                        folderId
                    }
                };
                file.Close();
                Google.Apis.Drive.v3.FilesResource.CreateMediaUpload request;
                using (var stream = new System.IO.FileStream(path, System.IO.FileMode.Open))
                {
                    request = service.Files.Create(FileMetaData, stream, FileMetaData.MimeType);
                    request.Fields = "id";
                    request.Upload();
                }
                var file1 = request.ResponseBody;
            }
        }


    }
}