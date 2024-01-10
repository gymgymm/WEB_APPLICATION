using Dapper;
using WebApplication1.Entities;
using WebApplication1.Helpers;
using WebApplication1.Interfaces;

namespace WebApplication1.Repositories
{
    public class CezalarRepository : ICezalarRepository
    {
        private readonly ConnectionHelper _connectionHelper;
        public CezalarRepository(ConnectionHelper connectionHelper)
        {
            _connectionHelper = connectionHelper;
        }
        public IEnumerable<Cezalar> GetCezalar()
        {
            var query = "SELECT * FROM TBLCEZALAR";
            using var connection = _connectionHelper.CreateSqlConnection();
            var cezalar = connection.Query<Cezalar>(query);
            return cezalar.ToList();
        }
    }
}
