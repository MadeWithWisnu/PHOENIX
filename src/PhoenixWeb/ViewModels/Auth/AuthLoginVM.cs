using System.ComponentModel.DataAnnotations;

namespace PhoenixWeb.ViewModels;

public class AuthLoginVM
{
    [Required(ErrorMessage = "{0} cannot be empty")]
    public string Username { get; set; } = null!;

    [Required(ErrorMessage = "{0} cannot be empty")]
    public string Password { get; set; } = null!;
    public string Role { get; set; } = null!;
}
