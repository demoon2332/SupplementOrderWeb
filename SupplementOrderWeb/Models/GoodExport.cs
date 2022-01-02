namespace SupplementOrderWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GoodExport")]
    public partial class GoodExport
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GoodExport()
        {
            ExportDetails = new HashSet<ExportDetail>();
        }

        public long id { get; set; }

        public long? cid { get; set; }

        public long? sid { get; set; }

        [Required]
        [StringLength(22)]
        public string paymentType { get; set; }

        public bool? statusPayment { get; set; }

        [StringLength(10)]
        public string statusDelivery { get; set; }

        [StringLength(22)]
        public string exportDate { get; set; }

        public virtual Customer Customer { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ExportDetail> ExportDetails { get; set; }
    }
}
