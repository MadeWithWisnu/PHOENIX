using System.ComponentModel.DataAnnotations;

namespace PhoenixWeb.ViewModels.Administrator;

public class AdminVM
{
    [Required(ErrorMessage = "{0} cannot be empty")]
    public string Username { get; set; } = null!;

    [Required(ErrorMessage = "{0} cannot be empty")]
    public string Password { get; set; } = null!;

    [Required(ErrorMessage = "{0} cannot be empty")]
    [Compare("Password", ErrorMessage = "Password does not match")]
    public string ConfirmPassword { get; set; } = null!;

    [Required(ErrorMessage = "{0} cannot be empty")]
    public string JobTitle { get; set; } = null!;
}
