﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ormApp.Models;

#nullable disable

namespace ormApp.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240618153223_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.31")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ormApp.Models.Expense", b =>
                {
                    b.Property<int>("ExpenseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("expense_id");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(10,2)")
                        .HasColumnName("amount");

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int")
                        .HasColumnName("category_id");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date")
                        .HasColumnName("date");

                    b.Property<int?>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("user_id");

                    b.HasKey("ExpenseId");

                    b.HasIndex("UserId");

                    b.ToTable("Expenses", (string)null);
                });

            modelBuilder.Entity("ormApp.Models.Income", b =>
                {
                    b.Property<int>("IncomeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("income_id");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(10,2)")
                        .HasColumnName("amount");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date")
                        .HasColumnName("date");

                    b.Property<string>("Source")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("source");

                    b.Property<int?>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("user_id");

                    b.HasKey("IncomeId");

                    b.HasIndex("UserId");

                    b.ToTable("Incomes", (string)null);
                });

            modelBuilder.Entity("ormApp.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("user_id");

                    b.Property<string>("Address")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("address");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("first_name");

                    b.Property<string>("LastName")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("last_name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("password");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("username");

                    b.HasKey("UserId");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("ormApp.Models.Expense", b =>
                {
                    b.HasOne("ormApp.Models.User", "User")
                        .WithMany("Expenses")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("User");
                });

            modelBuilder.Entity("ormApp.Models.Income", b =>
                {
                    b.HasOne("ormApp.Models.User", "User")
                        .WithMany("Incomes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("User");
                });

            modelBuilder.Entity("ormApp.Models.User", b =>
                {
                    b.Navigation("Expenses");

                    b.Navigation("Incomes");
                });
#pragma warning restore 612, 618
        }
    }
}
