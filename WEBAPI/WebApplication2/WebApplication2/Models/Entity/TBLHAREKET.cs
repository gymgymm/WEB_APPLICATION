using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models.Entity
{
    public class TBLHAREKET
    {
        public int ID { get; set; }
        public Nullable<int> KITAP { get; set; }
        public Nullable<int> UYE { get; set; }
        public Nullable<byte> PERSONEL { get; set; }
        public Nullable<System.DateTime> ALISTARIHI { get; set; }
        public Nullable<System.DateTime> IADETARIHI { get; set; }
        public Nullable<System.DateTime> UYEGETIRTARIH { get; set; }
        public Nullable<bool> ISLEMDURUM { get; set; }
        public virtual ICollection<TBLCEZALAR> TBLCEZALAR { get; set; }
        public virtual TBLKITAP TBLKITAP { get; set; }
        public virtual TBLUYELER TBLUYELER { get; set; }
        public virtual TBLPERSONEL TBLPERSONEL { get; set; }
    }
}