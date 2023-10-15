﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProTracking.Infrastructures.Data;

#nullable disable

namespace ProTracking.Infrastructures.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GoogleEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GoogleId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastLoginAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("OAuthExpiry")
                        .HasColumnType("datetime2");

                    b.Property<string>("OAuthToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RegisteredAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Role")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
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
                            Birthday = new DateTime(2023, 10, 15, 1, 45, 32, 736, DateTimeKind.Local).AddTicks(4694),
                            Email = "khoa@gmail.com",
                            EndDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Hoang",
                            GoogleEmail = "khoa@gmail.com",
                            LastLoginAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastName = "Khoa",
                            OAuthExpiry = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Password = "1234",
                            Phone = "08888888",
                            RegisteredAt = new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Local),
                            Role = 1,
                            StartDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Status = "Active",
                            Username = "khoa"
                        },
                        new
                        {
                            Id = 2,
                            AccountTypeId = 1,
                            Birthday = new DateTime(2023, 10, 15, 1, 45, 32, 736, DateTimeKind.Local).AddTicks(4711),
                            Email = "hai@gmail.com",
                            EndDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Hoang",
                            GoogleEmail = "hai@gmail.com",
                            LastLoginAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastName = "Hai",
                            OAuthExpiry = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Password = "1234",
                            Phone = "08888888",
                            RegisteredAt = new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Local),
                            Role = 1,
                            StartDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
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

                    b.ToTable("ProjectParticipants");
                });

            modelBuilder.Entity("ProTracking.Domain.Entities.Todo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Assignee")
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

                    b.ToTable("Todos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Assignee = 1,
                            CreatedBy = 1,
                            EndDate = new DateTime(2023, 10, 22, 1, 45, 32, 736, DateTimeKind.Local).AddTicks(4760),
                            IconPriority = "",
                            LabelId = 1,
                            Priority = 5,
                            ProjectId = 1,
                            ReportTo = 0,
                            StartDate = new DateTime(2023, 10, 15, 1, 45, 32, 736, DateTimeKind.Local).AddTicks(4759),
                            Status = "In Progress",
                            Title = "Design UI/UX for application"
                        },
                        new
                        {
                            Id = 2,
                            Assignee = 1,
                            CreatedBy = 1,
                            EndDate = new DateTime(2023, 10, 22, 1, 45, 32, 736, DateTimeKind.Local).AddTicks(4768),
                            IconPriority = "",
                            LabelId = 2,
                            Priority = 5,
                            ProjectId = 1,
                            ReportTo = 0,
                            StartDate = new DateTime(2023, 10, 15, 1, 45, 32, 736, DateTimeKind.Local).AddTicks(4768),
                            Status = "Todo",
                            Title = "Builtd API for application"
                        },
                        new
                        {
                            Id = 3,
                            Assignee = 1,
                            CreatedBy = 1,
                            EndDate = new DateTime(2023, 10, 22, 1, 45, 32, 736, DateTimeKind.Local).AddTicks(4770),
                            IconPriority = "",
                            LabelId = 3,
                            Priority = 5,
                            ProjectId = 1,
                            ReportTo = 0,
                            StartDate = new DateTime(2023, 10, 15, 1, 45, 32, 736, DateTimeKind.Local).AddTicks(4769),
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

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("PaymentId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("TransactionHistory");
                });

            modelBuilder.Entity("ProTracking.Domain.Entities.Comment", b =>
                {
                    b.HasOne("ProTracking.Domain.Entities.Comment", "ReplyTo")
                        .WithMany()
                        .HasForeignKey("ReplyToId");

                    b.Navigation("ReplyTo");
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
#pragma warning restore 612, 618
        }
    }
}
