
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

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
        public bool IsVisibale { get; set; }

        [ForeignKey("Halls")]
        public int IdHalls { get; set; }

        [NotMapped]
        public Microsoft.AspNetCore.Http.IFormFile ProfilePicture { get; set; }

        [JsonIgnore]
        public virtual ICollection<Booking> Booking { get; set; }

 
        public virtual Hall Halls  { get; set; }

    }
}
