using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection.Metadata;
using System.Text;

namespace DAL.EF
{
    public class StorageContext : DbContext
    {
        public DbSet<Storage> Storages { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<StoringFee> StoringFees { get; set; }
        public DbSet<Application> Applications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
            .HasOne(b => b.Storage)
                       .WithOne(i => i.Director)
                       .HasForeignKey<Storage>(b => b.DirectorID);
        }

        public StorageContext(DbContextOptions options)
            : base(options)
        {
        }
    }
}