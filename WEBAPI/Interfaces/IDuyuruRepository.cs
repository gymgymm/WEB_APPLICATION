using WebApplication1.Entities;

namespace WebApplication1.Interfaces
{
    public interface IDuyuruRepository
    {
        public IEnumerable<Duyuru> GetDuyurular();
        public void CreateDuyuru(Duyuru duyuru);
        public void DeleteDuyuru(int duyuruId);
        public Duyuru GetDuyuruId(int id);
        public void UpdateDuyuru(int DuyuruId, Duyuru duyuru);
        public IEnumerable<Hareket> DuyuruIslem();
    }
}
