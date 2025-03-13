using Hms.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hms.Persistence
{
    public class HmsDbContext : AuditableDbContext
    {
        public HmsDbContext(DbContextOptions<HmsDbContext> options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; } = null!;
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; } = null!;
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; } = null!;


    }
}
