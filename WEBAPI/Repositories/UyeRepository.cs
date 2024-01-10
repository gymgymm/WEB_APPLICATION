using Dapper;
using System.Data;
using WebApplication1.Entities;
using WebApplication1.Helpers;
using WebApplication1.Interfaces;

namespace WebApplication1.Repositories
{
    public class UyeRepository : IUyelerRepository
    {
        private readonly ConnectionHelper _connectionHelper;
        public UyeRepository(ConnectionHelper connectionHelper)
        {
            _connectionHelper = connectionHelper;
        }

        public void CreateUye(UyelerDTO uye)
        {
            var query = "INSERT INTO TBLUYELER (AD, SOYAD, MAIL, KULLANICIADI, SIFRE, FOTOGRAF, TELEFON, OKUL)" +
                 "VALUES(@AD, @SOYAD, @MAIL, @KULLANICIADI, @SIFRE, @FOTOGRAF, @TELEFON, @OKUL)";
            var parameters = new DynamicParameters();

            parameters.Add("AD",uye.AD,DbType.String);
            parameters.Add("SOYAD",uye.SOYAD,DbType.String);
            parameters.Add("MAIL",uye.MAIL,DbType.String);
            parameters.Add("KULLANICIADI",uye.KULLANICIADI,DbType.String);
            parameters.Add("SIFRE",uye.SIFRE,DbType.String);
            parameters.Add("FOTOGRAF",uye.FOTOGRAF,DbType.String);
            parameters.Add("TELEFON",uye.TELEFON,DbType.String);
            parameters.Add("OKUL",uye.OKUL,DbType.String);
            using var connection = _connectionHelper.CreateSqlConnection();
            connection.Execute(query,parameters);
        }

        public void DeleteUye(int uyeId)
        {
            var query = "DELETE  FROM TBLUYELER WHERE ID=@ID";
            using var connection = _connectionHelper.CreateSqlConnection();
            connection.Execute(query, new { ID=uyeId });
        }

        public Uyeler GetUyeId(int id)
        {
            var query = "SELECT * FROM TBLUYELER WHERE ID=@ID";
            using var connection = _connectionHelper.CreateSqlConnection();
            var uyeler = connection.QueryFirst<Uyeler>(query, new { ID = id });
            return uyeler;

        }

        public IEnumerable<Uyeler> GetUyeler()
        {
            var query = "SELECT * FROM TBLUYELER";
            using var connection = _connectionHelper.CreateSqlConnection();
            var uyeler = connection.Query<Uyeler>(query);
            return uyeler.ToList();
        }

        public void UpdateUye(int uyeId, UyelerDTO uye)
        {
            var query = "UPDATE  TBLUYELER SET AD=@AD, SOYAD=@SOYAD, MAIL=@MAIL, KULLANICIADI=@KULLANICIADI, SIFRE=@SIFRE, FOTOGRAF=@FOTOGRAF, TELEFON=@TELEFON, OKUL=@OKUL" +
                 " WHERE ID=@ID";
            var parameters = new DynamicParameters();

            parameters.Add("ID",uyeId , DbType.Int32);
            parameters.Add("AD",uye.AD , DbType.String);
            parameters.Add("SOYAD", uye.SOYAD, DbType.String);
            parameters.Add("MAIL", uye.MAIL, DbType.String);
            parameters.Add("KULLANICIADI", uye.KULLANICIADI, DbType.String);
            parameters.Add("SIFRE", uye.SIFRE, DbType.String);
            parameters.Add("FOTOGRAF", uye.FOTOGRAF, DbType.String);
            parameters.Add("TELEFON", uye.TELEFON, DbType.String);
            parameters.Add("OKUL", uye.OKUL, DbType.String);
            using var connection = _connectionHelper.CreateSqlConnection();
            connection.Execute(query, parameters);
        }

        public string UyeAd(int uyeId)
        {
            var query = "SELECT AD, SOYAD FROM TBLUYELER WHERE ID = @ID";
            using var connection = _connectionHelper.CreateSqlConnection();
            var result = connection.QueryFirstOrDefault<dynamic>(query, new { Id = uyeId });
            string adSoyad = $"{result.AD} {result.SOYAD}";
            return adSoyad;
        }

        public Uyeler UyeGetirMail(string mail)
        {
            var query = "SELECT * FROM TBLUYELER WHERE MAIL = @MAIL";
            using var connection = _connectionHelper.CreateSqlConnection();
            var uye = connection.QueryFirstOrDefault<Uyeler>(query, new { MAIL = mail });
            return uye;
        }

        public Uyeler UyeGiris(Uyeler uye)
        {
            var query = "SELECT TOP 1 * FROM TBLUYELER WHERE MAIL = @Mail AND SIFRE = @Sifre";
            using var connection = _connectionHelper.CreateSqlConnection();
            var uyeler = connection.QueryFirstOrDefault<Uyeler>(query, new { Mail = uye.MAIL, Sifre = uye.SIFRE });
            
            return uyeler;
        }
    }
}
