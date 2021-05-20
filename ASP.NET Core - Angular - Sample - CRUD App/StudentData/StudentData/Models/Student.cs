using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentData.Models
{
    public class Student
    {
        [Key]
        [DatabaseGenerated
         (DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength (50)]
        public string Name { get; set; }       

        [Required]
        //[MaxLength (3)]
        public int Round { get; set; }

        [Required]
        [MaxLength (10)]
        public string Batch { get; set; }

        [Required]
        [StringLength (20, MinimumLength = 2)]
        public string Course { get; set; }

        [StringLength(50, MinimumLength = 2)]
        public string Address { get; set; }
        
        public bool Status { get; set; }
    }
}
