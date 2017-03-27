namespace MenuCalculator.Database
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IDapperRequester
    {
        IEnumerable<T> Query<T>(string procedure);

        IEnumerable<T> Query<T>(string procedure, object parameters);

        Task<IEnumerable<T>> QueryAsync<T>(string procedure);

        Task<IEnumerable<T>> QueryAsync<T>(string procedure, object parameters);

        T QueryFirst<T>(string procedure);

        T QueryFirst<T>(string procedure, object parameters);

        Task<T> QueryFirstAsync<T>(string procedure);

        Task<T> QueryFirstAsync<T>(string procedure, object parameters);

        Task<int> ExecuteAsyncstring(string procedure, object parameters);

        int Execute(string procedure, object parameters);
    }
}