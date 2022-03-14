using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;

namespace MySocialNetwork.Models
{
    public class MyDbContext: DbContext
    {
        public DbSet<Account> Accounts { get; set; }

        public DbSet<SubscribeModel> SubscribeModels { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            var appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            optionsBuilder.UseSqlite($"Filename={appData}/mysocialnetwork.db", option => {
                option.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
            });

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Account>()
                .ToTable("Accounts")
                .HasKey(c => new { c.Id });

            base.OnModelCreating(modelBuilder);
        }
    }
}
