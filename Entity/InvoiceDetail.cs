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

        [Column(TypeName = "nvarchar(10)")]
        public string IdProduct { get; set; }
        [NotMapped]
        public string InvoiceIdInvoice { get; set; }
        [NotMapped]
        public  Product Product { get; set; }
        
        
        
        public InvoiceDetail()
        {
            
        }

        public InvoiceDetail(Product product, float quantity, float discount, decimal price)
        {
            Product = product;
            UnitValue = price;
            IdProduct = product.IdProduct;
            QuantityProduct = quantity;
            Discount = discount;
            CalculateTotalDetail();
        }

       
        public void CalculateTotalDetail()
        {
            
            TolalDetail = Decimal.Round((((decimal)QuantityProduct) * Product.SalePrice) * (1 - ((decimal)Discount/100)), 1);
        }


        public decimal CalculateIva()
        {
            return TolalDetail * ((decimal)Product.Iva  / (decimal)100);
        }
    }
}