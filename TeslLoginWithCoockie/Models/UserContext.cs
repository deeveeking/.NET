using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TeslLoginWithCoockie.Models
{
    public class UserContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Fuel> Fuels { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<Zakaz> Zakaz { get; set; }
        public DbSet<Suppliers> Suppliers { get; set; }


        public UserContext(DbContextOptions<UserContext> options):base(options)
        {
            Database.EnsureCreated();
        }
        public UserContext()
        {
            Database.EnsureCreated();
        }


    }
}
