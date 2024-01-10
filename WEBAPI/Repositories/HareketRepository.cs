using Dapper;
using System.Data;
using WebApplication1.Entities;
using WebApplication1.Helpers;
using WebApplication1.Interfaces;

namespace WebApplication1.Repositories
{
    public class HareketRepository : IHareket
    {
        private readonly ConnectionHelper _connectionHelper;
        public HareketRepository(ConnectionHelper connectionHelper)
        {
            _connectionHelper = connectionHelper;
        }

        public void CreateHareket(Hareket hareket)
        {
            var query = "INSERT INTO TBLHAREKET (KITAP, UYE, PERSONEL, ALISTARIHI, IADETARIHI, UYEGETIRTARIH, ISLEMDURUM)" +
                "VALUES(@KITAP, @UYE, @PERSONEL, @ALISTARIHI, @IADETARIHI, @UYEGETIRTARIH, @ISLEMDURUM)";
            var parameters = new DynamicParameters();

            parameters.Add("KITAP", hareket.KITAP, DbType.Int32);
            parameters.Add("UYE", hareket.UYE, DbType.Int32);
            parameters.Add("PERSONEL", hareket.PERSONEL, DbType.Byte);
            parameters.Add("ALISTARIHI", hareket.ALISTARIHI, DbType.DateTime);
            parameters.Add("IADETARIHI", hareket.IADETARIHI, DbType.DateTime);
            parameters.Add("UYEGETIRTARIH", hareket.UYEGETIRTARIH, DbType.DateTime);
            parameters.Add("ISLEMDURUM", hareket.ISLEMDURUM, DbType.Boolean);
            using var connection = _connectionHelper.CreateSqlConnection();
            connection.Execute(query, parameters);
        }

        public Hareket GetHareketId(int id)
        {
            var query = "SELECT * FROM TBLHAREKET WHERE ID=@ID";
            using var connection = _connectionHelper.CreateSqlConnection();
            var hareket = connection.QueryFirst<Hareket>(query, new { ID = id });
            return hareket;
        }

        public IEnumerable<Hareket> GetHareketler()
        {
            var query = "SELECT * FROM TBLHAREKET WHERE ISLEMDURUM = 0";
            using var connection = _connectionHelper.CreateSqlConnection();
            var uyeler = connection.Query<Hareket>(query);
            return uyeler.ToList();
        }

        public IEnumerable<Hareket> GetUyeHareketler(int id)
        {
            var query = "SELECT * FROM TBLHAREKET WHERE UYE = @ID";
            using var connection = _connectionHelper.CreateSqlConnection();
            var hareketler = connection.Query<Hareket>(query, new { ID = id });
            return hareketler.ToList();
        }

        public IEnumerable<Hareket> HareketGecmis(int ıd)
        {
            var query = "SELECT * FROM TBLHAREKET WHERE UYE = @ID";
            using var connection = _connectionHelper.CreateSqlConnection();
            var hareket = connection.Query<Hareket>(query, new { ID = ıd });

            return hareket.ToList();
        }

        public void UpdateHareket(int hareketId, Hareket hareket)
        {
            var query = "UPDATE  TBLHAREKET SET KITAP=@KITAP, UYE=@UYE, PERSONEL=@PERSONEL, ALISTARIHI=@ALISTARIHI, IADETARIHI=@IADETARIHI, UYEGETIRTARIH=@UYEGETIRTARIH, ISLEMDURUM=@ISLEMDURUM" +
                 " WHERE ID=@ID";
            var parameters = new DynamicParameters();

            parameters.Add("ID", hareketId, DbType.Int32);
            parameters.Add("KITAP", hareket.KITAP, DbType.Int32);
            parameters.Add("UYE", hareket.UYE, DbType.Int32);
            parameters.Add("PERSONEL", hareket.PERSONEL, DbType.Byte);
            parameters.Add("ALISTARIHI", hareket.ALISTARIHI, DbType.DateTime);
            parameters.Add("IADETARIHI", hareket.IADETARIHI, DbType.DateTime);
            parameters.Add("UYEGETIRTARIH", hareket.UYEGETIRTARIH, DbType.DateTime);
            parameters.Add("ISLEMDURUM", hareket.ISLEMDURUM, DbType.Boolean);
            using var connection = _connectionHelper.CreateSqlConnection();
            connection.Execute(query, parameters);
        }
    }
}
