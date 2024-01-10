using Dapper;
using WebApplication1.Entities;
using WebApplication1.Helpers;
using WebApplication1.Interfaces;

namespace WebApplication1.Repositories
{
    public class ProsedurRepository : IProsedurRepository
    {
        private readonly ConnectionHelper _connectionHelper;
        public ProsedurRepository(ConnectionHelper connectionHelper)
        {
            _connectionHelper = connectionHelper;
        }
        public Prosedür GetProsedur()
        {
            using var connection = _connectionHelper.CreateSqlConnection();
            connection.Open(); // Bağlantıyı aç

            var aktif = connection.Query<string>("EXEC EnAktifKisi;").FirstOrDefault();
            var kitap = connection.Query<string>("EXEC EnCokOkunanKitap;").FirstOrDefault();
            var yazar = connection.Query<string>("EXEC EnFazlaKitapYazarı;").FirstOrDefault();
            var personel = connection.Query<string>("EXEC EnAktifPersonel;").FirstOrDefault();
            var yayınevi = connection.Query<string>("EXEC EnİyiYayınEvi;").FirstOrDefault();
            var emanet = connection.Query<string>("EXEC BugununEmanetleri;").FirstOrDefault();

            // Prosedür sınıfınızın her bir özelliğini doldurun
            Prosedür p = new Prosedür
            {
                EnAktifKisi = aktif,
                EnCokOkunanKitap = kitap,
                EnFazlaKitapYazarı = yazar,
                EnAktifPersonel = personel,
                EnİyiYayınEvi = yayınevi,
                BugununEmanetleri = emanet
            };

            return p;
        }
    }
}
