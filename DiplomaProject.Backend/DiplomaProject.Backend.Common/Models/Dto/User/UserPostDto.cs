using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DiplomaProject.Backend.Common.Models.Dto.User
{
    public class UserPostDto
    {
        [Required]
        [StringLength(20, MinimumLength = 5)]
        public string Login { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Password { get; set; }
    }
}
