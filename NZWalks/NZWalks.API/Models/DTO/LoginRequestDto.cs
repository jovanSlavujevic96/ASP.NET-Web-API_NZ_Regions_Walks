using System.ComponentModel.DataAnnotations;

namespace NZWalks.API.Models.DTO
{
    public class LoginRequestDto
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        required public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        required public string Password { get; set; }
    }
}
