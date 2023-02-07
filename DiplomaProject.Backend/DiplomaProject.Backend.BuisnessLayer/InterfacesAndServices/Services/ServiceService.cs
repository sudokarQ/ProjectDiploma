using DiplomaProject.Backend.BuisnessLayer.InterfacesAndServices.Interfaces;
using DiplomaProject.Backend.Common.Models.Dto;
using DiplomaProject.Backend.Common.Models.Dto.Service;
using DiplomaProject.Backend.DataLayer.Repositories.Interfaces;

namespace DiplomaProject.Backend.BuisnessLayer.InterfacesAndServices.Services
{
    public class ServiceService : IServiceService
    {
        private readonly IServiceRepository _serviceRepository;

        public ServiceService(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public async Task CreateAsync(ServicePostDto service)
        {
            if (Validation(service))
                await _serviceRepository.CreateAsync(new()
                {
                    Id = new Guid(),
                    Name = service.Name,
                    TypeService = service.TypeService,
                    Price = service.Price,
                    ShopId = service.ShopId,
                });
            else
                throw new Exception("Validation declined");
        }

        public async Task<ServiceGetDto> FindByIdAsync(IdDto dto)
        {
            var service = await _serviceRepository.FindByIdAsync(x => x.Id == dto.Id);
            return service is null ? null : new ServiceGetDto
            {
                Id = service.Id,
                Name = service.Name,
                TypeService = service.TypeService,
                Price = service.Price,
                ShopId = service.ShopId,
            };
        }

        public async Task<List<ServiceSearchGetDto>> GetListByNameAsync(ServiceSearchGetDto dto)
        {
            var services = await _serviceRepository.GetAsync(x => x.Name.ToLower().StartsWith(dto.Name.ToLower()));

            return services.Select(x => new ServiceSearchGetDto
            {
                Id = x.Id,
                Name = x.Name,
                Price = x.Price,
                Description = x.Description,
            }).OrderBy(x => x.Name).ToList();
        }

        public async Task<List<ServiceGetDto>> GetAllAsync()
        {
            var services = await _serviceRepository.GetAllAsync();
            return services.Select(x => new ServiceGetDto
            {
                Id = x.Id,
                Name = x.Name,
                TypeService = x.TypeService,
                Price = x.Price,
                ShopId = x.ShopId,
            }).ToList();
        }

        public async Task RemoveAsync(IdDto dto)
        {
            var service = await _serviceRepository.FirstOrDefaultAsync(x => x.Id == dto.Id);
            await _serviceRepository.RemoveAsync(service);
        }

        public async Task UpdateAsync(ServicePutDto dto)
        {
            var service = await _serviceRepository.FirstOrDefaultAsync(x => x.Id == dto.Id);

            if (service is null || (service.Name == dto.Name && service.Price == dto.Price))
                return;
            // Валидация?

            service.Name = dto.Name ?? service.Name;
            service.Price = dto.Price ?? service.Price;

            await _serviceRepository.UpdateAsync(service);
        }

        private bool Validation(ServicePostDto service)
        {
            if (string.IsNullOrEmpty(service.Name) || string.IsNullOrEmpty(service.TypeService) || service.Price < 0)
                return false;

            return true;
        }
    }
}
