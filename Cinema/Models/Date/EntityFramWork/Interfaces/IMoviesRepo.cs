using RepositoryPatternWithUOW.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Models.Date.EntityFramWork.Interfaces
{
     public  interface IMoviesRepo:IBaseRepository<Movies>
    {
        List<Movies> GetListOfMovies();
        List<Hall> GetListOfHall();
        List<Hall> GetListOfHall(int id );
    }
}
