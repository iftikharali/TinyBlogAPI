using System.Data.Common;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace TinyBlog.DAL.Helpers.Interfaces
{
    public interface IDALHelper
    {
        SqlCommand GetCommand(string commandText);
        Task<DbDataReader> ExecuteReaderAsync(SqlCommand command);
        Task<int> ExecuteNonQueryAsync(SqlCommand command);
    }
}
