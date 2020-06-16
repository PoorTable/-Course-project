using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace kp2.Models
{
    public class TVContext : DbContext
    {
        public DbSet<TV> TVs { get; set; }
        public TVContext(DbContextOptions<TVContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
