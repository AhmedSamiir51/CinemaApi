using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Models.Date
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Booking> Booking { get; set; }
        public DbSet<Movies> Movies { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Hall> Halls { get; set; }
        public DbSet<Times> Times { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
 
        }
    }
}
