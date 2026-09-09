using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tasks_usingEF.Models
{
    public class Employee
    {
        [Key]
        public long EID { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [StringLength(250)]
        public string Ename { get; set; } = null!;

        public string EMobile { get; set; } = null!;

        [ForeignKey("division")]
        public long DIVID { get; set; }

        public Division division { get; set; } = null!;
    }
}
