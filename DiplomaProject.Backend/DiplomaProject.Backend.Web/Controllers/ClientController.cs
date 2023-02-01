using DiplomaProject.Backend.BuisnessLayer.InterfacesAndServices.Interfaces;
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

        [HttpGet("GetClient")]
        [AllowAnonymous]
        public async Task<List<ClientPostDto>> GetAsync()
        {
            var clients = await _clientService.GetAsync();
            return clients;
        }

        [HttpGet("GetAllClients")]
        [AllowAnonymous]
        public Task<List<ClientPostDto>> GetAllAsync()
        {
            var clients = _clientService.GetAllAsync();
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
        public async Task<IActionResult> Remove(Guid id)
        {
            await _clientService.RemoveAsync(id);
            return Ok();
        }

        [HttpPut("UpdateClient")]
        [AllowAnonymous]
        public async Task<IActionResult> Update(Guid id, ClientPostDto editedClient)
        {
            await _clientService.UpdateAsync(id, editedClient);
            return Ok();
        }

        [HttpGet("FindClient")]
        [AllowAnonymous]
        public async Task<ClientPostDto> FindByIdAsync(Guid id)
        {
            var clientDto = await _clientService.FindByIdAsync(id);
            return clientDto;
        }
    }
}
