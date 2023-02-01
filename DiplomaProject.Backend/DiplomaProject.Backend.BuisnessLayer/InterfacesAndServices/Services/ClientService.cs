using DiplomaProject.Backend.BuisnessLayer.InterfacesAndServices.Interfaces;
using DiplomaProject.Backend.Common.Models.Dto.Client;
using DiplomaProject.Backend.Common.Models.Entity;
using DiplomaProject.Backend.DataLayer.Repositories.Interfaces;
using System.Linq.Expressions;

namespace DiplomaProject.Backend.BuisnessLayer.InterfacesAndServices.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;

        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task CreateAsync(ClientPostDto client)
        {
            if (Validation(client))
                await _clientRepository.CreateAsync(new()
                {
                    Id = new Guid(),
                    Name = client.Name,
                    Surname = client.Surname,
                    PhoneNumber = client.PhoneNumber,
                });
            else
                throw new Exception("Validation declined");
        }

        public async Task<ClientPostDto> FindByIdAsync(Guid id)
        {
            var client = await _clientRepository.FindByIdAsync(id);
            return client is null ? null : new ClientPostDto
            {
                Name = client.Name,
                Surname = client.Surname,
                PhoneNumber = client.PhoneNumber,
            };
        }

        public async Task<ClientPostDto> FindByNameAsync(string name)
        {
            var client = await _clientRepository.FindByNameAsync(name);
            return client is null ? null : new ClientPostDto
            {
                Name = client.Name,
                Surname = client.Surname,
                PhoneNumber = client.PhoneNumber,
            }!;
        }

        public async Task<List<ClientPostDto>> GetAsync()
        {
            var clients = await _clientRepository.GetAsync(x => x.Name == "123");
            return clients.Select(x => new ClientPostDto
            {
                Name = x.Name,
                Surname = x.Surname,
                PhoneNumber = x.PhoneNumber,
            }).ToList();
        }

        public async Task<List<ClientPostDto>> GetAllAsync()
        {
            var clients = await _clientRepository.GetAllAsync();
            return clients.Select(x => new ClientPostDto
            {
                Name = x.Name,
                Surname = x.Surname,
                PhoneNumber = x.PhoneNumber,
            }).ToList();
        }

        public async Task RemoveAsync(Guid id)
        {
            var client = await _clientRepository.FirstOrDefaultAsync(x => x.Id == id);
            await _clientRepository.RemoveAsync(client);
        }

        public async Task UpdateAsync(ClientPostDto clientDto)
        {
            var client = await _clientRepository.FirstOrDefaultAsync(x => x.PhoneNumber == clientDto.PhoneNumber);
            await _clientRepository.UpdateAsync(client);
        }

        private bool Validation(ClientPostDto client)
        {
            if (string.IsNullOrEmpty(client.Name) || string.IsNullOrEmpty(client.Surname) || string.IsNullOrEmpty(client.PhoneNumber))
                return false;

            //if (_clientRepository.Find(x => x.PhoneNumber == client.PhoneNumber).Any())
            //    return false;

            //if (_clientRepository.FirstOrDefaultAsync(x => x.PhoneNumber == client.PhoneNumber) is not null)
            //    return false;

            return true;
        }
    }
}
