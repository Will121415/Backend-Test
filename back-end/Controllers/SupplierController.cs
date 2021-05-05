using System.Collections.Generic;
using System.Linq;
using back_end.models;
using BLL;
using DAL;
using Entity;
using Microsoft.AspNetCore.Mvc;

namespace back_end.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController: ControllerBase
    {
        private readonly SupplierService _supplierService;
        public SupplierController(TestContext testContext)
        {
            _supplierService = new SupplierService(testContext);
        }

        [HttpPost]
        public ActionResult<SupplierViewModel> Save(SupplierInputModel supplierInput)
        {
            Supplier supplier = MapSupplier(supplierInput);
            var response = _supplierService.Save(supplier);

            if (response.Error) return BadRequest(response.Message);
            return Ok(response.Object);

        }
        private Supplier MapSupplier(SupplierInputModel supplierImput)
        {
            Supplier supplier = new Supplier();

            supplier.Nit = supplierImput.Nit;
            supplier.Name = supplierImput.Name;
            supplier.Phone = supplierImput.Phone;

            return supplier;
        }

        [HttpGet]
        public ActionResult<IEnumerable<SupplierViewModel>> AllSuppliers()
        {
            var response = _supplierService.AllSuppliers();

            if(response.Objects == null) return BadRequest(response.Message);
             
            var supplier = response.Objects.Select(s => new SupplierViewModel(s));

            return Ok(supplier);
        }
    }
}