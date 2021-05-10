using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity
{
    public class Supplier: Entity<int>
    {
        [Key]
        [Column(TypeName = "nvarchar(15)")]
        public string Nit { get; set; }
        [Column(TypeName= "nvarchar(30)")]
        public string Name { get; set; }
        [Column(TypeName= "nvarchar(11)")]
        public string Phone { get; set; }

        public IList<Product> Products { get; set; }

    }
}