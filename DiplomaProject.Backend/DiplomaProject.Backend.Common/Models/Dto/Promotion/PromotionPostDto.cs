using System.ComponentModel.DataAnnotations;

namespace DiplomaProject.Backend.Common.Models.Dto.Promotion
{
    public class PromotionPostDto
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal DiscountPercent { get; set; }
        public bool IsCorporate { get; set; }

        public DateTime? BeginDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal? CompanyPercent { get; set; }

        public Guid ServiceId { get; set; } //сделать тоже самое без класса, но по Id
    }
}
