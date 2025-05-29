using ISExam.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISExam.Data.Interfaces
{
    public interface IClientRepository
    {
        public IEnumerable<Client> GetClients();
        public Client? GetClient(int id);
        public void AddClient(Client client);
        public void UpdateClient(Client oldClient, Client newClient);
        public bool DeleteClient(Client client);
    }
}
