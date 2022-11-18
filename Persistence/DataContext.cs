using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class DataContext : IdentityDbContext<User>
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Coef> Coefs { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Company>().HasOne(e => e.User)
                        .WithMany(s => s.UserCompanies)
                        .HasForeignKey(e => e.UserId)
                        .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Coef>().HasOne(e => e.Company)
                        .WithMany(s => s.CompanyCoefs)
                        .HasForeignKey(e => e.CompanyId)
                        .OnDelete(DeleteBehavior.Cascade);
        }
    }
}