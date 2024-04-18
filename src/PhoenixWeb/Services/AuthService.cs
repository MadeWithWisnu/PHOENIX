using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc.Rendering;
using PhoenixBussiness.Interfaces;
using PhoenixDataAccess.Models;
using PhoenixWeb.ViewModels;

namespace PhoenixWeb.Services;

public class AuthService
{
    private readonly IAdministratorRepository _repositoryAdmin;
    private readonly IGuestRepository _repositoryGuest;

    public AuthService(IAdministratorRepository repositoryAdmin, IGuestRepository repositoryGuest)
    {
        _repositoryAdmin = repositoryAdmin;
        _repositoryGuest = repositoryGuest;
    }

    private ClaimsPrincipal GetPrincipal(AuthLoginVM model)
    {
        List<Claim> claims = new List<Claim>{
            new Claim(ClaimTypes.Name, model.Username),
            new Claim(ClaimTypes.Role, model.Role),
        };
        ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        return new ClaimsPrincipal(identity);
    }

    private AuthenticationTicket GetAuthenticationTicket(ClaimsPrincipal principal)
    {
        AuthenticationProperties authenticationProperties = new AuthenticationProperties
        {
            IssuedUtc = DateTime.Now,
            ExpiresUtc = DateTime.Now.AddMinutes(30),
            AllowRefresh = false
        };
        return new AuthenticationTicket(principal, authenticationProperties, CookieAuthenticationDefaults.AuthenticationScheme);
    }

    public AuthenticationTicket GetTicket(AuthLoginVM model)
    {
        Administrator administrator = _repositoryAdmin.GetByUsername(model.Username);
        if (!BCrypt.Net.BCrypt.Verify(model.Password, administrator.Password)) //throw new UsernamePasswordException("Password tidak terdaftar");
        if (administrator.JobTitle!=model.Role) throw new Exception("Role tidak sesuai");

        ClaimsPrincipal principal = GetPrincipal(model);
        return GetAuthenticationTicket(principal);
    }

    private List<SelectListItem> GetRoles()
    {
        return new List<SelectListItem>{
            new SelectListItem{
                Text = "Admin",
                Value = "admin"
            },
            new SelectListItem{
                Text = "Guest",
                Value = "guest"
            }
        };
    }

    public AuthRegisterVM GetRegister()
    {
        return new AuthRegisterVM
        {
            Roles = GetRoles()
        };
    }

    public void InsertRegister(AuthRegisterVM model)
    {
        Administrator administrator = new Administrator
        {
            Username = model.Username,
            Password = BCrypt.Net.BCrypt.HashPassword(model.Password),
            JobTitle = model.Role
        };
        _repositoryAdmin.Insert(administrator);
        
        if(model.Role == "Guest")
        {
            var guestModel = new Guest()
            {
                Username = model.Username,
                FirstName = model.FirstName,
                MiddleName = model.MiddleName,
                LastName = model.LastName,
                BirthDate = model.BirthDate,
                Gender = model.Gender,
                Citizenship = model.Citizenship,
                IdNumber = model.IdNumber
            };
            _repositoryGuest.Insert(guestModel);
        }
    }
}
