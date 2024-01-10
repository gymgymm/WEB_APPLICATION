using WebApplication1.Entities;

namespace WebApplication1.Interfaces
{
    public interface IKitapRepository
    {
        public IEnumerable<Kitap> GetKitaplar(string p );
        public IEnumerable<Kitap> GetKitaplar();
        public IEnumerable<Kitap> GetKitaplarTure();
        public void CreateKitap(Kitap kitap);
        public void DeleteKitap(int kitapId);
        public Kitap GetKitapId(int id);
        public void UpdateKitap(int kitapId, Kitap company);
        public IEnumerable<Kitap> GetKitaplarFalse();
    }
}
