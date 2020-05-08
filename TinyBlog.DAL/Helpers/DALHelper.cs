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
            //SqlConnection connection = new SqlConnection(@"Data Source=A2ML32669\SQLEXPRESS;Initial Catalog=TinyBlog;Integrated Security=True;MultipleActiveResultSets=True");
            //command.Connection = connection;
            int IsQuerySuccess = 0;
            //string query = "Insert into [dbo].[User](UserId,Name,DateOfBirth,Email,Password,IsActive,Vote,BlogCount,PostCount,CreatedAt,UpdatedAt) values(@UserId,@Name,@DateOfBirth,@Email,@Password,@IsActive,@Vote,@BlogCount,@PostCount,@CreatedAt,@UpdatedAt)";
            SqlCommand sqlCommand = command;
            //sqlCommand.CommandText = query;
            sqlCommand.Connection = connection;
            /*sqlCommand.Parameters.AddWithValue("@UserId", "ifti@test.com");
            sqlCommand.Parameters.AddWithValue("@Name", "ifti@test.com");
            sqlCommand.Parameters.AddWithValue("@DateOfBirth", DateTime.Now);
            sqlCommand.Parameters.AddWithValue("@Email", "ifti@test.com");
            sqlCommand.Parameters.AddWithValue("@Password", "ifti@test.com");
            sqlCommand.Parameters.AddWithValue("@IsActive", false);
            sqlCommand.Parameters.AddWithValue("@Vote", 0);
            sqlCommand.Parameters.AddWithValue("@BlogCount", 0);
            sqlCommand.Parameters.AddWithValue("@PostCount", 0);
            sqlCommand.Parameters.AddWithValue("@CreatedAt", DateTime.Now);
            sqlCommand.Parameters.AddWithValue("@UpdatedAt", DateTime.Now);*/
            try
            {
                connection.Open();
                //IsQuerySuccess = await command.ExecuteNonQueryAsync();
                await sqlCommand.ExecuteNonQueryAsync();
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
