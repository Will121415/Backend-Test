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

        public ResponseList<Invoice> AllInvoices()
        {
            try {
                var invoices = _context.Invoices.ToList();
                var clients = _context.Clients.ToList();
                var details = _context.InvoiceDetails.ToList();
                var products = _context.Products.ToList();

                foreach (Invoice invoice1 in invoices) {
                    foreach (Client client in clients) {
                        if (invoice1.IdClient == client.IdClient) {
                            invoice1.Client = client;
                            break;
                        }
                    }
                }

                foreach (InvoiceDetail detail in details) {
                    foreach (Product product in products) {
                        if (detail.IdProduct == product.IdProduct) {
                            detail.Product = product;
                            break;
                        }
                    }
                }

                 foreach (Invoice invoice in invoices) {
                    foreach(InvoiceDetail detail in details) {
                        if (invoice.IdInvoice == detail.InvoiceIdInvoice) {
                            invoice.InvoiceDetails.Add(detail);
                        }
                    }

                }

                return new ResponseList<Invoice>(invoices);

            } catch (Exception e ) {
                return new ResponseList<Invoice>($"Error del aplicacion: {e.Message}");
            }
        }

        public Response<int> Count()
        {
            try {
                int count =  _context.Invoices.Count();
                return new Response<int>(count);
            } catch (Exception e) {
                return new Response<int>($"Error del aplicacion: {e.Message}");
            }
        }
    }
}