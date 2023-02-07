using System.ComponentModel.DataAnnotations;

namespace DiplomaProject.Backend.Common.Models.Dto.Service
{
    public class ServicePutDto
    {
        [Required]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
    }
}
