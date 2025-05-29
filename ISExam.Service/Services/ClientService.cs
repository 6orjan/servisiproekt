using AutoMapper;
using ISExam.Data.Entities;
using ISExam.Data.Interfaces;
using ISExam.Service.DTOs;
using ISExam.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISExam.Service.Services
{
    public class ClientService : IClientService
    {
        private readonly IMapper mapper;
        private readonly IClientRepository repository;

        public ClientService(IMapper mapper, IClientRepository repository)
        {
            this.mapper = mapper;
            this.repository = repository;
        }

        public ClientDTO AddClient(ClientDTO Client)
        {
            var newClient = mapper.Map<Client>(Client);

            if (repository.GetClient(Client.Id) == null)
                repository.AddClient(newClient);

            return mapper.Map<ClientDTO>(newClient);
            //throw new NotImplementedException();
        }

        public bool DeleteClient(int id)
        {
            var Client = repository.GetClient(id);

            return repository.DeleteClient(Client);
            //throw new NotImplementedException();
        }

        public ClientDTO? GetClient(int id)
        {
            var Client = repository.GetClient(id);

            return mapper.Map<ClientDTO>(Client);
            //throw new NotImplementedException();
        }

        public List<ClientDTO> GetClients()
        {
            var Clients = repository.GetClients();

            return mapper.Map<List<ClientDTO>>(Clients);
            //throw new NotImplementedException();
        }

        public ClientDTO UpdateClient(ClientDTO Client)
        {
            var newClient = mapper.Map<Client>(Client);
            var oldClient = repository.GetClient(Client.Id);

            if (oldClient != null)
                repository.UpdateClient(oldClient, newClient);

            return mapper.Map<ClientDTO>(newClient);
            //throw new NotImplementedException();
        }
    }
}
