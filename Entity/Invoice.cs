using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Entity
{
    public class Invoice
    {
        [Key]
        [Column(TypeName= "nvarchar(4)")]
        public string IdInvoice{ get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Subtotal { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalIva { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Total { get; set; }
        [Column(TypeName= "nvarchar(30)")]
        public string SaleDate { get; set; }
        [NotMapped]
        public string IdClient { get; set; }
        [Column(TypeName= "nvarchar(11)")]
        
        [ForeignKey("IdClient")]
        public virtual Client Client { get; set; }
        
        
        [Column(TypeName = "nvarchar(4)")]
        [ForeignKey("IdInvoice")]
        public virtual IList<InvoiceDetail> InvoiceDetails { get; set; } 

        public Invoice()
        {
            InvoiceDetails = new List<InvoiceDetail>();
        }

        public void AddInvoiceDetails(Product product, float quantity, float discount, decimal price)
        {
            InvoiceDetail invoiceDetail = new InvoiceDetail(product, quantity, discount, price);
            invoiceDetail.IdInvoice = this.IdInvoice;
            InvoiceDetails.Add(invoiceDetail);
        }

        public void CalculateSubtotal()
        {
            Subtotal = InvoiceDetails.Sum(d => d.TolalDetail);
        }

        public void CalcularTotalIva()
        {
            TotalIva = InvoiceDetails.Sum(d => d.CalculateIva());
        }

        public void CalculateTotal()
        {
            CalculateSubtotal();
            CalcularTotalIva();
           
            Total = Subtotal + TotalIva ;
        }
    }
}