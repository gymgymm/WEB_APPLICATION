using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models.Entity
{
    public class TBLCEZALAR
    {
        public int ID { get; set; }
        public Nullable<int> UYE { get; set; }
        public Nullable<System.DateTime> BASLANGIC { get; set; }
        public Nullable<System.DateTime> BITIS { get; set; }
        public Nullable<decimal> PARA { get; set; }
        public Nullable<int> HAREKET { get; set; }

        public virtual TBLHAREKET TBLHAREKET { get; set; }
        public virtual TBLUYELER TBLUYELER { get; set; }

    }
}