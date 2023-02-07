using DiplomaProject.Backend.BuisnessLayer.InterfacesAndServices.Interfaces;
using DiplomaProject.Backend.Common.Models.Dto;
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
        public Task<List<ServiceGetDto>> GetAllAsync()
        {
            var services = _serviceService.GetAllAsync();
            return services;
        }

        [HttpGet("GetServicesByName")]
        [AllowAnonymous]
        public Task<List<ServiceSearchGetDto>> GetListByName(ServiceSearchGetDto dto)
        {
            var services = _serviceService.GetListByNameAsync(dto);
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
        public async Task<IActionResult> Remove(IdDto dto)
        {
            await _serviceService.RemoveAsync(dto);
            return Ok();
        }

        [HttpPut("UpdateService")]
        [AllowAnonymous]
        public async Task<IActionResult> Update(ServicePutDto dto)
        {
            await _serviceService.UpdateAsync(dto);
            return Ok();
        }

        [HttpGet("FindService")]
        [AllowAnonymous]
        public async Task<ServiceGetDto> FindByIdAsync(IdDto dto)
        {
            var serviceDto = await _serviceService.FindByIdAsync(dto);
            return serviceDto;
        }
    }
}
