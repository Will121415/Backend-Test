using System.Collections.Generic;
using Entity;

namespace back_end.models
{
    public class InvoiceDetailInputModel
    {
        public int IdDetail { get; set; }
        public decimal UnitValue { get; set; }
        public float QuantityProduct { get; set; }
        public float Discount { get; set; }
        public decimal TolalDetail { get; set; }
        public string IdProduct{ get; set; }
        public  ProductInputModel Product { get; set; }

        public InvoiceDetailInputModel()
        {
            
        }
    }

    public class InvoiceImputModel
    {
        public string IdInvoice{ get; set; }
        public decimal Subtotal { get; set; }
        public decimal TotalIva { get; set; }
        public decimal Total { get; set; }
        public string SaleDate { get; set; }
        public string  IdClient { get; set; }
        public  IList<InvoiceDetailInputModel> InvoiceDetails { get; set; } 

        public InvoiceImputModel()
        {
            this.InvoiceDetails = new List<InvoiceDetailInputModel>();
        }
    }

    public class InvoiceViewModel: InvoiceImputModel
    {
        public InvoiceViewModel()
        {
            
        }

        public InvoiceViewModel(Invoice invoice)
        {
            IdInvoice = invoice.IdInvoice;
            Subtotal = invoice.Subtotal;
            TotalIva = invoice.TotalIva;
            Total = invoice.Total;
            SaleDate = invoice.SaleDate;
            IdClient = invoice.IdClient;



            foreach (InvoiceDetail detail in invoice.InvoiceDetails) {

                InvoiceDetailInputModel detailModel =  new InvoiceDetailInputModel();

                detailModel.IdDetail = detail.IdDetail;
                detailModel.UnitValue = detail.UnitValue;
                detailModel.QuantityProduct = detail.QuantityProduct;
                detailModel.Discount = detail.Discount;
                detailModel.TolalDetail = detail.TolalDetail;
                detailModel.IdProduct  = detail.IdProduct;


                detailModel.Product = new ProductInputModel();
                detailModel.Product  = new ProductViewModel(detail.Product);
                InvoiceDetails.Add(detailModel);
            }

        }

    }
}