using System.ComponentModel.DataAnnotations;
using Entity;

namespace back_end.models
{
    public class SupplierInputModel
    {
        [Required]
        [MinLength(4,ErrorMessage="El codigo debe tener 4 caracteres")]
        [StringLength(4,ErrorMessage="El codigo debe tener 4 caracteres")]
        public string Nit { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Phone { get; set; }

        public Supplier MapSupplier(SupplierInputModel supplierImput)
        {
            Supplier supplier = new Supplier();

            supplier.Nit = supplierImput.Nit;
            supplier.Name = supplierImput.Name;
            supplier.Phone = supplierImput.Phone;

            return supplier;
        }
    }

    public class SupplierViewModel: SupplierInputModel
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