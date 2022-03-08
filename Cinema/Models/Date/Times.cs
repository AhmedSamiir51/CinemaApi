using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Models.Date
{
    public class Times
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }

    }
}
