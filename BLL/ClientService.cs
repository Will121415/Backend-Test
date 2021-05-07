using System;
using System.Linq;
using DAL;
using Entity;

namespace BLL
{
    public class ClientService
    {
        private readonly TestContext _context;

        public ClientService(TestContext testContext)
        {
            _context = testContext;
        }

        public Response<Client> Save(Client client)
        {
            try {
                _context.Add(client);
                _context.SaveChanges();
                return new Response<Client>(client);
            } catch (Exception e) {

                return new Response<Client>($"Error del aplicacion: {e.Message}");
            }
        }

        public Response<Client> FindById(string idClient)
        {
            try 
            {
                Client client = _context.Clients.Where(c => c.IdClient == idClient).FirstOrDefault();
                return new Response<Client>(client);
            }
            catch (Exception e)
            {
                
                return new Response<Client>($"Error de la Aplicacion: {e.Message}");
            }
        }

        public ResponseList<Client> AllClients()
        {
            try {
                var clients = _context.Clients.ToList();
                return new ResponseList<Client>(clients);
            } catch (Exception e) {
                return new ResponseList<Client>($"Error del aplicacion: {e.Message}");
            }
        }

         public Response<Client> Modify(Client newClient)
        {
            try {
                var oldClient =  _context.Clients.Find(newClient.IdClient);

                if (oldClient != null)
                {
                    oldClient.IdClient =  newClient.IdClient;
                    oldClient.Name = newClient.Name;
                    oldClient.LastName = newClient.LastName;
                    oldClient.Phone =  newClient.Phone;
                    oldClient.Address = newClient.Address;
                    oldClient.Neighborhood = newClient.Neighborhood;
                    oldClient.City = newClient.City;

                    _context.Clients.Update(oldClient);
                    _context.SaveChanges();
                }
                

                return new Response<Client>(newClient);
            } catch (Exception e ) {
                return new Response<Client>($"Error del aplicacion: {e.Message}");
            }
        }
    }
}