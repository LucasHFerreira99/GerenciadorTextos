using GerenciadorTextos.Data;
using GerenciadorTextos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace GerenciadorTextos.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {

            var documentos = await _context.Documentos.ToListAsync();
            return View(documentos);
        }

  
    }
}
