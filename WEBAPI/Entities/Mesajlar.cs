namespace WebApplication1.Entities
{
    public class Mesajlar
    {
        public int ID { get; set; }
        public string GONDEREN { get; set; }
        public string ALICI { get; set; }
        public string KONU { get; set; }
        public string ICERIK { get; set; }
        public Nullable<System.DateTime> TARIH { get; set; }
    }
}
