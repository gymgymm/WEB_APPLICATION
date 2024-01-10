using Dapper;
using System.Data;
using WebApplication1.Entities;
using WebApplication1.Helpers;
using WebApplication1.Interfaces;

namespace WebApplication1.Repositories
{
    public class IletisimRepository:IIletisimRepository
    {
        private readonly ConnectionHelper _connectionHelper;
        public IletisimRepository(ConnectionHelper connectionHelper)
        {
            _connectionHelper = connectionHelper;
        }

        public void CreateIleisim(Iletisim iletisim)
        {
            var query = "INSERT INTO TBLILETISIM (AD, MAIL, KONU, MESAJ)" +
                 "VALUES(@AD, @MAIL, @KONU, @MESAJ)";
            var parameters = new DynamicParameters();

            parameters.Add("AD", iletisim.AD, DbType.String);
            parameters.Add("MAIL", iletisim.MAIL, DbType.String);
            parameters.Add("KONU", iletisim.KONU, DbType.String);
            parameters.Add("MESAJ", iletisim.MESAJ, DbType.String);
            using var connection = _connectionHelper.CreateSqlConnection();
            connection.Execute(query, parameters);
        }

        public IEnumerable<Iletisim> GetIletisim()
        {
            var query = "SELECT * FROM TBLILETISIM";
            using var connection = _connectionHelper.CreateSqlConnection();
            var iletisim = connection.Query<Iletisim>(query);
            return iletisim.ToList();
        }
    }
}
