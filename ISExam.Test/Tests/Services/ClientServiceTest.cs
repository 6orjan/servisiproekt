using AutoMapper;
using ISExam.Data.Entities;
using ISExam.Data.Interfaces;
using ISExam.Service.DTOs;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ISExam.Test.Tests.Services
{
    public class ClientServiceTest
    {
        IClientRepository clientRepository;
        IMapper mapper;
        Mock<IClientRepository> clientRepositoryMock = new Mock<IClientRepository>();
        Client client;
        ClientDTO clientDTO;
        Mock<IMapper> mapperMock = new Mock<IMapper>();
        List<ClientDTO> clientDTOList = new List<ClientDTO>();
        List<Client> clients = new List<Client>();

        private Client GetClient()
        {
            return new Client
            {
                Address = "Address",
                FirstName = "FirstName",
                Id = 1,
                LastName = "LastName",
                MembershipCardNumber = 123456,
                MembershipValidityDate = DateTime.Now,
                RentDate = DateTime.Now,
                ReturnDate = DateTime.Now.AddDays(7),
                DOB = DateTime.Now.AddYears(-20)
            };
        }

        private ClientDTO GetClientDTO()
        {
            return new ClientDTO
            {
                Address = "Address",
                FirstName = "FirstName",
                Id = 1,
                LastName = "LastName",
                MembershipCardNumber = 123456,
                MembershipValidityDate = DateTime.Now,
                RentDate = DateTime.Now,
                ReturnDate = DateTime.Now.AddDays(7),
                DOB = DateTime.Now.AddYears(-20)
            };
        }

        private List<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    Address = "Address",
                    FirstName = "FirstName",
                    Id = 1,
                    LastName = "LastName",
                    MembershipCardNumber = 123456,
                    MembershipValidityDate = DateTime.Now,
                    RentDate = DateTime.Now,
                    ReturnDate = DateTime.Now.AddDays(7),
                    DOB = DateTime.Now.AddYears(-20)
                },
                new Client
                {
                    Address = "Address2",
                    FirstName = "FirstName2",
                    Id = 2,
                    LastName = "LastName2",
                    MembershipCardNumber = 123456,
                    MembershipValidityDate = DateTime.Now,
                    RentDate = DateTime.Now,
                    ReturnDate = DateTime.Now.AddDays(7),
                    DOB = DateTime.Now.AddYears(-20)
                }
            };
        }

        private void SetUpMocks()
        {
            clientRepository = clientRepositoryMock.Object;
            mapper = mapperMock.Object;
        }

        private void SetUpClientDTOListMock()
        {
            clientDTO = GetClientDTO();

            var clientDTO2 = GetClientDTO();

            clientDTO2.Id = 2;

            clientDTOList.Add(clientDTO);
            clientDTOList.Add(clientDTO2);

            clients = GetClients();

            mapperMock.Setup(o => o.Map<List<ClientDTO>>(clients)).Returns(clientDTOList);
        }

        private void SetUpClientDTOMock()
        {
            client = GetClient();

            mapperMock.Setup(o => o.Map<ClientDTO>(client)).Returns(GetClientDTO());
        }

        [Fact]
        public void GetAllClientsTest()
        {
            SetUpMocks();
            SetUpClientDTOListMock();
            clientRepositoryMock.Setup(o => o.GetClients()).Returns(clients);

            var result = clientRepository.GetClients();

            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public void GetClientByIdTest()
        {
            SetUpMocks();
            SetUpClientDTOMock();
            clientRepositoryMock.Setup(o => o.GetClient(1)).Returns(client);
            var result = clientRepository.GetClient(1);
            Assert.NotNull(result);
            Assert.Equal(client.Id, result.Id);
        }
    }
}
