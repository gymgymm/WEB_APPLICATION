using Dapper;
using System.Data;
using WebApplication1.Entities;
using WebApplication1.Helpers;
using WebApplication1.Interfaces;

namespace WebApplication1.Repositories
{
    public class DuyuruRepository : IDuyuruRepository
    {
        private readonly ConnectionHelper _connectionHelper;
        public DuyuruRepository(ConnectionHelper connectionHelper)
        {
            _connectionHelper = connectionHelper;
        }

        public void CreateDuyuru(Duyuru duyuru)
        {
           
                var query = "INSERT INTO TBLDUYURULAR (KATEGORI,ICERIK,TARIH)" +
                     "VALUES(@KATEGORI, @ICERIK, @TARIH)";
                var parameters = new DynamicParameters();

                parameters.Add("KATEGORI", duyuru.KATEGORI, DbType.String);
                parameters.Add("ICERIK", duyuru.ICERIK, DbType.String);
                parameters.Add("TARIH", duyuru.TARIH, DbType.DateTime);
                using var connection = _connectionHelper.CreateSqlConnection();
                connection.Execute(query, parameters);
            
        }

        public void DeleteDuyuru(int duyuruId)
        {
            
                var query = "DELETE  FROM TBLDUYURULAR WHERE ID=@ID";
                using var connection = _connectionHelper.CreateSqlConnection();
                connection.Execute(query, new { ID = duyuruId });
            
        }

        public IEnumerable<Hareket> DuyuruIslem()
        {
           

                var query = "SELECT * FROM TBLHAREKET WHERE ISLEMDURUM = 1";
                using var connection = _connectionHelper.CreateSqlConnection();
                var duyuru = connection.Query<Hareket>(query);
                return duyuru.ToList();

            

        }

        public Duyuru GetDuyuruId(int id)
        {
            
                var query = "SELECT * FROM TBLDUYURULAR WHERE ID=@ID";
                using var connection = _connectionHelper.CreateSqlConnection();
                var duyuru = connection.QueryFirst<Duyuru>(query, new { ID = id });
                return duyuru;

            
        }

        public IEnumerable<Duyuru> GetDuyurular()
        {
            
                var query = "SELECT * FROM TBLDUYURULAR";
                using var connection = _connectionHelper.CreateSqlConnection();
                var uyeler = connection.Query<Duyuru>(query);
                return uyeler.ToList();
            
        }

        public void UpdateDuyuru(int DuyuruId, Duyuru duyuru)
        {
           
                var query = "UPDATE  TBLDUYURULAR SET KATEGORI=@KATEGORI, ICERIK=@ICERIK,TARIH=@TARIH" +
                     " WHERE ID=@ID";
                var parameters = new DynamicParameters();

                parameters.Add("ID", DuyuruId, DbType.Int32);
                parameters.Add("KATEGORI", duyuru.KATEGORI, DbType.String);
                parameters.Add("ICERIK", duyuru.ICERIK, DbType.String);
                parameters.Add("TARIH", duyuru.TARIH, DbType.DateTime);
                
                using var connection = _connectionHelper.CreateSqlConnection();
                connection.Execute(query, parameters);
            
        }
    }
}
