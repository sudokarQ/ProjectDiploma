using DiplomaProject.Backend.Common.DataBaseConfigurations;
using DiplomaProject.Backend.Common.Models.Enums;

namespace DiplomaProject.Backend.Common.Models.Entity
{
    public class Order
    {
        public Guid Id { get; set; }
        public DateTime DateTime { get; set; }
        public decimal TotaPrice { get; set; }
        public OrderStatus Status { get; set; }
        public TypeOrder Type { get; set; }
        public Guid ClientId { get; set; }
        public Client? Client { get; set; }
        public Guid ServiceId { get; set; }
        public Service? Service { get; set; }
    }
}
