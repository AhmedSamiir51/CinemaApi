using Cinema.Models.Date;
using Cinema.Models.EntityFramWork.Interfaces;
using RepositoryPatternWithUOW.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternWithUOW.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepositry User { get; }
        IBaseRepository<Movies> Movies { get; }

        IBaseRepository<Booking> Booking { get; }
        IBaseRepository<Hall> Halls { get; }
        IBaseRepository<Times> Times { get; }



        int Complete();
    }
}