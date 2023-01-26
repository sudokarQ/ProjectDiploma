using DiplomaProject.Backend.BuisnessLayer.InterfacesAndServices.Interfaces;
using DiplomaProject.Backend.Common.Models.Dto.Client;
using DiplomaProject.Backend.Common.Models.Entity;
using DiplomaProject.Backend.DataLayer.GenericRepository;

namespace DiplomaProject.Backend.BuisnessLayer.InterfacesAndServices.Services
{
    public class ClientService : IClientService
    {
        private readonly IGenericRepository<Client> _genericRepository;

        public ClientService(IGenericRepository<Client> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public void CreateAsync(ClientPostDto client)
        {
            if (Validation(client))
                _genericRepository.CreateAsync(new()
                {
                    Id = new Guid(),
                    Name = client.Name,
                    Surname = client.Surname,
                    PhoneNumber = client.PhoneNumber,
                });
            else
                throw new Exception("Validation declined");
        }

        public async Task<ClientPostDto> FindById(Guid id)
        {
            var client = await _genericRepository.FindById(id);
            if (client != null)
            {
                return new ClientPostDto
                {
                    Name = client.Name,
                    Surname = client.Surname,
                    PhoneNumber = client.PhoneNumber,
                };
            }
            return null;
        }

        public async Task<ClientPostDto> FindByName(string name)
        {
            var client = await _genericRepository.FindByName(name);
            if (client != null)
            {
                return new ClientPostDto
                {
                    Name = client.Name,
                    Surname = client.Surname,
                    PhoneNumber = client.PhoneNumber,
                };
            }
            return null;
        }

        public Task<List<ClientPostDto>> GetAsync(Func<ClientPostDto, bool> predicate)
        {

            return null;
        }

        public async Task<List<ClientPostDto>> GetAllAsync()
        {
            var clients = await _genericRepository.GetAsync();
            return clients.Select(x => new ClientPostDto
            {
                Name = x.Name,
                Surname = x.Surname,
                PhoneNumber = x.PhoneNumber,
            }).ToList();
        }

        public void Remove(ClientPostDto clientDto)
        {
            var client = _genericRepository.FirstOrDefault(x => x.PhoneNumber == clientDto.PhoneNumber && x.Surname == clientDto.Surname);
            _genericRepository.Remove(client);
        }

        public void Update(ClientPostDto clientDto)
        {
            var client = _genericRepository.FirstOrDefault(x => x.PhoneNumber == clientDto.PhoneNumber);
            _genericRepository.Update(client);
        }

        private bool Validation(ClientPostDto client)
        {
            if (string.IsNullOrEmpty(client.Name) || string.IsNullOrEmpty(client.Surname) || string.IsNullOrEmpty(client.PhoneNumber))
                return false;

            if (_genericRepository.Find(x => x.PhoneNumber == client.PhoneNumber).Any())
                return false;

            return true;
        }
    }
}
