using System.ComponentModel.DataAnnotations;

namespace DiplomaProject.Backend.Common.Models.Dto.Promotion
{
    public class PromotionPostDto
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal DiscountPercent { get; set; }
        public bool IsCorporate { get; set; }
    }
}
