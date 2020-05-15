using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using TinyBlog.DAL.Helpers.Interfaces;

namespace TinyBlog.DAL.Helpers
{
    public class DALHelper:IDALHelper
    {
        public string connectionString = string.Empty;

        public DALHelper(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public SqlCommand GetCommand(string commandText)
        {
            SqlCommand command = new SqlCommand(commandText);
            return command;
        }
        public async Task<DbDataReader> ExecuteReaderAsync(SqlCommand command)
        {
            SqlConnection connection = new SqlConnection(this.connectionString);
            command.Connection = connection;
            DbDataReader reader = null;
            try
            {
                connection.Open();
                reader = await command.ExecuteReaderAsync();
            }catch(SqlException ex)
            {
                throw (ex);
            }
            return reader;
        }

        public async Task<int> ExecuteNonQueryAsync(SqlCommand command)
        {
            SqlConnection connection = new SqlConnection(this.connectionString);
            int IsQuerySuccess = 0;
            SqlCommand sqlCommand = command;
            sqlCommand.Connection = connection;
            try
            {
                connection.Open();
                IsQuerySuccess = await sqlCommand.ExecuteNonQueryAsync();
            }
            catch(SqlException ex)
            {
                string sr = ex.Message;
                return IsQuerySuccess;
            }
            finally
            {
                connection.Close();
            }
            return IsQuerySuccess;
        }
    }
}
