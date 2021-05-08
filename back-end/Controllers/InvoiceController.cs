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
    public class InvoiceController: ControllerBase
    {
        private readonly InvoiceService _invoiceService;
        public InvoiceController(TestContext testContext)
        {
            _invoiceService = new InvoiceService(testContext);
        }

        [HttpPost]
        public ActionResult<InvoiceViewModel> Post(InvoiceImputModel invoiceImput)
        {
            Invoice invoice =  MapInvoice(invoiceImput);

            var response =  _invoiceService.Save(invoice);
            if (response.Error) {
                return BadRequest(response.Message);
            }
            return Ok(response.Object);
        }

         private Invoice MapInvoice(InvoiceImputModel invoiceImput)
        {
            Invoice invoice = new Invoice();

            invoice.IdInvoice = invoiceImput.IdInvoice;
            invoice.Subtotal = invoiceImput.Subtotal;
            invoice.TotalIva = invoiceImput.TotalIva;
            invoice.Total = invoiceImput.Total;
            invoice.SaleDate = invoiceImput.SaleDate;
            invoice.IdClient = invoiceImput.IdClient;

            foreach (InvoiceDetailInputModel detailModel in invoiceImput.InvoiceDetails) {

                InvoiceDetail detail =  new InvoiceDetail();

                detail.IdDetail = detailModel.IdDetail;
                detail.UnitValue =detailModel.UnitValue;
                detail.QuantityProduct = detailModel.QuantityProduct;
                detail.Discount = detailModel.Discount;
                detail.TolalDetail =detailModel.TolalDetail;
                detail.IdProduct = detailModel.IdProduct;

                detail.Product  = new  Product();
                detail.Product = MapProduct(detailModel.Product);
                invoice.InvoiceDetails.Add(detail);
            }

            return invoice;
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

            product.Supplier =  null;

            return product;
        }

        //api/Invoice/Count
        [HttpGet]
        public ActionResult<dynamic> Get(string typeRequest) 
        {
           if (typeRequest == "Count") 
           {
                var response = _invoiceService.Count();
                if (response.Error) return BadRequest(response.Message);

                 int result = (++response.Object);

                 return Ok(result);
           } else 
           {
                var response = _invoiceService.AllInvoices();

                if (response.Objects == null) return BadRequest(response.Message);

                var invoices = response.Objects.Select(i => new InvoiceViewModel(i));

                return Ok(invoices);
           }
        } 
        
    }
}