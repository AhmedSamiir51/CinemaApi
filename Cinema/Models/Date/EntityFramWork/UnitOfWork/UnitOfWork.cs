using Cinema.Models.Date;
using Cinema.Models.Date.EntityFramWork.Interfaces;
using Cinema.Models.Date.EntityFramWork.Repositories;
using Cinema.Models.EntityFramWork.Interfaces;
using Cinema.Models.EntityFramWork.Repositories;
using RepositoryPatternWithUOW.Core;
using RepositoryPatternWithUOW.Core.Interfaces;
using RepositoryPatternWithUOW.EF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternWithUOW.EF
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IUserRepositry User { get; private set; }
        public IBaseRepository<Movies> Movies { get; private set; }
        public IBookingRepo Booking { get; private set; }
        public IBaseRepository<Hall> Halls { get; private set; }
        public IBaseRepository<Times> Times { get; private set; }


        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;

            User = new UserRepositry(_context);
            Movies = new BaseRepository<Movies>(_context);
            Booking = new BookingRepo(_context);
            Times = new BaseRepository<Times>(_context);
            Halls = new BaseRepository<Hall>(_context);

        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}