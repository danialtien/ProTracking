using Microsoft.EntityFrameworkCore;
using ProTracking.Domain.Entities;
using ProTracking.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ProTracking.Infrastructures.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<ProjectParticipant> ProjectParticipants { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Label> Labels { get; set; }
        public DbSet<Todo> Todos { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<AccountType> AccountTypes { get; set; }
        public DbSet<ChildTask> ChildTasks { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<TransactionHistory> TransactionHistory { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AccountType>().HasData(
                 new AccountType { Id = 1, Title = AccountTypeEnum.Free, Description = "Free account", Index = 0, Price = 0 },
                 new AccountType { Id = 2, Title = AccountTypeEnum.Standard, Description = "Standard account", Index = 1, Price = 20 },
                 new AccountType { Id = 3, Title = AccountTypeEnum.Premium, Description = "Premium account", Index = 2, Price = 30 },
                 new AccountType { Id = 4, Title = AccountTypeEnum.Enterprise, Description = "Enterprise account", Index = 3, Price = 40 });

            modelBuilder.Entity<Customer>().HasData(
                new Customer
                {
                    Id = 1,
                    FirstName = "Hoang",
                    LastName = "Khoa",
                    Email = "khoa@gmail.com",
                    AccountTypeId = 1,
                    Birthday = DateTime.Now,
                    GoogleEmail = "khoa@gmail.com",
                    Password = "1234",
                    Phone = "08888888",
                    RegisteredAt = DateTime.Today,
                    Role = RoleEnum.Admin,
                    Status = "Active",
                    Username = "khoa"
                },
                new Customer
                {
                    Id = 2,
                    FirstName = "Hoang",
                    LastName = "Hai",
                    Email = "hai@gmail.com",
                    AccountTypeId = 1,
                    Birthday = DateTime.Now,
                    GoogleEmail = "hai@gmail.com",
                    Password = "1234",
                    Phone = "08888888",
                    RegisteredAt = DateTime.Today,
                    Role = RoleEnum.Admin,
                    Status = "Active",
                    Username = "khoa"
                }
                );
        }

    }
}
