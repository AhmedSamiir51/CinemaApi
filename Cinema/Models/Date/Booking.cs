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

        [JsonIgnore]

        public virtual User User { get; set; }
        [JsonIgnore]

        public virtual Movies Movies { get; set; }
        [JsonIgnore]

        public virtual Times Times { get; set; }
        [JsonIgnore]

        public virtual Hall Halls { get; set; }
    }
}
