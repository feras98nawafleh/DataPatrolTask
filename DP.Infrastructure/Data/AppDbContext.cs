using DP.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace DP.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Policy> Policies { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<UserGroup> UserGroups { get; set; }
        public DbSet<UserRequest> UserRequests { get; set; }
        public DbSet<GroupPolicy> GroupPolicies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            ConfigureRelationships(modelBuilder);

            ConfigureUniqueConstraints(modelBuilder);

            SeedData(modelBuilder);
        }

        private void ConfigureRelationships(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasKey(u => u.UserId);
            modelBuilder.Entity<User>()
                .Property(u => u.UserId).HasMaxLength(30);
            modelBuilder.Entity<User>()
                .Property(u => u.Username).HasMaxLength(200);
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Username).IsUnique();

            modelBuilder.Entity<Policy>()
                .HasKey(p => p.PolicyId);
            modelBuilder.Entity<Policy>()
                .Property(p => p.PolicyId).HasMaxLength(30);
            modelBuilder.Entity<Policy>()
                .Property(p => p.PolicyName).HasMaxLength(200);

            modelBuilder.Entity<Group>()
                .HasKey(g => g.GroupId);
            modelBuilder.Entity<Group>()
                .Property(g => g.GroupId).HasMaxLength(30);
            modelBuilder.Entity<Group>()
                .Property(g => g.Description).HasMaxLength(200);

            modelBuilder.Entity<UserRequest>()
                .HasKey(r => r.RequestId);
            modelBuilder.Entity<UserRequest>()
                .Property(r => r.RequestedBy).HasMaxLength(30);
            modelBuilder.Entity<UserRequest>()
                .Property(r => r.Description).HasMaxLength(200);
            modelBuilder.Entity<UserRequest>()
                .HasOne(r => r.RequesterUser)
                .WithMany(u => u.Requests)
                .HasForeignKey(r => r.RequestedBy);

            modelBuilder.Entity<UserGroup>()
                .HasKey(ug => new { ug.UserId, ug.GroupId });

            modelBuilder.Entity<GroupPolicy>()
                .HasKey(pg => new { pg.PolicyId, pg.GroupId });
        }

        private void ConfigureUniqueConstraints(ModelBuilder modelBuilder)
        {
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
        }
    }
}