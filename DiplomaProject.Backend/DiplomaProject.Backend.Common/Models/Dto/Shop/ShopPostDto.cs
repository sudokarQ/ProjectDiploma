using System.ComponentModel.DataAnnotations;

namespace DiplomaProject.Backend.Common.Models.Dto.Shop
{
    public class ShopPostDto
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
