using Entity;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class TestContext: DbContext
    {
        public TestContext(DbContextOptions options) : base (options) {}

        public DbSet<Product> Products { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceDetail> InvoiceDetails { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InvoiceDetail>()
            .HasOne<Product>().WithMany()
            .HasForeignKey(d => d.IdProduct);

            modelBuilder.Entity<Invoice>()
            .HasOne<Client>().WithMany()
            .HasForeignKey(i => i.IdClient);
        }

    }
}