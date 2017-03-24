using System.Collections.Generic;

namespace DapperTemplate.Data
{
    public interface IDapperRequester
    {
        IEnumerable<T> Query<T>(string procedure);

        T QueryFirst<T>(string procedure, object id);
    }
}