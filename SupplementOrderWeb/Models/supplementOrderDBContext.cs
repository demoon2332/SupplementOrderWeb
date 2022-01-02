using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace SupplementOrderWeb.Models
{
    public partial class supplementOrderDBContext : DbContext
    {
        public supplementOrderDBContext()
            : base("name=supplementOrderDBContext")
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<ExportDetail> ExportDetails { get; set; }
        public virtual DbSet<GoodExport> GoodExports { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Type> Types { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .HasMany(e => e.GoodExports)
                .WithOptional(e => e.Customer)
                .HasForeignKey(e => e.cid);

            modelBuilder.Entity<GoodExport>()
                .Property(e => e.statusDelivery)
                .IsUnicode(false);

            modelBuilder.Entity<GoodExport>()
                .Property(e => e.exportDate)
                .IsUnicode(false);

            modelBuilder.Entity<GoodExport>()
                .HasMany(e => e.ExportDetails)
                .WithOptional(e => e.GoodExport)
                .HasForeignKey(e => e.bid);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.ExportDetails)
                .WithOptional(e => e.Product)
                .HasForeignKey(e => e.pid);

            modelBuilder.Entity<Type>()
                .HasMany(e => e.Products)
                .WithOptional(e => e.Type1)
                .HasForeignKey(e => e.type);
        }
    }
}
