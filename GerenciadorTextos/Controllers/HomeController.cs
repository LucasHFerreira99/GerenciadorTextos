using GerenciadorTextos.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GerenciadorTextos.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

  
    }
}
