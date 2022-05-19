using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheMovieDbBackend.Core.Entity;

namespace TheMovieDbBackend
{
    public partial class TheMovieDbContext:DbContext
    {
       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(@"Server=MSI\SQLEXPRESS;Database=TheMovieDb;Trusted_Connection=true");

        }

        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<MovieDb> MovieDb { get; set; } = null!;


    }
}
