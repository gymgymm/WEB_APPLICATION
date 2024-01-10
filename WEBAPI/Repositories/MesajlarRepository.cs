using Dapper;
using System.Data;
using WebApplication1.Entities;
using WebApplication1.Helpers;
using WebApplication1.Interfaces;

namespace WebApplication1.Repositories
{
    public class MesajlarRepository : IMesajlarRepository
    {
        private readonly ConnectionHelper _connectionHelper;
        public MesajlarRepository(ConnectionHelper connectionHelper)
        {
            _connectionHelper = connectionHelper;
        }

        public void CreateMesaj(Mesajlar mesaj)
        {
            
                var query = "INSERT INTO TBLMESAJLAR (GONDEREN, ALICI, KONU, ICERIK, TARIH)" +
                     "VALUES(@GONDEREN, @ALICI, @KONU, @ICERIK, @TARIH)";
                var parameters = new DynamicParameters();

                parameters.Add("GONDEREN", mesaj.GONDEREN, DbType.String);
                parameters.Add("ALICI", mesaj.ALICI, DbType.String);
                parameters.Add("KONU", mesaj.KONU, DbType.String);
                parameters.Add("ICERIK", mesaj.ICERIK, DbType.String);
                parameters.Add("TARIH", mesaj.TARIH, DbType.DateTime);
                using var connection = _connectionHelper.CreateSqlConnection();
                connection.Execute(query, parameters);
            
        }

        public IEnumerable<Mesajlar> GetMesajlar(string mail)
        {
            var query = "SELECT * FROM TBLMESAJLAR WHERE ALICI=@ALICI";
            using var connection = _connectionHelper.CreateSqlConnection();
            var mesajlar = connection.Query<Mesajlar>(query, new { ALICI = mail });
            return mesajlar.ToList();
        }

        public IEnumerable<Mesajlar> GetMesajlargönderici(string mail)
        {
            var query = "SELECT * FROM TBLMESAJLAR WHERE GONDEREN=@GONDEREN";
            using var connection = _connectionHelper.CreateSqlConnection();
            var mesajlar = connection.Query<Mesajlar>(query, new { GONDEREN = mail });
            return mesajlar.ToList();
        }
    }
}
