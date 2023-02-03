using DiplomaProject.Backend.BuisnessLayer.InterfacesAndServices.Interfaces;
using DiplomaProject.Backend.Common.Models.Dto.Client;
using DiplomaProject.Backend.Common.Models.Dto.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DiplomaProject.Backend.Web.Controllers
{
    public class ServiceController : Controller
    {
        private readonly IServiceService _serviceService;

        public ServiceController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }


        [HttpGet("GetAllServices")]
        [AllowAnonymous]
        public Task<List<ServicePostDto>> GetAllAsync()
        {
            var services = _serviceService.GetAllAsync();
            return services;
        }

        [HttpPost("CreateService")]
        [AllowAnonymous]
        public async Task<IActionResult> CreateAsync(ServicePostDto servicePostDto)
        {
            await _serviceService.CreateAsync(servicePostDto);
            return Ok();
        }

        [HttpDelete("DeleteService")]
        [AllowAnonymous]
        public async Task<IActionResult> Remove(Guid id)
        {
            await _serviceService.RemoveAsync(id);
            return Ok();
        }

        [HttpPut("UpdateService")]
        [AllowAnonymous]
        public async Task<IActionResult> Update(Guid id, ServicePostDto editedService)
        {
            await _serviceService.UpdateAsync(id, editedService);
            return Ok();
        }

        [HttpGet("FindService")]
        [AllowAnonymous]
        public async Task<ServicePostDto> FindByIdAsync(Guid id)
        {
            var serviceDto = await _serviceService.FindByIdAsync(id);
            return serviceDto;
        }
    }
}
