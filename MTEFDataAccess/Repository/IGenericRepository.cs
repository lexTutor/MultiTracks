using MTEFDataAccess.Entities;

namespace MTEFDataAccess.Repository
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task InsertAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task SaveAsync(CancellationToken cancellationToken = default);

        IQueryable<T> Table { get; }
        IQueryable<T> TableNoTracking { get; }
    }
}
