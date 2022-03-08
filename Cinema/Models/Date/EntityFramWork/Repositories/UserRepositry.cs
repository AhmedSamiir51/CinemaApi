using Cinema.Models.Date;
using Cinema.Models.EntityFramWork.Interfaces;
using Cinema.Models.ViewModel;
using Microsoft.EntityFrameworkCore;
using RepositoryPatternWithUOW.EF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Models.EntityFramWork.Repositories
{
    public class UserRepositry : BaseRepository<User>, IUserRepositry
    {
        private readonly ApplicationDbContext _context;

        public UserRepositry(ApplicationDbContext context) : base(context)
        {
            _context = context;

        }


        public User Login(AppLoginModel user)
        {
            var data = _context.Users.FirstOrDefault(x => x.Email == user.Email && x.Password == user.Password);
            return data;
        }
    }
}
