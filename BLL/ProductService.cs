using System;
using System.Collections.Generic;
using System.Linq;
using DAL;
using Entity;
using Microsoft.EntityFrameworkCore;

namespace BLL
{
    public class ProductService
    {
        private readonly TestContext _context;
        public ProductService(TestContext testContext)
        {
            _context = testContext;    
        }

        public  Response<Product> Save(Product product)
        {
            try
            {
                var suppliers = _context.Suppliers.Include(s => s.Products);
                if(suppliers == null) return new Response<Product>("No hay proveedores registrados");

                var supplier = suppliers.Where(p => p.Nit == product.Supplier.Nit).FirstOrDefault();
                if(supplier == null) return new Response<Product>("El proveedor no se encuentra registrado");
                if(supplier.Products == null) supplier.Products = new List<Product>();

                supplier.Products.Add(product);
                _context.Suppliers.Update(supplier);
                _context.SaveChanges();

                product.Supplier.Products = null;
                return new Response<Product>(product);
            }catch(Exception e)
            {
                return new Response<Product>($"Error del aplicacion: {e.Message}");
            }
        }

        public ResponseList<Product> AllProducts()
        {
            try{
                var products = _context.Products.Include(p => p.Supplier).ToList();
                return new ResponseList<Product>(products);
            }
            catch(Exception e)
            {
                return new ResponseList<Product>($"Error de aplicacion: {e.Message}");
            }
        }
        public Response<Product> ChangeStatus(String idProduct)
        {
            try{
                var oldProduct = _context.Products.Find(idProduct);
                if(oldProduct != null)
                {
                    oldProduct.Status = (oldProduct.Status == "Active") ? "Inactive": "Active";
                    _context.Products.Update(oldProduct);
                    _context.SaveChanges();
                }
                return new Response<Product>(oldProduct);
            }
            catch (Exception e)
            {
                return new Response<Product>($"Error de la Aplicación: {e.Message}");
            }
        }
        public Response<Product> Modidy( Product newProduct)
        {
            try{
                var oldProduct = _context.Products.Find(newProduct.IdProduct);
                if(oldProduct != null)
                {
                    oldProduct.IdProduct = newProduct.IdProduct;
                    oldProduct.Name = newProduct.Name;
                    oldProduct.Status = newProduct.Status;
                    oldProduct.UnitMeasure = newProduct.UnitMeasure;
                    oldProduct.SalePrice = newProduct.SalePrice;
                    oldProduct.PurchasePrice = newProduct.PurchasePrice;
                    oldProduct.Iva = newProduct.Iva;
                    oldProduct.Description = newProduct.Description;
                    oldProduct.QuantityStock = newProduct.QuantityStock;
                    _context.Products.Update(oldProduct);
                    _context.SaveChanges();
                }
                return new Response<Product>(newProduct);
            }
            catch (Exception e)
            {
                return new Response<Product>($"Error de la Aplicación: {e.Message}");
            }
        }

    }
}