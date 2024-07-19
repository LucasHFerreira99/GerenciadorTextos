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

        public IActionResult CriarDocumento()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> CriarDocumento(Documento documentoRecebido)
        {
            if (ModelState.IsValid)
            {
                _context.Add(documentoRecebido);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(documentoRecebido);
        }
  
    }
}
