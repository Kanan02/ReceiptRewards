﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ReceiptRewards.Infrastructure.DataAccess.Contexts;

#nullable disable

namespace ReceiptRewards.Infrastructure.Migrations
{
    [DbContext(typeof(ReceiptRewardsAPIDbContext))]
    [Migration("20240718081343_Log Error")]
    partial class LogError
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.28")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("PresentUser", b =>
                {
                    b.Property<int>("PresentsId")
                        .HasColumnType("int");

                    b.Property<int>("UsersId")
                        .HasColumnType("int");

                    b.HasKey("PresentsId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("PresentUser");
                });

            modelBuilder.Entity("ReceiptRewards.Domain.Entities.AdditionalProperty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("PropertyName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PropertyValue")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("AdditionalProperties");
                });

            modelBuilder.Entity("ReceiptRewards.Domain.Entities.ErrorLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("LogType")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("ErrorLogs");
                });

            modelBuilder.Entity("ReceiptRewards.Domain.Entities.Present", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Presents");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2024, 7, 18, 12, 13, 43, 326, DateTimeKind.Local).AddTicks(6102),
                            Name = "TESS çanta",
                            Price = 1500,
                            Quantity = 200
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2024, 7, 18, 12, 13, 43, 326, DateTimeKind.Local).AddTicks(6106),
                            Name = "TESS fincan",
                            Price = 2000,
                            Quantity = 200
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(2024, 7, 18, 12, 13, 43, 326, DateTimeKind.Local).AddTicks(6108),
                            Name = "TESS T-Shirt",
                            Price = 2200,
                            Quantity = 200
                        },
                        new
                        {
                            Id = 4,
                            CreatedAt = new DateTime(2024, 7, 18, 12, 13, 43, 326, DateTimeKind.Local).AddTicks(6109),
                            Name = "TESS hədiyyə dəsti",
                            Price = 3500,
                            Quantity = 200
                        },
                        new
                        {
                            Id = 5,
                            CreatedAt = new DateTime(2024, 7, 18, 12, 13, 43, 326, DateTimeKind.Local).AddTicks(6111),
                            Name = "TESS uçuş yastğı",
                            Price = 4500,
                            Quantity = 200
                        },
                        new
                        {
                            Id = 6,
                            CreatedAt = new DateTime(2024, 7, 18, 12, 13, 43, 326, DateTimeKind.Local).AddTicks(6112),
                            Name = "TESS bel çanatası",
                            Price = 6500,
                            Quantity = 200
                        },
                        new
                        {
                            Id = 7,
                            CreatedAt = new DateTime(2024, 7, 18, 12, 13, 43, 326, DateTimeKind.Local).AddTicks(6114),
                            Name = "TESS idman çantası",
                            Price = 7000,
                            Quantity = 200
                        },
                        new
                        {
                            Id = 8,
                            CreatedAt = new DateTime(2024, 7, 18, 12, 13, 43, 326, DateTimeKind.Local).AddTicks(6115),
                            Name = "TESS gödəkçə",
                            Price = 8000,
                            Quantity = 200
                        });
                });

            modelBuilder.Entity("ReceiptRewards.Domain.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<double>("Price")
                        .HasColumnType("double");

                    b.Property<double>("Quantity")
                        .HasColumnType("double");

                    b.Property<int>("ReceiptId")
                        .HasColumnType("int");

                    b.Property<double>("TotalPrice")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.HasIndex("ReceiptId");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("ReceiptRewards.Domain.Entities.Receipt", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("ApprovalDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("City")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("FiscalDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("FiscalId")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Points")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Receipts");
                });

            modelBuilder.Entity("ReceiptRewards.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Instagram")
                        .HasColumnType("longtext");

                    b.Property<string>("Msisdn")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Operator")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Pending")
                        .HasColumnType("int");

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Remaining")
                        .HasColumnType("int");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<int>("Spent")
                        .HasColumnType("int");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Total")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = -1,
                            Address = "myaddress",
                            CreatedAt = new DateTime(2024, 7, 18, 12, 13, 43, 326, DateTimeKind.Local).AddTicks(5877),
                            Email = "ilkindenziyev@gmail.com",
                            Instagram = "admin",
                            Msisdn = "994506607883",
                            Name = "AdminName",
                            Operator = 0,
                            Password = "Admin123@",
                            Pending = 0,
                            RegisterDate = new DateTime(2024, 7, 18, 12, 13, 43, 326, DateTimeKind.Local).AddTicks(5850),
                            Remaining = 0,
                            Role = 0,
                            Spent = 0,
                            Surname = "AdminSurname",
                            Total = 0
                        });
                });

            modelBuilder.Entity("PresentUser", b =>
                {
                    b.HasOne("ReceiptRewards.Domain.Entities.Present", null)
                        .WithMany()
                        .HasForeignKey("PresentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ReceiptRewards.Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ReceiptRewards.Domain.Entities.Product", b =>
                {
                    b.HasOne("ReceiptRewards.Domain.Entities.Receipt", "Receipt")
                        .WithMany("products")
                        .HasForeignKey("ReceiptId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Receipt");
                });

            modelBuilder.Entity("ReceiptRewards.Domain.Entities.Receipt", b =>
                {
                    b.HasOne("ReceiptRewards.Domain.Entities.User", "User")
                        .WithMany("Receipts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ReceiptRewards.Domain.Entities.Receipt", b =>
                {
                    b.Navigation("products");
                });

            modelBuilder.Entity("ReceiptRewards.Domain.Entities.User", b =>
                {
                    b.Navigation("Receipts");
                });
#pragma warning restore 612, 618
        }
    }
}
