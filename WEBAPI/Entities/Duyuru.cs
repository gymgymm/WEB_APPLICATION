namespace WebApplication1.Entities
{
    public class Duyuru
    {
        public byte ID { get; set; }
        public string KATEGORI { get; set; }
        public string ICERIK { get; set; }
        public Nullable<System.DateTime> TARIH { get; set; }
    }
}
