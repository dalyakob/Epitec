using Microsoft.EntityFrameworkCore;
using Module1.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Module1.Data
{
    public class ApplicationDbContext : DbContext
    {
        private string _myConnectionString { get; set; } = @"Server = localhost; Database = EpitecDb; Trusted_Connection = True;";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies().UseSqlServer(_myConnectionString);
        }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<Employee> Employees { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    Id = Guid.NewGuid(),
                    FirstName = "David",
                    LastName = "Al-Yakobi"
                },
                new Employee
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Jelard",
                    LastName = "Macalino"
                },
                new Employee
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Steve",
                    LastName = "Karim"
                });

        }
    }
}
