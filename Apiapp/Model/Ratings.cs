using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Apiapp.Models
{
    public class Ratings
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int sno{get; set;}
        [Required]
        public string EmployeeId{get; set;}
        [Required]
        public string Rating{get; set;}
        [Required]
        public string Feedback{get; set;}
    }
}
