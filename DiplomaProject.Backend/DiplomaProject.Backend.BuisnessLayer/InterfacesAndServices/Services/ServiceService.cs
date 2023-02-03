using DiplomaProject.Backend.BuisnessLayer.InterfacesAndServices.Interfaces;
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
                });
            else
                throw new Exception("Validation declined");
        }

        public async Task<ServicePostDto> FindByIdAsync(Guid id)
        {
            var service = await _serviceRepository.FindByIdAsync(id);
            return service is null ? null : new ServicePostDto
            {
                Id = service.Id,
                Name = service.Name,
                TypeService = service.TypeService,
                Price = service.Price,
            };
        }

        public async Task<ServicePostDto> FindByNameAsync(string name)
        {
            var service = await _serviceRepository.FindByNameAsync(name);
            return service is null ? null : new ServicePostDto
            {
                Id = service.Id,
                Name = service.Name,
                TypeService = service.TypeService,
                Price = service.Price,
            }!;
        }

        public async Task<List<ServicePostDto>> GetAllAsync()
        {
            var services = await _serviceRepository.GetAllAsync();
            return services.Select(x => new ServicePostDto
            {
                Id = x.Id,
                Name = x.Name,
                TypeService = x.TypeService,
                Price = x.Price,
            }).ToList();
        }

        public async Task RemoveAsync(Guid id)
        {
            var service = await _serviceRepository.FirstOrDefaultAsync(x => x.Id == id);
            await _serviceRepository.RemoveAsync(service);
        }

        public async Task UpdateAsync(Guid id, ServicePostDto editedService)
        {
            var service = await _serviceRepository.FirstOrDefaultAsync(x => x.Id == id);

            if (service is null || !Validation(editedService))
                return;

            service.Name = editedService.Name;
            service.TypeService = editedService.TypeService;
            service.Price = editedService.Price;

            await _serviceRepository.UpdateAsync(service);
        }

        private bool Validation(ServicePostDto service)
        {
            if (string.IsNullOrEmpty(service.Name) || string.IsNullOrEmpty(service.TypeService) || service.Price < 0)
                return false;

            //if (_serviceRepository.FirstOrDefaultAsync(x => x.Name == service.Name) is not null)
            //    return false;

            return true;
        }
    }
}
