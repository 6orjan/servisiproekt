using ISExam.Data.Entities;
using ISExam.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ISExam.Data.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly MainContext context;

        public ClientRepository(MainContext context)
        {
            this.context = context;
        }

        public void AddClient(Client client)
        {
            context.Clients.Add(client);
            context.SaveChanges();
            //throw new NotImplementedException();
        }

        public bool DeleteClient(Client client)
        {
            try
            {
                context.Clients.Remove(client);
                context.SaveChanges();
                return true;
            } catch
            {
                return false;
            }
            //throw new NotImplementedException();
        }

        public Client? GetClient(int id)
        {
            return context.Clients.Include(c => c.Movie).FirstOrDefault(c => c.Id == id);
            //throw new NotImplementedException();
        }

        public IEnumerable<Client> GetClients()
        {
            //throw new NotImplementedException();
            return context.Clients.Include(c => c.Movie);
        }

        public void UpdateClient(Client oldClient, Client newClient)
        {
            context.Clients.Entry(oldClient).CurrentValues.SetValues(newClient);
            context.SaveChanges();
            //throw new NotImplementedException();
        }
    }
}
