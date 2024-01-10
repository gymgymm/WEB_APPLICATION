using WebApplication1.Entities;

namespace WebApplication1.Interfaces
{
    public interface IHareket
    {
        public IEnumerable<Hareket> HareketGecmis(int ıd);
        public IEnumerable<Hareket> GetHareketler();
        public IEnumerable<Hareket> GetUyeHareketler(int id);
        public void CreateHareket(Hareket hareket);
        public Hareket GetHareketId(int id);
        public void UpdateHareket(int hareketId, Hareket hareket);
    }
}
