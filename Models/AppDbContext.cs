using Microsoft.EntityFrameworkCore;

namespace ormApp.Models
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Income> Incomes { get; set; }
        public virtual DbSet<Expense> Expenses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("Users");

                entity.HasKey(e => e.UserId);

                entity.Property(e => e.UserId).HasColumnName("user_id");
                entity.Property(e => e.Username).HasColumnName("username").IsRequired().HasMaxLength(255);
                entity.Property(e => e.Password).HasColumnName("password").IsRequired().HasMaxLength(255);
                entity.Property(e => e.Email).HasColumnName("email").IsRequired().HasMaxLength(255);
                entity.Property(e => e.FirstName).HasColumnName("first_name").HasMaxLength(255);
                entity.Property(e => e.LastName).HasColumnName("last_name").HasMaxLength(255);
                entity.Property(e => e.Address).HasColumnName("address").HasMaxLength(255);
            });

            modelBuilder.Entity<Income>(entity =>
            {
                entity.ToTable("Incomes");

                entity.HasKey(e => e.IncomeId);

                entity.Property(e => e.IncomeId).HasColumnName("income_id");
                entity.Property(e => e.UserId).HasColumnName("user_id");
                entity.Property(e => e.Amount).HasColumnName("amount").HasColumnType("decimal(10, 2)").IsRequired();
                entity.Property(e => e.Date).HasColumnName("date").HasColumnType("date").IsRequired();
                entity.Property(e => e.Source).HasColumnName("source").HasMaxLength(255);

                entity.HasOne(d => d.User)
                      .WithMany(p => p.Incomes)
                      .HasForeignKey(d => d.UserId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Expense>(entity =>
            {
                entity.ToTable("Expenses");

                entity.HasKey(e => e.ExpenseId);

                entity.Property(e => e.ExpenseId).HasColumnName("expense_id");
                entity.Property(e => e.UserId).HasColumnName("user_id");
                entity.Property(e => e.Amount).HasColumnName("amount").HasColumnType("decimal(10, 2)").IsRequired();
                entity.Property(e => e.Date).HasColumnName("date").HasColumnType("date").IsRequired();
                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.HasOne(d => d.User)
                      .WithMany(p => p.Expenses)
                      .HasForeignKey(d => d.UserId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
