using WebApplication1.Entities;

namespace WebApplication1.Interfaces
{
    public interface ICezalarRepository
    {
        public IEnumerable<Cezalar> GetCezalar();

    }
}
