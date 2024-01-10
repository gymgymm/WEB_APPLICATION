using WebApplication1.Entities;

namespace WebApplication1.Interfaces
{
    public interface IYazarRepository
    {
        public IEnumerable<Yazar> GetYazarlar();
        public void CreateYazar(Yazar yazar);
        public void DeleteYazar(int yazarId);
        public Yazar GetYazarId(int id);
        public void UpdateYazar(int yazarId, Yazar yazar);
        public IEnumerable<Kitap> GetYazarKitap(int id);
    }
}
