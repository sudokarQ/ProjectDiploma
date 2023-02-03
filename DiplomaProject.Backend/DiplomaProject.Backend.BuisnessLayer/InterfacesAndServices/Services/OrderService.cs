using DiplomaProject.Backend.BuisnessLayer.InterfacesAndServices.Interfaces;
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
                });
            else
                throw new Exception("Validation declined");
        }


        public async Task<OrderPostDto> FindByIdAsync(Guid id)
        {
            var order = await _orderRepository.FindByIdAsync(id);
            return order is null ? null : new OrderPostDto
            {
                Id = id,
                DateTime = order.DateTime,
                Status = order.Status,
            };
        }

        public async Task<List<OrderPostDto>> GetAllAsync()
           => (await _orderRepository.GetAllAsync()).Select(x => new OrderPostDto
           {
               Id = x.Id,
               DateTime = x.DateTime,
               Status = x.Status,
           }).ToList();

        public async Task RemoveAsync(Guid id)
        {
            var order = await _orderRepository.FirstOrDefaultAsync(x => x.Id == id);
            await _orderRepository.RemoveAsync(order);
        }

        public async Task UpdateAsync(Guid id, OrderPostDto editedOrder)
        {
            var order = await _orderRepository.FirstOrDefaultAsync(x => x.Id == id);

            if (order is null)
                return;

            order.DateTime = editedOrder.DateTime;
            order.Status = editedOrder.Status;

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

