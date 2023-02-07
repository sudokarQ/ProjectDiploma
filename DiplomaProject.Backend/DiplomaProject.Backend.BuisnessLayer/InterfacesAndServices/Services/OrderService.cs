using DiplomaProject.Backend.BuisnessLayer.InterfacesAndServices.Interfaces;
using DiplomaProject.Backend.Common.Models.Dto;
using DiplomaProject.Backend.Common.Models.Dto.Order;
using DiplomaProject.Backend.DataLayer.Repositories.Interfaces;

namespace DiplomaProject.Backend.BuisnessLayer.InterfacesAndServices.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }


        public async Task CreateAsync(OrderPostDto order)
        {
            if (Validation(order))
                await _orderRepository.CreateAsync(new()
                {
                    Id = new Guid(),
                    DateTime = order.DateTime,
                    Status = order.Status,
                    Type = order.Type,
                    ClientId = order.ClientId,
                    ServiceId = order.ServiceId,
                });
            else
                throw new Exception("Validation declined");
        }


        public async Task<OrderGetDto> FindByIdAsync(IdDto dto)
        {
            var order = await _orderRepository.FindByIdAsync(x => x.Id == dto.Id);
            return order is null ? null : new OrderGetDto
            {
                Id = dto.Id,
                DateTime = order.DateTime,
                Status = order.Status,
                Type = order.Type,
                ClientId = order.ClientId,
                ServiceId = order.ServiceId,
                TotaPrice = order.TotaPrice,
            };
        }

        public async Task<List<OrderGetDto>> GetAllAsync()
           => (await _orderRepository.GetAllAsync()).Select(x => new OrderGetDto
           {
               Id = x.Id,
               DateTime = x.DateTime,
               Status = x.Status,
               Type = x.Type,
               ClientId = x.ClientId,
               ServiceId = x.ServiceId,
               TotaPrice = x.TotaPrice,
           }).ToList();

        public async Task RemoveAsync(IdDto dto)
        {
            var order = await _orderRepository.FirstOrDefaultAsync(x => x.Id == dto.Id);
            await _orderRepository.RemoveAsync(order);
        }

        public async Task UpdateAsync(OrderPutDto dto)
        {
            var order = await _orderRepository.FirstOrDefaultAsync(x => x.Id == dto.Id);

            if (order is null)
                return;

            order.Type = dto.Type ?? order.Type;
            order.Status = dto.Status ?? order.Status;
            order.TotaPrice= dto.TotaPrice ?? order.TotaPrice;

            await _orderRepository.UpdateAsync(order);
        }

        private bool Validation(OrderPostDto order)
        {
            //if (_orderRepository.FirstOrDefaultAsync(x => x.DateTime == order.DateTime) is not null) //поменять
            //    return false;

            return true;
        }
    }
}

