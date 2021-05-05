using System.Linq;
using System.Collections.Generic;
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
            var response = _productService.Save(product);

            if (response.Error) return BadRequest(response.Message);
            return Ok(response.Object);

        }

        private Product MapProduct(ProductInputModel productModel)
        {
            Product product = new Product();
            
            product.IdProduct = productModel.IdProduct;
            product.Name = productModel.Name;
            product.Status = productModel.Status;
            product.PurchasePrice = productModel.PurchasePrice;
            product.SalePrice = productModel.SalePrice;
            product.UnitMeasure = productModel.UnitMeasure;
            product.QuantityStock = productModel.QuantityStock;
            product.Iva = productModel.Iva;
            product.Description = productModel.Description;

            product.Supplier =  MapSupplier(productModel.Supplier);

            return product;
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
        public ActionResult<IEnumerable<ProductViewModel>> AllProducts()
        {
            var response = _productService.AllProducts();

            if(response.Objects == null) return BadRequest(response.Message);

            var products = response.Objects.Select(p => new ProductViewModel(p));

            return Ok(products); 
        }

        [HttpPut]
        public ActionResult<ProductViewModel> Modify(ProductInputModel productInput)
        {
            Product product = MapProduct(productInput);
            var response = _productService.Modidy(product);
            if(response.Error) return BadRequest(response.Message);
            return Ok(response.Object);
        }

        [HttpPut("{idProduct}")]
        public ActionResult<ProductViewModel> ChangeStatus(String idProduct)
        {
            var response = _productService.ChangeStatus(idProduct);
            if(response.Error) return BadRequest(response.Message);
            return Ok(response.Object);
        }
    }
}