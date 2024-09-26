using harita.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace harita.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
       : base(options)
        {
        }
        public DbSet<Point> points { get; set; }
        public DbSet<LineString> linestrings { get; set; }
        public DbSet<Polygon> polygons { get; set; }
    }
}
