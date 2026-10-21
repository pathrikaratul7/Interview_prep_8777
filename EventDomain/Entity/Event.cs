using System.ComponentModel.DataAnnotations;

namespace EventDomain.Entity

{
    public class Event
    {
        [Key]
        public long Id { get; set; }
        [Required(ErrorMessage = "Event name field is required")]
        [MaxLength(100)]
        public string Name { get; set; } = null!;
        [Required(ErrorMessage ="Total Seats field is required")]
        [MaxLength(100)]
        public int TotalSeats { get; set; }
        public DateTime StartsAt { get; set; } = DateTime.Now;

    }
}
