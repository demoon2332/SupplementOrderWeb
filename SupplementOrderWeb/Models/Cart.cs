using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SupplementOrderWeb.Models
{
    
    public partial class Cart
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cart()
        {
            
        }

        public long bid { get; set; }

        public string name { get; set; }

        public string unit { get; set; }

        public double price { get; set; }

        public int quantity { get; set; }

        public double intoMoney { get; set; }
    }
}