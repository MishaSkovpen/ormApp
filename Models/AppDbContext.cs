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
                entity.HasKey(e => e.UserId);

                entity.Property(e => e.Username).IsRequired().HasMaxLength(255);
                entity.Property(e => e.Password).IsRequired().HasMaxLength(255);
                entity.Property(e => e.Email).IsRequired().HasMaxLength(255);
                entity.Property(e => e.FirstName).HasMaxLength(255);
                entity.Property(e => e.LastName).HasMaxLength(255);
                entity.Property(e => e.Address).HasMaxLength(255);
            });

            modelBuilder.Entity<Income>(entity =>
            {
                entity.HasKey(e => e.IncomeId);

                entity.Property(e => e.Amount).HasColumnType("decimal(10,2)").IsRequired();
                entity.Property(e => e.Date).HasColumnType("date").IsRequired();
                entity.Property(e => e.Source).HasMaxLength(255);

                entity.HasOne(d => d.User)
                      .WithMany(p => p.Incomes)
                      .HasForeignKey(d => d.UserId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Expense>(entity =>
            {
                entity.HasKey(e => e.ExpenseId);

                entity.Property(e => e.Amount).HasColumnType("decimal(10,2)").IsRequired();
                entity.Property(e => e.Date).HasColumnType("date").IsRequired();

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
