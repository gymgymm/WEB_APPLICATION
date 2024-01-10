using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models.Entity
{
    public class TBLMESAJLAR
    {
        public int ID { get; set; }
        public string GONDEREN { get; set; }
        public string ALICI { get; set; }
        public string KONU { get; set; }
        public string ICERIK { get; set; }
        public Nullable<System.DateTime> TARIH { get; set; }
    }
}