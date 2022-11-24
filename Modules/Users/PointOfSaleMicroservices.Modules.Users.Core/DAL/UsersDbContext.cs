﻿using Microsoft.EntityFrameworkCore;
using PointOfSaleMicroservices.Modules.Users.Core.Entities;

namespace PointOfSaleMicroservices.Modules.Users.Core.DAL
{
    internal class UsersDbContext : DbContext
    {
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }

        public UsersDbContext(DbContextOptions<UsersDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("users");
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}
