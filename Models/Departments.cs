using System.ComponentModel.DataAnnotations;

namespace EMS.Models
{
    public class Departments
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
                
        [ScaffoldColumn(false)]
        public DateTime CreatedDate { get; set;}
        
        [ScaffoldColumn(false)]
        public DateTime UpdatedDate { get; set;}
    }
}
