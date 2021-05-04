using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity
{
    public class Client
    {
        [Key]
        [Column(TypeName= "nvarchar(11)")]
        public string Indentification { get; set; }
        [Column(TypeName= "nvarchar(130)")]
        public string Name { get; set; }
        [Column(TypeName= "nvarchar(30)")]
        public string LastName { get; set; }
        [Column(TypeName= "nvarchar(11)")]
        public string Phone { get; set; }
        [Column(TypeName= "nvarchar(50)")]
        public string Address { get; set; }
        [Column(TypeName= "nvarchar(30)")]
        public string Neighborhood { get; set; }
        [Column(TypeName= "nvarchar(20)")]
        public string City { get; set; }

    }
}