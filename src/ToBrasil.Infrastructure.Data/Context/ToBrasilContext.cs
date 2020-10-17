using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Text;
using ToBrasil.Domain.Entities;

namespace ToBrasil.Infrastructure.Data.Context
{
    public class ToBrasilContext : IdentityDbContext<Users, IdentityRole<Guid>, Guid>
    {
        public ToBrasilContext(DbContextOptions<ToBrasilContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Users> User { get; set; }
        public virtual DbSet<Phone> Phone { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Users>(e => 
            {
                e.ToTable("Users");
                e.Property(d => d.Created).ValueGeneratedOnAdd().HasDefaultValueSql("GETDATE()");
                e.Property(d => d.Modified).ValueGeneratedOnUpdate().HasComputedColumnSql("GETDATE()");
                e.Property(d => d.Modified).Metadata.SetBeforeSaveBehavior(PropertySaveBehavior.Ignore);
            });     
        }
    }
}
