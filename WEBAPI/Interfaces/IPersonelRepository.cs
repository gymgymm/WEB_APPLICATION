using WebApplication1.Entities;

namespace WebApplication1.Interfaces
{
    public interface IPersonelRepository
    {
        public IEnumerable<Personel> GetPersoneller();
        public void CreatPersonel(Personel personel);
        public void DeletePersonel(int personelId);
        public Personel GetPersonelId(int id);
        public void UpdatePersonel(int personelId, Personel personel);
    }
}
