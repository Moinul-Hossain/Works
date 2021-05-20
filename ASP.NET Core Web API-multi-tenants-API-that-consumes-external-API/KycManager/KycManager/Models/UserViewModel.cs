using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace KycManager.Models
{
    public class UserViewModel
    {
        public string TenantId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public IFormFile DocFrontFile { get; set; }
        public IFormFile DocBackFile { get; set; }
    }
}
