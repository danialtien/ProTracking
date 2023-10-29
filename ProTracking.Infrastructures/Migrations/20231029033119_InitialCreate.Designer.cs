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
    [Migration("20231029033119_InitialCreate")]
    partial class InitialCreate
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
                            AccountTypeId = 1,
                            Birthday = new DateTime(2023, 10, 29, 10, 31, 19, 527, DateTimeKind.Local).AddTicks(9003),
                            Email = "khoa@gmail.com",
                            FirstName = "Hoang",
                            GoogleEmail = "khoa@gmail.com",
                            LastName = "Khoa",
                            Password = "1234",
                            Phone = "08888888",
                            RegisteredAt = new DateTime(2023, 10, 29, 0, 0, 0, 0, DateTimeKind.Local),
                            Role = 1,
                            Status = "Active",
                            Username = "khoa"
                        },
                        new
                        {
                            Id = 2,
                            AccountTypeId = 1,
                            Birthday = new DateTime(2023, 10, 29, 10, 31, 19, 527, DateTimeKind.Local).AddTicks(9023),
                            Email = "hai@gmail.com",
                            FirstName = "Hoang",
                            GoogleEmail = "hai@gmail.com",
                            LastName = "Hai",
                            Password = "1234",
                            Phone = "08888888",
                            RegisteredAt = new DateTime(2023, 10, 29, 0, 0, 0, 0, DateTimeKind.Local),
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
                            AccessKey = "AceessKey",
                            PrivateKey = "Privatekey",
                            QRCode = "dfsdalfdfa",
                            Title = "ZaloPay"
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
                            CreatedBy = 1,
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

                    b.HasIndex("CustomerId");

                    b.HasIndex("ProjectId");

                    b.ToTable("ProjectParticipants");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CustomerId = 1,
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

                    b.Property<int>("ReportTo")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("LabelId");

                    b.HasIndex("ProjectId");

                    b.ToTable("Todos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Assignee = 1,
                            CreatedBy = 1,
                            EndDate = new DateTime(2023, 11, 5, 10, 31, 19, 527, DateTimeKind.Local).AddTicks(9077),
                            IconPriority = "",
                            LabelId = 1,
                            Priority = 5,
                            ProjectId = 1,
                            ReportTo = 0,
                            StartDate = new DateTime(2023, 10, 29, 10, 31, 19, 527, DateTimeKind.Local).AddTicks(9076),
                            Status = "In Progress",
                            Title = "Design UI/UX for application"
                        },
                        new
                        {
                            Id = 2,
                            Assignee = 1,
                            CreatedBy = 1,
                            EndDate = new DateTime(2023, 11, 5, 10, 31, 19, 527, DateTimeKind.Local).AddTicks(9086),
                            IconPriority = "",
                            LabelId = 2,
                            Priority = 5,
                            ProjectId = 1,
                            ReportTo = 0,
                            StartDate = new DateTime(2023, 10, 29, 10, 31, 19, 527, DateTimeKind.Local).AddTicks(9085),
                            Status = "Todo",
                            Title = "Builtd API for application"
                        },
                        new
                        {
                            Id = 3,
                            Assignee = 1,
                            CreatedBy = 1,
                            EndDate = new DateTime(2023, 11, 5, 10, 31, 19, 527, DateTimeKind.Local).AddTicks(9088),
                            IconPriority = "",
                            LabelId = 3,
                            Priority = 5,
                            ProjectId = 1,
                            ReportTo = 0,
                            StartDate = new DateTime(2023, 10, 29, 10, 31, 19, 527, DateTimeKind.Local).AddTicks(9087),
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

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("PaymentId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AccountTypeId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("PaymentId");

                    b.ToTable("TransactionHistory");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AccountTypeId = 1,
                            Amount = 0.0,
                            CustomerId = 1,
                            EndDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsActive = false,
                            PaymentDate = new DateTime(2023, 10, 29, 10, 31, 19, 528, DateTimeKind.Local).AddTicks(2005),
                            PaymentId = 1,
                            StartDate = new DateTime(2023, 10, 29, 10, 31, 19, 528, DateTimeKind.Local).AddTicks(2008)
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

            modelBuilder.Entity("ProTracking.Domain.Entities.ProjectParticipant", b =>
                {
                    b.HasOne("ProTracking.Domain.Entities.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProTracking.Domain.Entities.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("ProTracking.Domain.Entities.Todo", b =>
                {
                    b.HasOne("ProTracking.Domain.Entities.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CreatedBy")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProTracking.Domain.Entities.Label", "Label")
                        .WithMany()
                        .HasForeignKey("LabelId");

                    b.HasOne("ProTracking.Domain.Entities.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Label");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("ProTracking.Domain.Entities.TransactionHistory", b =>
                {
                    b.HasOne("ProTracking.Domain.Entities.AccountType", "AccountType")
                        .WithMany()
                        .HasForeignKey("AccountTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProTracking.Domain.Entities.Customer", "Customer")
                        .WithMany("TransactionHistories")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ProTracking.Domain.Entities.Payment", "Payment")
                        .WithMany()
                        .HasForeignKey("PaymentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AccountType");

                    b.Navigation("Customer");

                    b.Navigation("Payment");
                });

            modelBuilder.Entity("ProTracking.Domain.Entities.Customer", b =>
                {
                    b.Navigation("TransactionHistories");
                });
#pragma warning restore 612, 618
        }
    }
}