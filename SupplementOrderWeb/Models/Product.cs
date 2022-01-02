namespace SupplementOrderWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            ExportDetails = new HashSet<ExportDetail>();
        }
        [Required]
        public long id { get; set; }

        [Required]
        [StringLength(100)]
        public string name { get; set; }


        [StringLength(50)]
        public string unit { get; set; }

        public double price { get; set; }

        public byte? type { get; set; }

        public int? inventory { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ExportDetail> ExportDetails { get; set; }

        public virtual Type Type1 { get; set; }
    }

}
