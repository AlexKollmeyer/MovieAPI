using Microsoft.EntityFrameworkCore;
using MoviesAPI.Models;
using System.Diagnostics.Contracts;

namespace MoviesAPI.Data
{
    public class ApplicationDbContext : DbContext 
    {
        public DbSet<Movie> Movies { get; set; }
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
