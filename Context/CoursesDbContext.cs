using Apicursos.Models;
using GestaoCursos.Models;
using Microsoft.EntityFrameworkCore;

namespace GestaoCursos.Context
{
    public class CoursesDbContext : DbContext
    {
        public CoursesDbContext(DbContextOptions<CoursesDbContext> options) : base(options)
        {

        }

        public DbSet<Courses> Courses { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
