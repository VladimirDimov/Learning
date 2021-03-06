﻿namespace MenuCalculator.Database
{
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Threading.Tasks;
    using Dapper;

    public class DapperRequester : IDapperRequester
    {
        private string connectionString = @"data source=.\vdimov;initial catalog=MenuCalculator;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework";

        public DapperRequester()
        {
        }

        public Task<IEnumerable<T>> QueryAsync<T>(string procedure)
        {
            return this.QueryAsync<T>(procedure, null);
        }

        public Task<IEnumerable<T>> QueryAsync<T>(string procedure, object parameters)
        {
            return Task.Factory.StartNew(() =>
            {
                return this.Query<T>(procedure, parameters);
            });
        }

        public IEnumerable<T> Query<T>(string procedure)
        {
            return this.Query<T>(procedure, null);
        }

        public IEnumerable<T> Query<T>(string procedure, object parameters)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                this.OpenConnection(connection);

                var result = connection.Query<T>(
                    sql: procedure,
                    commandType: CommandType.StoredProcedure,
                    param: parameters);

                return result;
            }
        }

        public Task<T> QueryFirstAsync<T>(string procedure)
        {
            return this.QueryFirstAsync<T>(procedure, null);
        }

        public Task<T> QueryFirstAsync<T>(string procedure, object parameters)
        {
            return Task.Factory.StartNew<T>(() =>
            {
                return this.QueryFirst<T>(procedure, parameters);
            });
        }

        public T QueryFirst<T>(string procedure)
        {
            return this.QueryFirst<T>(procedure, null);
        }

        public T QueryFirst<T>(string procedure, object parameters)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                this.OpenConnection(connection);

                var result = connection.QueryFirst<T>(
                    sql: procedure,
                    commandType: CommandType.StoredProcedure,
                    param: parameters);

                return result;
            }
        }

        public Task<int> ExecuteAsyncstring(string procedure, object parameters)
        {
            return Task.Factory.StartNew(() =>
            {
                return this.Execute(procedure, parameters);
            });
        }

        /// <summary>
        /// Executes the specified procedure.
        /// </summary>
        /// <param name="procedure">The procedure.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>Rows affewcted.</returns>
        public int Execute(string procedure, object parameters)
        {
            using (var connection = new SqlConnection(this.connectionString))
            {
                this.OpenConnection(connection);

                var rowsAffected = connection.Execute(
                    sql: procedure,
                    param: parameters);

                return rowsAffected;
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