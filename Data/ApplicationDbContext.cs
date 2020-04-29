using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SchoolsPortal.Models;

namespace SchoolsPortal.Data
{
    public class ApplicationDbContext: IdentityDbContext<ApplicationUser,ApplicationRole,string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Slider> Sliders { get; set; }
        public DbSet<AboutUs> AboutUses { get; set; }
        public DbSet<ContactUs> ContactUses { get; set; }
        public DbSet<Gallery> Galleries { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<Services> Serviceses { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Slider>().Property(x => x.Id).HasDefaultValueSql("NEWID()");
            builder.Entity<AboutUs>().Property(x => x.Id).HasDefaultValueSql("NEWID()");
            builder.Entity<ContactUs>().Property(x => x.Id).HasDefaultValueSql("NEWID()");
            builder.Entity<Gallery>().Property(x => x.Id).HasDefaultValueSql("NEWID()");
            builder.Entity<Setting>().Property(x => x.Id).HasDefaultValueSql("NEWID()");
            builder.Entity<Services>().Property(x => x.Id).HasDefaultValueSql("NEWID()");   
        }
    }
}
