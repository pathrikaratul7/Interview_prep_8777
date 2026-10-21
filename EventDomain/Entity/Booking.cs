using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventDomain.Entity
{
    public class Booking
    {
        [Key]
        public long Id { get; set; }
        [ForeignKey("Id")]
        public  long EventId { get; set; }
        public string UserId { get; set; } = null!;
        [Required(ErrorMessage ="This SeatBooked field is required")]
        [MaxLength(100)]
        public int SeatsBooked { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string Status { get; set; } = "Confirmed";
             //(Confirmed / Cancelled),
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // this is for relationship
        public Event Event { get; set; } = null!;
    }
}
