using Blogging.Domain.Entities;
using Blogging.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;

namespace Blogging.Persistence;

public class BlogDbContext : DbContext
{
    public BlogDbContext(DbContextOptions<BlogDbContext> opt) : base(opt)
    {
    }
    
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        foreach (var entry in ChangeTracker.Entries<BaseDomainEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedDate = DateTime.UtcNow;
                    entry.Entity.CreatedBy = "Api";
                    break;
                case EntityState.Modified:
                    entry.Entity.LastModifiedDate = DateTime.UtcNow;
                    entry.Entity.ModifiedBy = "Api";
                    break;
            }
        }
        return base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<Article>(entity =>
        {
            entity
                .HasOne(e => e.User)
                .WithMany(u => u.Articles)
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Article_User");
        });
        builder.Entity<ApplicationUser>(entity =>
        {
            entity
                .HasMany(e => e.Articles)
                .WithOne(a => a.User)
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_User_Article");
        });
    }

    public DbSet<Article> Articles { get; set; }
    public DbSet<ApplicationUser> Users { get; set; }
}