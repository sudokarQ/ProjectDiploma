using DiplomaProject.Backend.Common.DataBaseConfigurations;

namespace DiplomaProject.Backend.Common.Models.Entity
{
    public class Order
    {
        public Guid Id { get; set; }
        public DateOnly Date { get; set; }
        public TimeOnly Time { get; set; }

        public bool OnDelivery { get; set; }
        public DeliveryStatus? Status { get; set; }

        public Client? Client { get; set; }
        public Service? Service { get; set; }
    }
}
