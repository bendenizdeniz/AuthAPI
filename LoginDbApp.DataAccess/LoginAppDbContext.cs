using Microsoft.EntityFrameworkCore;
using LoginDbApp.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoginDbApp.DataAccess
{
    public class LoginAppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server = DESKTOP-EMSG0FT; Database = LoginDb; integrated security = true;");
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Read> Reads { get; set; }

    }
}
