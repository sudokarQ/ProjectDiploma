using DiplomaProject.Backend.Common.DataBaseConfigurations;

namespace DiplomaProject.Backend.Common.Models.Dto.Order
{
    public class OrderGetDto
    {
        public Guid Id { get; set; }
        public DateTime DateTime { get; set; }
        public OrderStatus Status { get; set; }
    }
}
