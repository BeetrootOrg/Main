using Microsoft.EntityFrameworkCore;
using WebApplication.Models;

namespace WebApplication.Database
{
    public partial class OrderDbContext: DbContext
    {
        public OrderDbContext()
        {
        }

        public OrderDbContext(DbContextOptions<OrderDbContext> options)
            : base(options)
        {
        }
       
        public virtual DbSet<Order> Orders { get; set; } = null!;

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Server=AMIGA\\SQLEXPRESS;Database=OrderDB;Trusted_Connection=True;");
            
//            }

//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.Customer)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Flash)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Manager)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Modified).HasColumnType("datetime");

                entity.Property(e => e.Note).HasColumnType("text");

                entity.Property(e => e.Operator)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Ord)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Steel)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Surface)
                    .HasMaxLength(60)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
