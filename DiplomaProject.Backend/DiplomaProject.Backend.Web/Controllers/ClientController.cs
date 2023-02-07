using DiplomaProject.Backend.BuisnessLayer.InterfacesAndServices.Interfaces;
using DiplomaProject.Backend.Common.Models.Dto;
using DiplomaProject.Backend.Common.Models.Dto.Client;
using DiplomaProject.Backend.Common.Models.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace DiplomaProject.Backend.Web.Controllers
{
    public class ClientController : Controller
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }


        [HttpGet("GetAllClients")]
        [AllowAnonymous]
        public Task<List<ClientGetDto>> GetAllAsync()
        {
            var clients = _clientService.GetAllAsync();
            return clients;
        }

        [HttpGet("GetClientsByName")]
        [AllowAnonymous]
        public Task<List<ClientSearchGetDto>> GetListByName(ClientSearchGetDto dto)
        {
            var clients = _clientService.GetListByNameAsync(dto);
            return clients;
        }

        [HttpPost("CreateClient")]
        [AllowAnonymous]
        public async Task<IActionResult> CreateAsync(ClientPostDto clientPostDto)
        {
            await _clientService.CreateAsync(clientPostDto);
            return Ok();
        }

        [HttpDelete("DeleteClient")]
        [AllowAnonymous]
        public async Task<IActionResult> Remove(IdDto dto)
        {
            await _clientService.RemoveAsync(dto);
            return Ok();
        }

        [HttpPut("UpdateClient")]
        [AllowAnonymous]
        public async Task<IActionResult> Update(ClientPutDto dto)
        {
            await _clientService.UpdateAsync(dto);
            return Ok();
        }

        [HttpGet("FindClient")]
        [AllowAnonymous]
        public async Task<ClientGetDto> FindByIdAsync(IdDto dto)
        {
            var clientDto = await _clientService.FindByIdAsync(dto);
            return clientDto;
        }
    }
}
