using System;
using DAL;
using Entity;

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
                _context.Add(product);
                _context.SaveChanges();
                return new Response<Product>(product);
            }catch(Exception e)
            {
                return new Response<Product>($"Error del aplicacion: {e.Message}");
            }
        }

    }
}