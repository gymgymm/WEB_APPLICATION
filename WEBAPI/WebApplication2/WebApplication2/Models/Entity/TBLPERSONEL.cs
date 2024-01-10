using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models.Entity
{
    public class TBLPERSONEL
    {
        public byte ID { get; set; }
        public string PERSONEL { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBLHAREKET> TBLHAREKET { get; set; }
    }
}