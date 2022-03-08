using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Cinema.Models.Date
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string FristName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int PhoneNumber { get; set; }
        [ForeignKey("Roles")]
        public int RoleId { get; set; }
        [JsonIgnore]
        public virtual ICollection<Booking> Booking { get; set; }

        [JsonIgnore]
        public virtual Roles Roles { get; set; }

    }
}
