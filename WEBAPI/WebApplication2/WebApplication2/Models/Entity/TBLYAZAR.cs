using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models.Entity
{
    public class TBLYAZAR
    {
        public int ID { get; set; }
        public string AD { get; set; }
        public string SOYAD { get; set; }
        public string DETAY { get; set; }
        public virtual ICollection<TBLKITAP> TBLKITAP { get; set; }
    }
}