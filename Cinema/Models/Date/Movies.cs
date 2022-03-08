
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Cinema.Models.Date
{
    public class Movies
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string PhotoData { get; set; }
        public string TraileUrl { get; set; }

        [NotMapped]
        public Microsoft.AspNetCore.Http.IFormFile ProfilePicture { get; set; }

        [JsonIgnore]
        public virtual ICollection<Booking> Booking { get; set; }

    }
}
