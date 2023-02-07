using System.ComponentModel.DataAnnotations;

namespace DiplomaProject.Backend.Common.Models.Dto.Client
{
    public class ClientPutDto
    {
        [Required]
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? CompanyName { get; set; }
    }
}
