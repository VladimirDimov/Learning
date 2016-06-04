namespace MvcTemplate.Data.Common
{
    using System.Linq;

    public interface IDbGenericRepository<T> : IDbGenericRepository<T, int>
    {
    }

    public interface IDbGenericRepository<T, in TKey>
    {
        IQueryable<T> All();

        T GetById(TKey id);

        void Add(T entity);

        void Delete(T entity);

        void Save();
    }
}
