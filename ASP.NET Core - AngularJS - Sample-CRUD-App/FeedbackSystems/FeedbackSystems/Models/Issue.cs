using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FeedbackSystems.Models
{
    public class Issue
    {
        [Key]
        [DatabaseGenerated
         (DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [MaxLength(250)]
        public string Text { get; set; }

        public bool Done { get; set; }
    }
}