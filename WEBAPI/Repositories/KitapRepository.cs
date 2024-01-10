using Dapper;
using System.Data;
using WebApplication1.Entities;
using WebApplication1.Helpers;
using WebApplication1.Interfaces;

namespace WebApplication1.Repositories
{
    public class KitapRepository : IKitapRepository
    {
        private readonly ConnectionHelper _connectionHelper;
        public KitapRepository(ConnectionHelper connectionHelper)
        {
            _connectionHelper = connectionHelper;
        }

        public void CreateKitap(Kitap kitap)
        {
            var query = "INSERT INTO TBLKİTAP (AD, KATEGORI, YAZAR, BASIMYILI, YAYINEVI, SAYFA, DURUM, KITAPRESIM)" +
                 "VALUES(@AD, @KATEGORI, @YAZAR, @BASIMYILI, @YAYINEVI, @SAYFA, @DURUM, @KITAPRESIM)";
            var parameters = new DynamicParameters();

            parameters.Add("AD", kitap.AD, DbType.String);
            parameters.Add("KATEGORI", kitap.KATEGORI, DbType.Byte);
            parameters.Add("YAZAR", kitap.YAZAR, DbType.Int32);
            parameters.Add("BASIMYILI", kitap.BASIMYILI, DbType.String);
            parameters.Add("YAYINEVI", kitap.YAYINEVI, DbType.String);
            parameters.Add("SAYFA", kitap.SAYFA, DbType.String);
            parameters.Add("DURUM", kitap.DURUM, DbType.Boolean);
            parameters.Add("KITAPRESIM", kitap.KITAPRESIM, DbType.String);
            using var connection = _connectionHelper.CreateSqlConnection();
            connection.Execute(query, parameters);
        }

        public void DeleteKitap(int kitapId)
        {
            var query = "DELETE  FROM TBLKİTAP WHERE ID=@ID";
            using var connection = _connectionHelper.CreateSqlConnection();
            connection.Execute(query, new { ID = kitapId });
        }
        public Kitap GetKitapId(int id)
        {
            var query = "SELECT * FROM TBLKİTAP WHERE ID=@ID";
            using var connection = _connectionHelper.CreateSqlConnection();
            var uyeler = connection.QueryFirst<Kitap>(query, new { ID = id });
            return uyeler;
        }
        public IEnumerable<Kitap> GetKitaplar(string p)
        {
            var query = "SELECT * FROM TBLKİTAP as k WHERE (@p IS NULL OR AD LIKE '%' + @p + '%')";
            using var connection = _connectionHelper.CreateSqlConnection();
            var kitaplar = connection.Query<Kitap>(query, new { p = p });
            return kitaplar.ToList();
        }
        public IEnumerable<Kitap> GetKitaplar()
        {
                var query = "SELECT * FROM TBLKİTAP ";
                using var connection = _connectionHelper.CreateSqlConnection();
                var kitap = connection.Query<Kitap>(query);
                return kitap.ToList();
        }
        public IEnumerable<Kitap> GetKitaplarTure()
        {
            var query = "SELECT* FROM TBLKİTAP WHERE DURUM = 1 ";
            using var connection = _connectionHelper.CreateSqlConnection();
            var kitap = connection.Query<Kitap>(query);
            return kitap.ToList();
        }
        public IEnumerable<Kitap> GetKitaplarFalse()
        {
            var query = "SELECT* FROM TBLKİTAP WHERE DURUM = 0 ";
            using var connection = _connectionHelper.CreateSqlConnection();
            var kitap = connection.Query<Kitap>(query);
            return kitap.ToList();
        }

        public void UpdateKitap(int kitapId, Kitap company)
        {
            var query = "UPDATE TBLKİTAP SET AD = @AD, KATEGORI = @KATEGORI, YAZAR = @YAZAR, BASIMYILI = @BASIMYILI, " +
                        "YAYINEVI = @YAYINEVI, SAYFA = @SAYFA, DURUM = @DURUM, KITAPRESIM = @KITAPRESIM WHERE ID = @ID";

            var parameters = new DynamicParameters();

            parameters.Add("ID", kitapId, DbType.Int32);
            parameters.Add("AD", company.AD, DbType.String);
            parameters.Add("KATEGORI", company.KATEGORI, DbType.Byte); // Bu satırda DbType, KATEGORI'nin veri türüne bağlı olarak değişebilir.
            parameters.Add("YAZAR", company.YAZAR, DbType.Int32);
            parameters.Add("BASIMYILI", company.BASIMYILI, DbType.String);
            parameters.Add("YAYINEVI", company.YAYINEVI, DbType.String);
            parameters.Add("SAYFA", company.SAYFA, DbType.String);
            parameters.Add("DURUM", company.DURUM, DbType.Boolean);
            parameters.Add("KITAPRESIM", company.KITAPRESIM, DbType.String);

            using var connection = _connectionHelper.CreateSqlConnection();
            connection.Execute(query, parameters);
        }
    }
}
