using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;

namespace DapperTemplate.Data
{
    public class DbContext
    {
        string connectionString = @"data source=.\vdimov;initial catalog=NORTHWND;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework";

        public IEnumerable<Category> Get()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var result = connection.Query<Category>(sql: "Categories_All", commandType: System.Data.CommandType.StoredProcedure);

                return result;
            }
        }
    }
}