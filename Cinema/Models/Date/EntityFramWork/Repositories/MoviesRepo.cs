using Cinema.Models.Date.EntityFramWork.Interfaces;
using Microsoft.EntityFrameworkCore;
using RepositoryPatternWithUOW.EF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Models.Date.EntityFramWork.Repositories
{
    public class MoviesRepo : BaseRepository<Movies>, IMoviesRepo
    {
        
        private readonly ApplicationDbContext _context;

        public MoviesRepo(ApplicationDbContext context) : base(context)
        {
            _context = context;

        }
        public List<Movies> GetListOfMovies()
        {
            var data = _context.Movies.Where(e=>e.IsVisibale==true).Include(s => s.Halls).ToList();
            return data;
        }
        public List<Movies> AllGetListOfMovies()
        {
            var data = _context.Movies.Include(s => s.Halls).ToList();
            return data;
        }

        public List<Hall> GetListOfHall()
        {
 

          var books = _context.Halls.FromSqlRaw(" select  h.* from movies m  " +
                                                 "right join Halls h on h.Id = m.IdHalls " +
                                                 "WHERE m.id IS NULL").ToList();
             

            return books;
        }

        public List<Hall> GetListOfHall(int id )
        {
            var books = _context.Halls.FromSqlRaw(" select  h.* from movies m  " +
                                                   "right join Halls h on h.Id = m.IdHalls " +
                                                   "WHERE m.id IS NULL or h.Id = {0}",id).ToList();
            return books;
        }



        public Hall GetHallIdFromMovies(int id)
        {
            var books = _context.Movies.Where(e => e.Id == id).Select(e => e.Halls).FirstOrDefault();
            return books;
        }
    }
}
