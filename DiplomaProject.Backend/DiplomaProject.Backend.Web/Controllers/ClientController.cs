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

        //[HttpGet("GetShop")]
        //[AllowAnonymous]
        //public Task<List<Client>> GetAsync(Expression<Func<Client, bool>> predicate)
        //{
        //    var clients = _clientService.GetAsync(predicate);
        //    return clients;
        //}

        [HttpGet("GetAllClients")]
        [AllowAnonymous]
        public Task<List<ClientPostDto>> GetAllAsync()
        {
            var clients = _clientService.GetAllAsync();
            return clients;
        }

        [HttpPost("CreateClient")]
        [AllowAnonymous]
        public IActionResult CreateAsync(ClientPostDto clientPostDto)
        {
            _clientService.CreateAsync(clientPostDto);
            return Ok();
        }

        [HttpDelete("DeleteClient")]
        [AllowAnonymous]
        public async Task<IActionResult> Remove(ClientPostDto clientPostDto)
        {
            await _clientService.RemoveAsync(clientPostDto);
            return Ok();
        }

        [HttpPut("UpdateClient")]
        [AllowAnonymous]
        public async Task<IActionResult> Update(ClientPostDto clientPostDto)
        {
            await _clientService.UpdateAsync(clientPostDto);
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
