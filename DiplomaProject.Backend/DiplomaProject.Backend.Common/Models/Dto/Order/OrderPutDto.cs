using DiplomaProject.Backend.Common.DataBaseConfigurations;
using DiplomaProject.Backend.Common.Models.Enums;

namespace DiplomaProject.Backend.Common.Models.Dto.Order
{
    public class OrderPutDto
    {
        public Guid Id { get; set; }
        public OrderStatus? Status { get; set; }
        public TypeOrder? Type { get; set; }
        public decimal? TotaPrice { get; set; }
    }
}
