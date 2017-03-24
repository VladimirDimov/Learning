using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using DapperTemplate.Data.DbModels;

namespace DapperTemplate.Data
{
    public class DapperRequester : IDapperRequester
    {
        private string connectionString = @"data source=.\vdimov;initial catalog=NORTHWND;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework";

        public IEnumerable<T> Query<T>(string procedure)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                this.OpenConnection(connection);

                var result = connection.Query<T>(
                    sql: procedure,
                    commandType: CommandType.StoredProcedure);

                return result;
            }
        }

        public T QueryFirst<T>(string procedure, object id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                this.OpenConnection(connection);

                var result = connection.QueryFirst<T>(
                    sql: procedure,
                    commandType: CommandType.StoredProcedure,
                    param: new { id = id });

                return result;
            }
        }

        private void OpenConnection(SqlConnection connection)
        {
            try
            {
                connection.Open();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
    }
}