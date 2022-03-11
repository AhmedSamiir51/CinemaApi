using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Cinema.Models.Date
{
    public class Hall
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Limit { get; set; }
        [JsonIgnore]

        public virtual ICollection<Movies> Movies { get; set; }

    }
}
