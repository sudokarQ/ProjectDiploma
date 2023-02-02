using DiplomaProject.Backend.BuisnessLayer.InterfacesAndServices.Interfaces;
using DiplomaProject.Backend.Common.Models.Dto.Client;
using DiplomaProject.Backend.DataLayer.Repositories.Interfaces;

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
            if (await Validation(client))
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
                Id = client.Id,
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
                Id = client.Id,
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
                Id = x.Id,
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
                Id = x.Id,
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

        public async Task UpdateAsync(Guid id, ClientPostDto editedClient)
        {
            var client = await _clientRepository.FirstOrDefaultAsync(x => x.Id == id);

            if (client is null)
                return;

            if (!await Validation(editedClient))
                throw new Exception("Validation declined"); ;

            client.Name = editedClient.Name;
            client.Surname = editedClient.Surname;
            client.PhoneNumber = editedClient.PhoneNumber;

            await _clientRepository.UpdateAsync(client);
        }

        public async Task<List<ClientPostDto>> GetListByName(string name)
        {
            var clients = await _clientRepository.GetAsync(x => x.Name.StartsWith(name));

            return clients.Select(x => new ClientPostDto
            {   
                Id = x.Id,
                Name = x.Name,
                Surname = x.Surname,
                PhoneNumber = x.PhoneNumber,
            }).OrderBy(x => x.Name).ThenBy(x => x.Surname).ToList();
        }

        private async Task<bool> Validation(ClientPostDto client)
        {
            if (string.IsNullOrEmpty(client.Name) || string.IsNullOrEmpty(client.Surname) || string.IsNullOrEmpty(client.PhoneNumber))
                return false;

            bool haveAny = await _clientRepository.AnyAsync(x => x.PhoneNumber == client.PhoneNumber);

            if (haveAny)
                return false;

            return true;
        }
    }
}
