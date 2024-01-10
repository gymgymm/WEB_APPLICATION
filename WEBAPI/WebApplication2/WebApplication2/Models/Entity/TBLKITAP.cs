using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models.Entity
{
    public class TBLKITAP
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
        public virtual ICollection<TBLHAREKET> TBLHAREKET { get; set; }
        public virtual TBLKATEGORI TBLKATEGORI { get; set; }
        public virtual TBLYAZAR TBLYAZAR { get; set; }
    }
}