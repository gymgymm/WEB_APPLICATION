using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models.Entity
{
    public class TBLDUYURULAR
    {
        public byte ID { get; set; }
        public string KATEGORI { get; set; }
        public string ICERIK { get; set; }
        public Nullable<System.DateTime> TARIH { get; set; }
    }
}