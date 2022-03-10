using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Cinema.Models.Date
{
    public class Booking
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        [ForeignKey("Movies")]
        public int MovieId { get; set; }

        [ForeignKey("Times")]
        public int TimerId { get; set; }

        [ForeignKey("Halls")]
        public int HallsId { get; set; }
        public DateTime DayBooking { get; set; }

 

        public virtual User User { get; set; }
     

        public virtual Movies Movies { get; set; }
      

        public virtual Times Times { get; set; }
 

        public virtual Hall Halls { get; set; }
    }
}
