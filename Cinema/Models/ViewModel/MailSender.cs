using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Models.ViewModel
{
    public class MailSender
    {
        public string ToMailAddress { get; set; }
        public string Name { get; set; }
        public string Message { get; set; }
    }
}
