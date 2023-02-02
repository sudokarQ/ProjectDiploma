using System.ComponentModel.DataAnnotations;

namespace DiplomaProject.Backend.Common.Models.Dto.Client
{
    public class ClientPostDto
    {
        public Guid Id { get; set; } 
        [Required]
        [StringLength(30)]
        public string Name { get; set; }
        [Required]
        [StringLength(30)]
        public string Surname { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
    }
}
