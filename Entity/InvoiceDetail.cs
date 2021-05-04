using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity
{
    public class InvoiceDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdDetail { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal UnitValue { get; set; }
        public float QuantityProduct { get; set; }
        public float Discount { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal TolalDetail { get; set; }
        [NotMapped]
        public string IdInvoice { get; set; }
        [NotMapped]
        public string IdProduct { get; set; }
        [Column(TypeName = "nvarchar(10)")]
        [ForeignKey("IdProduct")]
        public virtual Product Product { get; set; }
        
        public InvoiceDetail()
        {
            
        }

        public InvoiceDetail(Product product, float quantity, float discount, decimal price)
        {
            IdProduct = product.IdProduct;
            Product = product;
            UnitValue = price;
            QuantityProduct = quantity;
            Discount = discount;
            CalculateTotalDetail();
            CalculateIva();
        }

        public void CalculateTotalDetail()
        {
            
            TolalDetail = Decimal.Round((((decimal)QuantityProduct) * Product.SalePrice) * (1 - ((decimal)Discount/100)), 1);
        }


        public decimal CalculateIva()
        {
            return TolalDetail * (Product.Iva  / 100) ;
        }
    }
}