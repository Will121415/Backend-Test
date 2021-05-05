using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity
{
    public class Product
    {
        [Key]
        [Column(TypeName= "nvarchar(10)")]
        public string  IdProduct { get; set; }
        [Column(TypeName= "nvarchar(20)")]
        public string Name { get; set; }
        [Column(TypeName= "nvarchar(20)")]
        public string Status { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal SalePrice { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal PurchasePrice { get; set; }
        [Column(TypeName = "nvarchar(10)")]
        public string UnitMeasure { get; set; }
        public float QuantityStock { get; set; }
        public int Iva { get; set; }
        public string Description { get; set; }
        // [NotMapped]
        // [Column(TypeName = "nvarchar(15)")]
        // public string IdSupplier { get; set; }
        // [ForeignKey("IdSupplier")]
        public  Supplier Supplier { get; set; }


    }
}