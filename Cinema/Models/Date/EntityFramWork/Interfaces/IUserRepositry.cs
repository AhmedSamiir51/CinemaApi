using Cinema.Models.Date;
using Cinema.Models.ViewModel;
using RepositoryPatternWithUOW.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Models.EntityFramWork.Interfaces
{
    public interface IUserRepositry:IBaseRepository<User>
    {
        User Login(AppLoginModel user);
    }
}
