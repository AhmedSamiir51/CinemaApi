using Cinema.Models.Date;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Models.ViewModel
{
    public class MoviesDTO
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string PhotoData { get; set; }
        public string TraileUrl { get; set; }
        public bool IsVisibale { get; set; }

        public int IdHalls { get; set; }
        [NotMapped]
        public Microsoft.AspNetCore.Http.IFormFile ProfilePicture { get; set; }
        public virtual Hall Halls { get; set; }

    }
}
