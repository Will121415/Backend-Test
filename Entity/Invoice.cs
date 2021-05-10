using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Entity
{
    public class Invoice: Entity<int>
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
        [Column(TypeName= "nvarchar(11)")]
        public string IdClient { get; set; }
        
        [NotMapped]
        public  Client Client { get; set; }

        [Column(TypeName= "nvarchar(4)")]
        [ForeignKey("IdInvoice")]
        public  IList<InvoiceDetail> InvoiceDetails { get; set; } 

        public Invoice() {
            InvoiceDetails = new List<InvoiceDetail>();
        }

        public Invoice(string idIvoice, string idClient)
        {
            IdInvoice = idIvoice;
            IdClient = idClient;
            SaleDate = DateTime.Now.ToString("dd/MM/yyyy"); 
            InvoiceDetails = new List<InvoiceDetail>();
        }

        public void AddInvoiceDetails(Product product, float quantity, float discount, decimal price)
        {
            InvoiceDetail invoiceDetail = new InvoiceDetail(product, quantity, discount, price);
            InvoiceDetails.Add(invoiceDetail);
        }

        public void CalculateSubtotal()
        {
            Subtotal = InvoiceDetails.Sum(d => d.TolalDetail);
        }

        public void CalcularTotalIva()
        {
            TotalIva = 0.0m;
            foreach (var item in this.InvoiceDetails)
            {
                this.TotalIva +=  item.CalculateIva();
            }
        }

        public void CalculateTotal()
        {
            this.CalculateSubtotal();
            this.CalcularTotalIva();
           
            Total = Subtotal + TotalIva ;
        }
    }
}