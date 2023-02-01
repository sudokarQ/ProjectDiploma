using DiplomaProject.Backend.Common.DataBaseConfigurations;
using DiplomaProject.Backend.Common.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace DiplomaProject.Backend.Common.Models.Entity
{
    public class Order
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime DateTime { get; set; }

        public OrderStatus Status { get; set; }
        public TypeOrder Type { get; set; }

        public Client? Client { get; set; }
        public Service? Service { get; set; }
    }
}
