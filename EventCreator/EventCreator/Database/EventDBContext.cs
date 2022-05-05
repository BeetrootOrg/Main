using Microsoft.EntityFrameworkCore;
using EventCreator.Models;

namespace EventCreator.Database
{
    public partial class EventsDBContext : DbContext
    {
        public EventsDBContext()
        {
        }

        public EventsDBContext(DbContextOptions<EventsDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<Location> Locations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event>(entity =>
            {
                entity.Property(e => e.EventDescription)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.EventName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(e => e.Location)
                    .WithMany(l => l.Events)
                    .HasForeignKey(x => x.LocationId);
            });

            modelBuilder.Entity<Location>(entity => entity.Property(x => x.Name)
                .HasMaxLength(1000)
                .IsUnicode(false));

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
