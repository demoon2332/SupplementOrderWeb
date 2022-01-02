namespace SupplementOrderWeb.Models
{
    using SupplementOrderWeb.Controllers;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data;
    using System.Data.Entity.Spatial;
    using System.Data.SqlClient;
    using System.Linq;

    [Table("Customer")]
    public partial class Customer
    {
        private supplementOrderDBContext context;


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Customer()
        {
            context = new supplementOrderDBContext();
            GoodExports = new HashSet<GoodExport>();
        }

        public long id { get; set; }


        [StringLength(100)]
        public string fullName { get; set; }


        [StringLength(100)]
        public string address { get; set; }

        [Required]
        [StringLength(15)]
        public string phone { get; set; }

        [Required]
        [StringLength(1000)]
        public string password { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GoodExport> GoodExports { get; set; }

        public int Login(string phone,string password)
        {
            if(phone == null || password == null)
                return 0;
            DataTable res = DataProvider.Instance.ExecuteQuery("Exec customerLogin @phone , @password", new object[] { phone, password });
            return res.Rows.Count;
        }
    }
}
