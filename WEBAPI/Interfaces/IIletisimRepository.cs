using WebApplication1.Entities;

namespace WebApplication1.Interfaces
{
    public interface IIletisimRepository
    {
        public void CreateIleisim(Iletisim iletisim);
        public IEnumerable<Iletisim> GetIletisim();
    }
}
