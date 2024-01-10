using WebApplication1.Entities;

namespace WebApplication1.Interfaces
{
    public interface IUyelerRepository
    {
        public IEnumerable<Uyeler> GetUyeler();
        public Uyeler GetUyeId(int id);
        public void CreateUye(UyelerDTO uye);
        public void UpdateUye(int uyeId, UyelerDTO company);
        public void DeleteUye(int uyeId);
        public string UyeAd(int uyeId);
        public Uyeler UyeGiris(Uyeler uye);
        public Uyeler UyeGetirMail(string mail);
        
    }
}
