﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Models.ViewModel
{
    public class AppLoginModel
    {
        [Required]
        public string Email { get; set; }
        [Required]

        public string Password { get; set; }
    }
}
