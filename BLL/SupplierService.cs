using System;
using System.Linq;
using DAL;
using Entity;

namespace BLL
{
    public class SupplierService
    {
        private readonly TestContext _context;
        public SupplierService(TestContext testContext) => _context = testContext;

        public Response<Supplier> Save(Supplier supplier)
        {
            try
            {
                _context.Suppliers.Add(supplier);
                _context.SaveChanges();
                return new Response<Supplier>(supplier);

            } catch (Exception e) 
            {
                return new Response<Supplier>($"Error de la Aplicación: {e.Message}");
            }
        }

        public ResponseList<Supplier> AllSuppliers()
        {
            try
            {
                var suppliers = _context.Suppliers.ToList();
                return new ResponseList<Supplier>(suppliers);
            }catch (Exception e) 
            {
                return new ResponseList<Supplier>($"Error de la Aplicación: {e.Message}");
            }
        }
    }
}