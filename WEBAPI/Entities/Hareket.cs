namespace WebApplication1.Entities
{
    public class Hareket
    {
        public int ID { get; set; }
        public Nullable<int> KITAP { get; set; }
        public Nullable<int> UYE { get; set; }
        public Nullable<byte> PERSONEL { get; set; }
        public Nullable<System.DateTime> ALISTARIHI { get; set; }
        public Nullable<System.DateTime> IADETARIHI { get; set; }
        public Nullable<System.DateTime> UYEGETIRTARIH { get; set; }
        public Nullable<bool> ISLEMDURUM { get; set; }
    }
}
