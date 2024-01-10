using Dapper;
using System.Data;
using WebApplication1.Entities;
using WebApplication1.Helpers;
using WebApplication1.Interfaces;

namespace WebApplication1.Repositories
{
    public class YazarRepository : IYazarRepository
    {

        private readonly ConnectionHelper _connectionHelper;
        public YazarRepository(ConnectionHelper connectionHelper)
        {
            _connectionHelper = connectionHelper;
        }
        public void CreateYazar(Yazar yazar)
        {
            var query = "INSERT INTO TBLYAZAR (AD, SOYAD, DETAY)" +
                "VALUES(@AD, @SOYAD, @DETAY)";
            var parameters = new DynamicParameters();

            parameters.Add("AD", yazar.AD, DbType.String);
            parameters.Add("SOYAD", yazar.SOYAD, DbType.String);
            parameters.Add("DETAY", yazar.DETAY, DbType.String);
            using var connection = _connectionHelper.CreateSqlConnection();
            connection.Execute(query, parameters); ;
        }

        public void DeleteYazar(int yazarId)
        {
            var query = "DELETE  FROM TBLYAZAR WHERE ID=@ID";
            using var connection = _connectionHelper.CreateSqlConnection();
            connection.Execute(query, new { ID = yazarId });
        }

        public Yazar GetYazarId(int id)
        {
            var query = "SELECT * FROM TBLYAZAR WHERE ID=@ID";
            using var connection = _connectionHelper.CreateSqlConnection();
            var yazar = connection.QueryFirst<Yazar>(query, new { ID = id });
            return yazar;
        }

        public IEnumerable<Kitap> GetYazarKitap(int id)
        {
            var query = "SELECT * FROM TBLKITAP WHERE YAZAR=@ID";
            using var connection = _connectionHelper.CreateSqlConnection();
            var kitap = connection.Query<Kitap>(query, new {ID=id} );
            return kitap.ToList();
        }

        public IEnumerable<Yazar> GetYazarlar()
        {
            var query = "SELECT * FROM TBLYAZAR";
            using var connection = _connectionHelper.CreateSqlConnection();
            var yazar = connection.Query<Yazar>(query);
            return yazar.ToList();
        }

        public void UpdateYazar(int yazarId, Yazar yazar)
        {
            var query = "UPDATE  TBLYAZAR SET AD=@AD, SOYAD=@SOYAD, DETAY=@DETAY" +
                " WHERE ID=@ID";
            var parameters = new DynamicParameters();

            parameters.Add("ID", yazarId, DbType.Int32);
            parameters.Add("AD", yazar.AD, DbType.String);
            parameters.Add("SOYAD", yazar.SOYAD, DbType.String);
            parameters.Add("DETAY", yazar.DETAY, DbType.String);
            using var connection = _connectionHelper.CreateSqlConnection();
            connection.Execute(query, parameters);
        }
    }
}
