using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Apiapp.Models
{
    public class Ratings
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int sno{get; set;}
        public string EmployeeID{get; set;}
        public string ratings{get; set;}
        public string feedback{get; set;}z
    }
}
