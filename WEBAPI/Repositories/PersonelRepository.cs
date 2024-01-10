using Dapper;
using System.Data;
using WebApplication1.Entities;
using WebApplication1.Helpers;
using WebApplication1.Interfaces;

namespace WebApplication1.Repositories
{
    public class PersonelRepository:IPersonelRepository
    {
        private readonly ConnectionHelper _connectionHelper;
        public PersonelRepository(ConnectionHelper connectionHelper)
        {
            _connectionHelper = connectionHelper;
        }

        public void CreatPersonel(Personel personel)
        {
            var query = "INSERT INTO TBLPERSONEL (PERSONEL)" +
                "VALUES(@PERSONEL)";
            var parameters = new DynamicParameters();

            parameters.Add("PERSONEL", personel.PERSONEL, DbType.String);
           
            using var connection = _connectionHelper.CreateSqlConnection();
            connection.Execute(query, parameters);
        }

        public void DeletePersonel(int personelId)
        {
            var query2 = "ALTER TABLE dbo.TBLHAREKET DROP CONSTRAINT FK_TBLHAREKET_TBLPERSONEL;";
            var query1 = "ALTER TABLE dbo.TBLHAREKET\r\nADD CONSTRAINT FK_TBLHAREKET_TBLPERSONEL\r\nFOREIGN KEY (PERSONEL) REFERENCES dbo.TBLPERSONEL(ID)\r\nON DELETE CASCADE;";
            var query = "DELETE  FROM TBLPERSONEL WHERE ID=@ID";
            using var connection = _connectionHelper.CreateSqlConnection();
            connection.Execute(query2);
            connection.Execute(query1);
            connection.Execute(query, new { ID = personelId });
        }

        public Personel GetPersonelId(int id)
        {
            var query = "SELECT * FROM TBLPERSONEL WHERE ID=@ID";
            using var connection = _connectionHelper.CreateSqlConnection();
            var personel = connection.QueryFirst<Personel>(query, new { ID = id });
            return personel;
        }

        public IEnumerable<Personel> GetPersoneller()
        {
            var query = "SELECT * FROM TBLPERSONEL";
            using var connection = _connectionHelper.CreateSqlConnection();
            var personel = connection.Query<Personel>(query);
            return personel.ToList();
        }

        public void UpdatePersonel(int personelId, Personel personel)
        {
            var query = "UPDATE  TBLPERSONEL SET PERSONEL=@PERSONEL" +
                 " WHERE ID=@ID";
            var parameters = new DynamicParameters();

            parameters.Add("ID", personelId, DbType.Int32);
            parameters.Add("PERSONEL", personel.PERSONEL, DbType.String);
            
            using var connection = _connectionHelper.CreateSqlConnection();
            connection.Execute(query, parameters);
        }
    }
}
