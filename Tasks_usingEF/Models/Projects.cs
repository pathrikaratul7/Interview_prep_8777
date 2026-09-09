using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tasks_usingEF.Models
{
    public class Projects
    {
        [Key]
        public long PID { get; set; }

        public string ProjectName { get; set; } = null!;

        [Column(TypeName ="decimal(18,2)")]
        public decimal Projectbudjet { get; set; } = decimal.Zero;
        public int ProjectTeamSize { get; set; } = int.MinValue;

    }
}
