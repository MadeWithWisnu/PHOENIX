using Microsoft.AspNetCore.Mvc;
using PhoenixWeb.Services;
using PhoenixWeb.ViewModels;
using PhoenixWeb.ViewModels.Guest;

namespace PhoenixWeb.Controllers;

public class GuestController : Controller
{
    private readonly GuestService _service;

    public GuestController(GuestService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Register(RegisterVM viewModel)
    {
        if(ModelState.IsValid)
        {

            _service.Insert(viewModel);
            return RedirectToAction("Login", "Auth");
        }
        return View();
    }
}
