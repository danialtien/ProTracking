using Microsoft.EntityFrameworkCore;
using ProTracking.Domain.Entities;
using ProTracking.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Numerics;
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

            modelBuilder.Entity<Payment>().HasData(
                 new Payment { Id = 1, Title = "Free", AccessKey = "Free", PrivateKey = "Free", QRCode = "Free" },
                 new Payment { Id = 2, Title = "ZaloPay", AccessKey = "Normal", PrivateKey = "Normal", QRCode = "https://drive.google.com/file/d/10qMV7ydU1rCyhMaZdHTmzwQh6_vkFv4n/view?usp=sharing" },
                 new Payment { Id = 3, Title = "ZaloPay", AccessKey = "Standard", PrivateKey = "Standard", QRCode = "https://drive.google.com/file/d/1KhnoyG2OcJjR5isd44K4mMC6nXZs-VxE/view?usp=sharing" },
                 new Payment { Id = 4, Title = "ZaloPay", AccessKey = "Premium", PrivateKey = "Premium", QRCode = "https://drive.google.com/file/d/1lyhl-L9asLIx48XAws8F50pGrTvLSocX/view?usp=sharing" },
                 new Payment { Id = 5, Title = "TPBank", AccessKey = "Normal", PrivateKey = "Normal", QRCode = "https://drive.google.com/file/d/17gfyZEJWp-6ltJQazuAxj86nzxRoRmhM/view?usp=sharing" },
                 new Payment { Id = 6, Title = "TPBank", AccessKey = "Standard", PrivateKey = "Standard", QRCode = "https://drive.google.com/file/d/1bXRIqAG_qDv5VXlL4_Lr2EDqPa3nhVYI/view?usp=sharing" },
                 new Payment { Id = 7, Title = "TPBank", AccessKey = "Premium", PrivateKey = "Premium", QRCode = "https://drive.google.com/file/d/1V9ykNI_Rsm4bZWvMZ-rORTG9SPPjBB7l/view?usp=sharing" }
                 );

            modelBuilder.Entity<Customer>().HasData(
                new Customer
                {
                    Id = 1,
                    FirstName = "ProTracking",
                    LastName = "ProTracking",
                    Email = "protracking@gmail.com",
                    AccountTypeId = 3,
                    Birthday = DateTime.Now,
                    GoogleEmail = "protracking@gmail.com",
                    Password = "toilaadmin",
                    Phone = "08888888",
                    RegisteredAt = DateTime.Today,
                    Role = RoleEnum.Admin,
                    Status = "Active",
                    Username = "ProTracking"
                },
                new Customer
                {
                    Id = 2,
                    FirstName = "Hoang",
                    LastName = "Khoa",
                    Email = "khoa@gmail.com",
                    AccountTypeId = 3,
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
                    Id = 3,
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


            modelBuilder.Entity<Project>().HasData(
                    new Project
                    {
                        Id = 1,
                        Title = "ProTracking EXE201",
                        CreatedBy = 2,
                        Description = "A startup project helping user to manage projects",
                        Status = "Active",
                        SubTitle = "ProTracking make your work easier"
                    });

            modelBuilder.Entity<ProjectParticipant>().HasData(
                new ProjectParticipant
                {
                    Id = 1,
                    CustomerId = 2,
                    ProjectId = 1,
                    IsLeader = true,
                    /*Customer = new()
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
                    Project = new()
                    {
                        Id = 1,
                        Title = "ProTracking EXE201",
                        CreatedBy = 1,
                        Description = "A startup project helping user to manage projects",
                        Status = "Active",
                        SubTitle = "ProTracking make your work easier"
                    }*/
                });


            modelBuilder.Entity<Label>().HasData(
                new Label
                {
                    Id = 1,
                    ProjectId = 1,
                    Title = "Frontend"
                },
                new Label
                {
                    Id = 2,
                    ProjectId = 1,
                    Title = "Backend"
                },
                new Label
                {
                    Id = 3,
                    ProjectId = 1,
                    Title = "AI"
                },
                new Label
                {
                    Id = 4,
                    ProjectId = 1,
                    Title = "Marketing"
                });

            modelBuilder.Entity<Todo>().HasData(
                new Todo
                {
                    Id = 1,
                    ProjectId = 1,
                    LabelId = 1,
                    Title = "Design UI/UX for application",
                    Status = StringConstUtil.IN_PROGRESS,
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddDays(7),
                    Assignee = 2,
                    CreatedBy = 2,
                    Priority = PriorityEnum.Highest,
                    IconPriority = ""
                },
                new Todo
                {
                    Id = 2,
                    ProjectId = 1,
                    LabelId = 2,
                    Title = "Builtd API for application",
                    Status = StringConstUtil.TODO,
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddDays(7),
                    Assignee = 2,
                    CreatedBy = 2,
                    Priority = PriorityEnum.Highest,
                    IconPriority = ""
                },
                new Todo
                {
                    Id = 3,
                    ProjectId = 1,
                    LabelId = 3,
                    Title = "Integrated Chatbox to application",
                    Status = StringConstUtil.IN_PROGRESS,
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddDays(7),
                    Assignee = 2,
                    CreatedBy = 2,
                    Priority = PriorityEnum.Highest,
                    IconPriority = ""
                });

            modelBuilder.Entity<TransactionHistory>()
                .HasOne(th => th.Customer)
                .WithMany(c => c.TransactionHistories)
                .HasForeignKey(th => th.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<TransactionHistory>().HasData(
                new TransactionHistory
                {
                    Id = 1,
                    CustomerId = 2,
                    AccountTypeId = 1,
                    PaymentId = 1,
                    PaymentDate = DateTime.Now,
                    StartDate = DateTime.Now,
                    Amount = 0,
                });

        }

    }
}
