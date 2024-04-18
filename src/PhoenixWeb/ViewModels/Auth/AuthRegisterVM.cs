using Microsoft.AspNetCore.Mvc.Rendering;

namespace PhoenixWeb.ViewModels;

public class AuthRegisterVM
{
    public string Username { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public string Gender { get; set; } = null!;
    public string Citizenship { get; set; }
    public string IdNumber { get; set; }
    public string? Role { get; set; }
    public List<SelectListItem> Roles { get; set; } = new List<SelectListItem>();
    public List<SelectListItem> Genders { get; set; } = new List<SelectListItem>();
}
