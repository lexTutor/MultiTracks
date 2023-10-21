using Microsoft.EntityFrameworkCore;
using MTEFDataAccess.Entities;

namespace MTEFDataAccess.Data
{
    public class SQLContext : DbContext
    {
        public SQLContext(DbContextOptions<SQLContext> dbcontext) : base(dbcontext) { }

        public DbSet<Artist> Artist { get; set; }
        public DbSet<Song> Song { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var item in ChangeTracker.Entries<BaseEntity>())
            {
                switch (item.State)
                {
                    case EntityState.Added:
                        item.Entity.DateCreation = DateTime.UtcNow;
                        break;
                    default:
                        break;
                }
            }

            return await base.SaveChangesAsync(cancellationToken);
        }

    }
}
