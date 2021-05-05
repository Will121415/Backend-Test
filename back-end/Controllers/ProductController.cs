using System;
using back_end.models;
using BLL;
using DAL;
using Entity;
using Microsoft.AspNetCore.Mvc;

namespace back_end.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController: ControllerBase
    {
        private readonly ProductService _productService;

        public ProductController(TestContext testContext)
        {
            _productService = new ProductService(testContext);
        }

                [HttpPost]
        public ActionResult<ProductViewModel> Post(ProductInputModel productModel)
        {
            Product product = MapProduct(productModel);
            Console.WriteLine(product.ToString());
            var response = _productService.Save(product);

            if (response.Error) return BadRequest(response.Message);
            return Ok(response.Object);

        }

        private Product MapProduct(ProductInputModel productModel)
        {
            Product product = new Product();
            
            product.IdProduct = productModel.IdProduct;
            product.Name = productModel.Name;
            product.PurchasePrice = productModel.PurchasePrice;
            product.SalePrice = productModel.SalePrice;
            product.UnitMeasure = productModel.UnitMeasure;
            product.QuantityStock = productModel.QuantityStock;
            product.Iva = productModel.Iva;
            product.Description = productModel.Description;

            product.Supplier =  MapSupplier(productModel.Supplier);

            return product;
        }
        private Supplier MapSupplier(SupplierImputModel supplierImput)
        {
            Supplier supplier = new Supplier();

            supplier.Nit = supplierImput.Nit;
            supplier.Name = supplierImput.Name;
            supplier.Phone = supplierImput.Phone;

            return supplier;
        }
    }
}