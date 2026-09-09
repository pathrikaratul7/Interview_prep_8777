using System.ComponentModel.DataAnnotations;

namespace Tasks_usingEF.Models
{
    public class Division
    {
        [Key]
        public long DIVID { get; set; } = 0;

        [Required(ErrorMessage = "This field is required, please enter division")]
        [StringLength(100)]
        public string DivName { get; set; } = null!;

        [Required(ErrorMessage = "This filed is required, please provide input true or false")]
        public bool IsActive { get; set; } = true;
    }
}
