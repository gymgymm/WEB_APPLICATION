using WebApplication1.Entities;

namespace WebApplication1.Interfaces
{
    public interface IKategoriRepository
    {
        public IEnumerable<Kategori> GetKategori();
        public Kategori GetKategoriId(int id);
        public void CreateKategori(Kategori kategori);
        public void DeleteKategori(int kategoriId);
        public void UpdateKategori(int kategoriId, Kategori kategori);
    }
}
