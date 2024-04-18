using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using PhoenixWeb.Services;
using PhoenixWeb.ViewModels;

namespace PhoenixWeb.Controllers;

public class AuthController : Controller
{
    private readonly AuthService _service;
    public AuthController(AuthService service)
    {
        _service = service;
    }
    public IActionResult Index()
    {
        return RedirectToAction("Login");
    }

    [HttpGet("login")]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(AuthLoginVM model)
    {
        if (ModelState.IsValid)
        {
            try
            {
                AuthenticationTicket ticket = _service.GetTicket(model);
                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    ticket.Principal,
                    ticket.Properties
                );
                return RedirectToAction("Index", "Home");
            }
            catch (Exception exception)
            {
                ViewBag.Message = exception.Message;
                return View();
            }
        }
        return View();
    }

    [HttpGet("RegisterGuest")]
    public IActionResult RegisterGuest()
    {
        if (User?.Identity?.IsAuthenticated ?? false) return RedirectToAction("Index", "Home");

        return View();
    }

    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync();
        return RedirectToAction("Login");
    }

    [HttpPost("RegisterGuest")]
    public IActionResult RegisterGuest(AuthRegisterVM model)
    {
        model.Role = "Guest";
        if (ModelState.IsValid)
        {
            _service.InsertRegister(model);
            return RedirectToAction("Index");
        }
        model = _service.GetRegister();
        return View(model);
    }

    [HttpGet("access-denied")]
    public IActionResult Denied()
    {
        return View();
    }
}
