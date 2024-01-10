using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models.Entity
{
    public class TBLKATEGORI
    {
        public byte ID { get; set; }
        public string AD { get; set; }
        public Nullable<bool> DURUM { get; set; }
        public virtual ICollection<TBLKITAP> TBLKITAP { get; set; }
    }
}