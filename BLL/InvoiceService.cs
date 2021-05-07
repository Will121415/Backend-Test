using System;
using System.Collections.Generic;
using System.Linq;
using DAL;
using Entity;
using Microsoft.EntityFrameworkCore;

namespace BLL
{
    public class InvoiceService
    {
        private readonly TestContext _context;
        public InvoiceService(TestContext testContext)
        {
            _context = testContext;
        }
        public Response<Invoice> Save(Invoice invoice)
        {
            try {

                Invoice newInvoice = new Invoice(invoice.IdInvoice, invoice.IdClient);
                foreach (InvoiceDetail detail in invoice.InvoiceDetails)
                {
                    newInvoice.AddInvoiceDetails(detail.Product,detail.QuantityProduct, detail.Discount,detail.UnitValue);
                }
                newInvoice.CalculateTotal();
                foreach (InvoiceDetail detail1 in newInvoice.InvoiceDetails)
                {
                    detail1.Product = null;
                }

                _context.Invoices.Add(newInvoice);
                _context.SaveChanges();
                return new Response<Invoice>(newInvoice);
            } catch (Exception e) {
                return new Response<Invoice>($"Error del aplicacion: {e.Message}");
            }
        }
    }
}