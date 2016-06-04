namespace MvcTemplate.Data.Common
{
    using System.Linq;

    using MvcTemplate.Data.Common.Models;

    public interface IDbRepository<T> : IDbGenericRepository<T, int>
        where T : BaseModel<int>
    {
    }

    public interface IDbRepository<T, in TKey> : IDbGenericRepository<T, TKey>
        where T : BaseModel<TKey>
    {
        IQueryable<T> AllWithDeleted();

        void HardDelete(T entity);
    }
}
