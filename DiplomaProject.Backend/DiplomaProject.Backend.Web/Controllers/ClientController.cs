using DiplomaProject.Backend.BuisnessLayer.InterfacesAndServices.Interfaces;
using DiplomaProject.Backend.Common.Models.Dto.Client;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
        //public IActionResult GetAsync(Func<ShopPostDto, bool> predicate)
        //{
        //    _shopService.GetAsync(predicate);
        //    return Ok();
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
        public IActionResult Remove(ClientPostDto clientPostDto)
        {
            _clientService.Remove(clientPostDto);
            return Ok();
        }

        [HttpPut("UpdateClient")]
        [AllowAnonymous]
        public IActionResult Update(ClientPostDto clientPostDto)
        {
            _clientService.Update(clientPostDto);
            return Ok();
        }

        [HttpGet("FindClient")]
        [AllowAnonymous]
        public async Task<ClientPostDto> FindByIdAsync(Guid id)
        {
            var clientDto = await _clientService.FindById(id);
            if (clientDto == null)
                return null;

            return clientDto;
        }
    }
}
