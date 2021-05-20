using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KycManager.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } 
        public string GetId { get; set; }
        public Tenant Tenant { get; set; }
        public string FirstName { get; set; }       
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }        
        public string DocFront { get; set; }
        public string DocBack { get; set; }
        public Status Status { get; set; }
    }

    public enum Status
    {
        Pending,
        Complete,
        Failed,
        Declined,
        NeedsReview
    }
}
