using ISExam.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISExam.Service.Interfaces
{
    public interface IClientService
    {
        public List<ClientDTO> GetClients();
        public ClientDTO? GetClient(int id);
        public ClientDTO UpdateClient(ClientDTO Client);
        public ClientDTO AddClient(ClientDTO Client);
        public bool DeleteClient(int id);
    }
}
