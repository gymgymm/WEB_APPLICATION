using Dapper;
using WebApplication1.Entities;
using WebApplication1.Helpers;
using WebApplication1.Interfaces;

namespace WebApplication1.Repositories
{
    public class HakkımızdaRepository : IHakkımızdaRepository
    {
        private readonly ConnectionHelper _connectionHelper;
        public HakkımızdaRepository(ConnectionHelper connectionHelper)
        {
            _connectionHelper = connectionHelper;
        }
        public IEnumerable<Hakkımızda> GetHakkımızda()
        {
            var query = "SELECT * FROM TBLHAKKIMIZDA";
            using var connection = _connectionHelper.CreateSqlConnection();
            var hakkımızda = connection.Query<Hakkımızda>(query);
            return hakkımızda.ToList();
        }
    }
}
