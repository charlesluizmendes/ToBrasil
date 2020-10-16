using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
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

        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Phone> Phone { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Users>()
            .ToTable("Users")
            .Property(p => p.Id)
            .HasColumnName("Id");
        }
    }
}
