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
                    Date = order.Date,
                    Time = order.Time,
                    OnDelivery = order.OnDelivery,
                });
            else
                throw new Exception("Validation declined");
        }

        public async Task<OrderPostDto> FindByIdAsync(Guid id)
        {
            var order = await _orderRepository.FindByIdAsync(id);
            return order is null ? null : new OrderPostDto
            {
                Date = order.Date,
                Time = order.Time,
                OnDelivery = order.OnDelivery,
            };
        }

        public Task<List<OrderPostDto>> GetAsync(Func<OrderPostDto, bool> predicate)
        {

            return null;
        }

        public async Task<List<OrderPostDto>> GetAllAsync()
        {
            var orders = await _orderRepository.GetAsync();
            return orders.Select(x => new OrderPostDto
            {
                Date = x.Date,
                Time = x.Time,
                OnDelivery = x.OnDelivery,
            }).ToList();
        }

        public async Task RemoveAsync(OrderPostDto orderDto)
        {
            var order = _orderRepository.FirstOrDefault(x => x.Date == orderDto.Date && x.Time == orderDto.Time);
            await _orderRepository.RemoveAsync(order);
        }

        public async Task UpdateAsync(OrderPostDto orderDto)
        {
            var order = _orderRepository.FirstOrDefault(x => x.Date == orderDto.Date && x.Time == orderDto.Time);
            await _orderRepository.UpdateAsync(order);
        }

        private bool Validation(OrderPostDto order)
        {
            //if (_orderRepository.Find(x => x.Date == order.Date && x.Time == order.Time).Any()) //поменять
            //    return false;

            return true;
        }
    }
}

