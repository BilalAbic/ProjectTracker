using Microsoft.EntityFrameworkCore;
using ProjectTracker.API.Models;

namespace ProjectTracker.API.Data
{
    /// <summary>
    /// Basit DbContext - Sadece Invitations tablosu için
    /// </summary>
    public class InvitationDbContext : DbContext
    {
        public InvitationDbContext(DbContextOptions<InvitationDbContext> options) : base(options)
        {
        }

        public DbSet<InvitationModel> Invitations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InvitationModel>(entity =>
            {
                entity.ToTable("Invitations");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Token).HasMaxLength(100).IsRequired();
                entity.Property(e => e.Email).HasMaxLength(255).IsRequired();
                entity.Property(e => e.TeamName).HasMaxLength(100).IsRequired();
                entity.Property(e => e.InvitedByName).HasMaxLength(100).IsRequired();
                entity.Property(e => e.ProposedRole).HasMaxLength(50).IsRequired();
                entity.Property(e => e.Status).HasMaxLength(20).HasDefaultValue("Pending");
                entity.HasIndex(e => e.Token).IsUnique();
                entity.HasIndex(e => e.Email);
            });
        }
    }
}
