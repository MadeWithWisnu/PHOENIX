using System.ComponentModel.DataAnnotations;

namespace PhoenixWeb.ViewModels.Guest;

public class RegisterVM
{
    [Required(ErrorMessage = "{0} cannot be empty")]
    public string Username { get; set; } = null!;

    [Required(ErrorMessage = "{0} cannot be empty")]
    public string Password { get; set; } = null!;

    [Required(ErrorMessage = "{0} cannot be empty")]
    [Compare("Password", ErrorMessage = "Paassword does not match")]
    public string ConfirmPassword { get; set; } = null!;

    [Required(ErrorMessage = "{0} cannot be empty")]
    public string FirstName { get; set; } = null!;
    public string MiddleName { get; set; }
    public string LastName { get; set; }

    [Required(ErrorMessage = "{0} cannot be empty")]
    public DateTime BirthDate { get; set; }

    [Required(ErrorMessage = "{0} cannot be empty")]
    public string Gender { get; set; } = null!;

    [Required(ErrorMessage = "{0} cannot be empty")]
    public string Citizenship { get; set; } = null!;

    public string IdNumber { get; set; } = null!;
}
