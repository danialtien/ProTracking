﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProTracking.Infrastructures.Data;

#nullable disable

namespace ProTracking.Infrastructures.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231125041501_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ProTracking.Domain.Entities.AccountType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Index")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AccountTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Free account",
                            Index = 0,
                            Price = 0.0,
                            Title = "Free"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Standard account",
                            Index = 1,
                            Price = 20.0,
                            Title = "Standard"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Premium account",
                            Index = 2,
                            Price = 30.0,
                            Title = "Premium"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Enterprise account",
                            Index = 3,
                            Price = 40.0,
                            Title = "Enterprise"
                        });
                });

            modelBuilder.Entity("ProTracking.Domain.Entities.ChildTask", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<int?>("Priority")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TodoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TodoId");

                    b.ToTable("ChildTasks");
                });

            modelBuilder.Entity("ProTracking.Domain.Entities.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<int?>("ReplyToId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TodoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ReplyToId");

                    b.HasIndex("TodoId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("ProTracking.Domain.Entities.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AccountTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Avatar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GoogleEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GoogleId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastLoginAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RegisteredAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Role")
                        .HasColumnType("int");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AccountTypeId");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AccountTypeId = 3,
                            Birthday = new DateTime(2023, 11, 25, 11, 15, 1, 314, DateTimeKind.Local).AddTicks(2381),
                            Email = "protracking@gmail.com",
                            FirstName = "ProTracking",
                            GoogleEmail = "protracking@gmail.com",
                            LastName = "ProTracking",
                            Password = "toilaadmin",
                            Phone = "08888888",
                            RegisteredAt = new DateTime(2023, 11, 25, 0, 0, 0, 0, DateTimeKind.Local),
                            Role = 1,
                            Status = "Active",
                            Username = "ProTracking"
                        },
                        new
                        {
                            Id = 2,
                            AccountTypeId = 3,
                            Birthday = new DateTime(2023, 11, 25, 11, 15, 1, 314, DateTimeKind.Local).AddTicks(2392),
                            Email = "khoa@gmail.com",
                            FirstName = "Hoang",
                            GoogleEmail = "khoa@gmail.com",
                            LastName = "Khoa",
                            Password = "1234",
                            Phone = "08888888",
                            RegisteredAt = new DateTime(2023, 11, 25, 0, 0, 0, 0, DateTimeKind.Local),
                            Role = 1,
                            Status = "Active",
                            Username = "khoa"
                        },
                        new
                        {
                            Id = 3,
                            AccountTypeId = 1,
                            Birthday = new DateTime(2023, 11, 25, 11, 15, 1, 314, DateTimeKind.Local).AddTicks(2394),
                            Email = "hai@gmail.com",
                            FirstName = "Hoang",
                            GoogleEmail = "hai@gmail.com",
                            LastName = "Hai",
                            Password = "1234",
                            Phone = "08888888",
                            RegisteredAt = new DateTime(2023, 11, 25, 0, 0, 0, 0, DateTimeKind.Local),
                            Role = 1,
                            Status = "Active",
                            Username = "khoa"
                        });
                });

            modelBuilder.Entity("ProTracking.Domain.Entities.Label", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("Labels");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ProjectId = 1,
                            Title = "Frontend"
                        },
                        new
                        {
                            Id = 2,
                            ProjectId = 1,
                            Title = "Backend"
                        },
                        new
                        {
                            Id = 3,
                            ProjectId = 1,
                            Title = "AI"
                        },
                        new
                        {
                            Id = 4,
                            ProjectId = 1,
                            Title = "Marketing"
                        });
                });

            modelBuilder.Entity("ProTracking.Domain.Entities.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AccessKey")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PrivateKey")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("QRCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Payments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AccessKey = "Free",
                            PrivateKey = "Free",
                            QRCode = "Free",
                            Title = "Free"
                        },
                        new
                        {
                            Id = 2,
                            AccessKey = "Normal",
                            PrivateKey = "Normal",
                            QRCode = "https://drive.google.com/file/d/10qMV7ydU1rCyhMaZdHTmzwQh6_vkFv4n/view?usp=sharing",
                            Title = "ZaloPay"
                        },
                        new
                        {
                            Id = 3,
                            AccessKey = "Standard",
                            PrivateKey = "Standard",
                            QRCode = "https://drive.google.com/file/d/1KhnoyG2OcJjR5isd44K4mMC6nXZs-VxE/view?usp=sharing",
                            Title = "ZaloPay"
                        },
                        new
                        {
                            Id = 4,
                            AccessKey = "Premium",
                            PrivateKey = "Premium",
                            QRCode = "https://drive.google.com/file/d/1lyhl-L9asLIx48XAws8F50pGrTvLSocX/view?usp=sharing",
                            Title = "ZaloPay"
                        },
                        new
                        {
                            Id = 5,
                            AccessKey = "Normal",
                            PrivateKey = "Normal",
                            QRCode = "https://drive.google.com/file/d/17gfyZEJWp-6ltJQazuAxj86nzxRoRmhM/view?usp=sharing",
                            Title = "TPBank"
                        },
                        new
                        {
                            Id = 6,
                            AccessKey = "Standard",
                            PrivateKey = "Standard",
                            QRCode = "https://drive.google.com/file/d/1bXRIqAG_qDv5VXlL4_Lr2EDqPa3nhVYI/view?usp=sharing",
                            Title = "TPBank"
                        },
                        new
                        {
                            Id = 7,
                            AccessKey = "Premium",
                            PrivateKey = "Premium",
                            QRCode = "https://drive.google.com/file/d/1V9ykNI_Rsm4bZWvMZ-rORTG9SPPjBB7l/view?usp=sharing",
                            Title = "TPBank"
                        });
                });

            modelBuilder.Entity("ProTracking.Domain.Entities.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SubTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Projects");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedBy = 2,
                            Description = "A startup project helping user to manage projects",
                            Status = "Active",
                            SubTitle = "ProTracking make your work easier",
                            Title = "ProTracking EXE201"
                        });
                });

            modelBuilder.Entity("ProTracking.Domain.Entities.ProjectParticipant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<bool>("IsLeader")
                        .HasColumnType("bit");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ProjectParticipants");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CustomerId = 2,
                            IsLeader = true,
                            ProjectId = 1
                        });
                });

            modelBuilder.Entity("ProTracking.Domain.Entities.Todo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("Assignee")
                        .HasColumnType("int");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("IconPriority")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("LabelId")
                        .HasColumnType("int");

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<int?>("ReportTo")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Todos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Assignee = 2,
                            CreatedBy = 2,
                            EndDate = new DateTime(2023, 12, 2, 11, 15, 1, 314, DateTimeKind.Local).AddTicks(2445),
                            IconPriority = "",
                            LabelId = 1,
                            Priority = 5,
                            ProjectId = 1,
                            StartDate = new DateTime(2023, 11, 25, 11, 15, 1, 314, DateTimeKind.Local).AddTicks(2445),
                            Status = "In Progress",
                            Title = "Design UI/UX for application"
                        },
                        new
                        {
                            Id = 2,
                            Assignee = 2,
                            CreatedBy = 2,
                            EndDate = new DateTime(2023, 12, 2, 11, 15, 1, 314, DateTimeKind.Local).AddTicks(2448),
                            IconPriority = "",
                            LabelId = 2,
                            Priority = 5,
                            ProjectId = 1,
                            StartDate = new DateTime(2023, 11, 25, 11, 15, 1, 314, DateTimeKind.Local).AddTicks(2447),
                            Status = "Todo",
                            Title = "Builtd API for application"
                        },
                        new
                        {
                            Id = 3,
                            Assignee = 2,
                            CreatedBy = 2,
                            EndDate = new DateTime(2023, 12, 2, 11, 15, 1, 314, DateTimeKind.Local).AddTicks(2450),
                            IconPriority = "",
                            LabelId = 3,
                            Priority = 5,
                            ProjectId = 1,
                            StartDate = new DateTime(2023, 11, 25, 11, 15, 1, 314, DateTimeKind.Local).AddTicks(2450),
                            Status = "In Progress",
                            Title = "Integrated Chatbox to application"
                        });
                });

            modelBuilder.Entity("ProTracking.Domain.Entities.TransactionHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AccountTypeId")
                        .HasColumnType("int");

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsBanking")
                        .HasColumnType("bit");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("PaymentId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("TransactionHistory");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AccountTypeId = 1,
                            Amount = 0.0,
                            CustomerId = 2,
                            EndDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsActive = false,
                            IsBanking = false,
                            PaymentDate = new DateTime(2023, 11, 25, 11, 15, 1, 314, DateTimeKind.Local).AddTicks(9356),
                            PaymentId = 1,
                            StartDate = new DateTime(2023, 11, 25, 11, 15, 1, 314, DateTimeKind.Local).AddTicks(9360)
                        });
                });

            modelBuilder.Entity("ProTracking.Domain.Entities.ChildTask", b =>
                {
                    b.HasOne("ProTracking.Domain.Entities.Todo", "Todo")
                        .WithMany()
                        .HasForeignKey("TodoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Todo");
                });

            modelBuilder.Entity("ProTracking.Domain.Entities.Comment", b =>
                {
                    b.HasOne("ProTracking.Domain.Entities.Comment", "ReplyTo")
                        .WithMany()
                        .HasForeignKey("ReplyToId");

                    b.HasOne("ProTracking.Domain.Entities.Todo", "Todo")
                        .WithMany()
                        .HasForeignKey("TodoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ReplyTo");

                    b.Navigation("Todo");
                });

            modelBuilder.Entity("ProTracking.Domain.Entities.Customer", b =>
                {
                    b.HasOne("ProTracking.Domain.Entities.AccountType", "AccountType")
                        .WithMany()
                        .HasForeignKey("AccountTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AccountType");
                });

            modelBuilder.Entity("ProTracking.Domain.Entities.Label", b =>
                {
                    b.HasOne("ProTracking.Domain.Entities.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");
                });

            modelBuilder.Entity("ProTracking.Domain.Entities.TransactionHistory", b =>
                {
                    b.HasOne("ProTracking.Domain.Entities.Customer", "Customer")
                        .WithMany("TransactionHistories")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("ProTracking.Domain.Entities.Customer", b =>
                {
                    b.Navigation("TransactionHistories");
                });
#pragma warning restore 612, 618
        }
    }
}