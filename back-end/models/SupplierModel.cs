using System.ComponentModel.DataAnnotations;
using Entity;

namespace back_end.models
{
    public class SupplierImputModel
    {
        [Required]
        [MinLength(4,ErrorMessage="El codigo debe tener 4 caracteres")]
        [StringLength(4,ErrorMessage="El codigo debe tener 4 caracteres")]
        public string Nit { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Phone { get; set; }
    }

    public class SupplierViewModel: SupplierImputModel
    {
        public SupplierViewModel() {}

        public SupplierViewModel(Supplier supplier) 
        {
            Nit = supplier.Nit;
            Name = supplier.Name;
            Phone = supplier.Phone;

        }
    }
}