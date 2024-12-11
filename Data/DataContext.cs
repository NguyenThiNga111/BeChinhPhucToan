using Microsoft.EntityFrameworkCore;
using BeChinhPhucToan_BE.Models;

namespace BeChinhPhucToan_BE.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Administrator> Administrators { get; set; }

        public override int SaveChanges()
        {
            AddTimestamps();
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            AddTimestamps();
            return await base.SaveChangesAsync();
        }

        private void AddTimestamps()
        {
            var entities = ChangeTracker.Entries()
                .Where(x => x.Entity is BaseEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));

            foreach (var entity in entities)
            {
                var now = DateTime.UtcNow; // current datetime

                if (entity.State == EntityState.Added)
                {
                    ((BaseEntity)entity.Entity).createdAt = now;
                }
                ((BaseEntity)entity.Entity).updatedAt = now;
            }
        }
    }
}
