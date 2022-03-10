using Cinema.Models.Date.EntityFramWork.Interfaces;
using RepositoryPatternWithUOW.EF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Models.Date.EntityFramWork.Repositories
{
    public class BookingRepo : BaseRepository<Booking>, IBookingRepo
    {
        private readonly ApplicationDbContext _context;

        public BookingRepo(ApplicationDbContext context) : base(context)
        {
            _context = context;

        }

        public void UpdateBooking(Booking model)
        {
            var data = _context.Booking.Where(e => e.Id == model.Id).FirstOrDefault();
            data.MovieId = model.MovieId;
            data.UserId = model.UserId;
            data.HallsId = model.HallsId;
            data.TimerId = model.TimerId;
            data.DayBooking = model.DayBooking;
            _context.SaveChanges();
        }
    }
}
