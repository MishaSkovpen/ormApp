using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ormApp.Models
{
    public partial class financeContext : DbContext
    {
        public financeContext()
        {
        }

        public financeContext(DbContextOptions<financeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Expense> Expenses { get; set; } = null!;
        public virtual DbSet<Income> Incomes { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;database=finance;user id=svc_finance;password=passw0rd", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.4.0-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Expense>(entity =>
            {
                entity.HasIndex(e => e.UserId, "user_id");

                entity.Property(e => e.ExpenseId).HasColumnName("expense_id");

                entity.Property(e => e.Amount)
                    .HasPrecision(10, 2)
                    .HasColumnName("amount");

                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.Property(e => e.Date).HasColumnName("date");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Expenses)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("Expenses_ibfk_1");
            });

            modelBuilder.Entity<Income>(entity =>
            {
                entity.HasIndex(e => e.UserId, "user_id");

                entity.Property(e => e.IncomeId).HasColumnName("income_id");

                entity.Property(e => e.Amount)
                    .HasPrecision(10, 2)
                    .HasColumnName("amount");

                entity.Property(e => e.Date).HasColumnName("date");

                entity.Property(e => e.Source)
                    .HasMaxLength(255)
                    .HasColumnName("source");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Incomes)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("Incomes_ibfk_1");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.Address)
                    .HasMaxLength(255)
                    .HasColumnName("address");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(255)
                    .HasColumnName("first_name");

                entity.Property(e => e.LastName)
                    .HasMaxLength(255)
                    .HasColumnName("last_name");

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .HasColumnName("password");

                entity.Property(e => e.Username)
                    .HasMaxLength(255)
                    .HasColumnName("username");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
