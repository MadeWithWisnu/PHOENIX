using Microsoft.AspNetCore.Mvc;

namespace PhoenixWeb.Controllers;

public class AdministratorController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        ViewBag.PageTitle = "Admin";
        return View();
    }
}
