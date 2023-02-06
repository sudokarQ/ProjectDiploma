using DiplomaProject.Backend.Common.DataBaseConfigurations;
using System.ComponentModel.DataAnnotations;

namespace DiplomaProject.Backend.Common.Models.Dto.Order
{
    public class OrderPostDto
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        [Required]
        public OrderStatus Status { get; set; }
    }
}
