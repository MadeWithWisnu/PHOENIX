using Microsoft.AspNetCore.Mvc;

namespace PhoenixWeb.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        ViewBag.PageTitle = "Dashboard";
        return View();
    }
}
