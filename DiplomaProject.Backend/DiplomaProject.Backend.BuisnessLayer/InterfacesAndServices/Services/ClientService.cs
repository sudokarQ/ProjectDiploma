using DiplomaProject.Backend.BuisnessLayer.InterfacesAndServices.Interfaces;
using DiplomaProject.Backend.Common.Models.Dto;
using DiplomaProject.Backend.Common.Models.Dto.Client;
using DiplomaProject.Backend.Common.Models.Entity;
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
                    Email = client.Email,
                    CompanyName = client.CompanyName,
                    BirthdayDate = client.BirthdayDate,
                    Adress = client.Adress,
                    UserId = client.UserId,
                });
            else
                throw new Exception("Validation declined");
        }

        public async Task<ClientGetDto> FindByIdAsync(IdDto dto)
        {
            var client = await _clientRepository.FindByIdAsync(x => x.Id == dto.Id);
            return client is null ? null : new ClientGetDto
            {
                Id = client.Id,
                Name = client.Name,
                Surname = client.Surname,
                PhoneNumber = client.PhoneNumber,
                Email = client.Email,
                BirthdayDate = client.BirthdayDate,
                Adress = client.Adress,
                UserId = client.UserId,
            };
        }

        public async Task<List<ClientGetDto>> GetAllAsync()
        {
            var clients = await _clientRepository.GetAllAsync();
            return clients.Select(x => new ClientGetDto
            {
                Id = x.Id,
                Name = x.Name,
                Surname = x.Surname,
                PhoneNumber = x.PhoneNumber,
                Email = x.Email,
                BirthdayDate = x.BirthdayDate,
                Adress = x.Adress,
                UserId = x.UserId,
            }).ToList();
        }

        public async Task RemoveAsync(IdDto dto)
        {
            var client = await _clientRepository.FirstOrDefaultAsync(x => x.Id == dto.Id);
            await _clientRepository.RemoveAsync(client);
        }

        public async Task UpdateAsync(ClientPutDto dto)
        {
            var client = await _clientRepository.FirstOrDefaultAsync(x => x.Id == dto.Id);

            if (client is null || (client.Name == dto.Name && client.Surname == dto.Surname && client.CompanyName == dto.CompanyName))
                return;

            //if (!await Validation(dto))
            //    throw new Exception("Validation declined");

            client.Name = dto.Name ?? client.Name;
            client.Surname = dto.Surname ?? client.Surname;
            client.CompanyName = dto.CompanyName ?? client.CompanyName;

            await _clientRepository.UpdateAsync(client);
        }

        public async Task<List<ClientSearchGetDto>> GetListByNameAsync(ClientSearchGetDto dto)
        {
            var clients = await _clientRepository.GetAsync(x => x.Name.ToLower().StartsWith(dto.Name.ToLower()));

            return clients.Select(x => new ClientSearchGetDto
            {   
                Id = x.Id,
                Name = x.Name,
                Surname = x.Surname,
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
