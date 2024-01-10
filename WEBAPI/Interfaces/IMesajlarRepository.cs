using WebApplication1.Entities;

namespace WebApplication1.Interfaces
{
    public interface IMesajlarRepository
    {
        public IEnumerable<Mesajlar> GetMesajlar(string mail);
        public IEnumerable<Mesajlar> GetMesajlargönderici(string mail);
        public void CreateMesaj(Mesajlar mesaj);
    }
}
