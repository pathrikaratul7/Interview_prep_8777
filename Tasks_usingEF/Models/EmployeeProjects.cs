using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tasks_usingEF.Models
{
    public class EmployeeProjects
    {
        [Key]
        public long EPID { get; set; }

        [ForeignKey("projects")]
        public long PID { get; set; }
        public Projects projects { get; set; } = null!;

        [ForeignKey("employees")]
        public long EID { get; set; }
        public Employee employees { get; set; } = null!;
    }
}
