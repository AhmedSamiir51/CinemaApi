using RepositoryPatternWithUOW.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Models.Date.EntityFramWork.Interfaces
{
    public  interface IBookingRepo : IBaseRepository<Booking>
    {
        void UpdateBooking(Booking model);
    }
}
