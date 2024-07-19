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

        public async Task<IActionResult> EditarDocumento(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var documento = await _context.Documentos.FirstAsync(x => x.Id == id);

            return View(documento);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
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


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditarDocumento(Documento documentoEditado)
        {
            if (ModelState.IsValid)
            {
                var documento = await _context.Documentos.FirstAsync(x => x.Id == documentoEditado.Id);

                documento.Titulo = documentoEditado.Titulo;
                documento.Conteudo = documentoEditado.Conteudo;
                documento.DataAlteracao = DateTime.Now;

                _context.Update(documento);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View();
        }

    }
}
