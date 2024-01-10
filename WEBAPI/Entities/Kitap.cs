namespace WebApplication1.Entities
{
    public class Kitap
    {
        public int ID { get; set; }
        public string AD { get; set; }
        public Nullable<byte> KATEGORI { get; set; }
        public Nullable<int> YAZAR { get; set; }
        public string BASIMYILI { get; set; }
        public string YAYINEVI { get; set; }
        public string SAYFA { get; set; }
        public Nullable<bool> DURUM { get; set; }
        public string KITAPRESIM { get; set; }

    }
}
