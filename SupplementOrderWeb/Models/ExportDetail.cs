namespace SupplementOrderWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ExportDetail")]
    public partial class ExportDetail
    {
        public long id { get; set; }

        public long bid { get; set; }

        public long pid { get; set; }

        public int quantity { get; set; }

        public virtual GoodExport GoodExport { get; set; }

        public virtual Product Product { get; set; }
    }
}
