using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechConnectBackend.Models;

namespace TechConnectBackend.Controllers;

public class AuthController : Controller
{
    private readonly AppDbContext _context;

    public AuthController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
        {
            ViewBag.Error = "Por favor, insira um email válido.";
            return View();
        }

        var participante = await _context.Participantes
            .Include(p => p.Inscricoes)
            .ThenInclude(i => i.Certificados)
            .FirstOrDefaultAsync(p => p.Email == email);

        if (participante == null)
        {
            ViewBag.Error = "Participante não encontrado. Verifique o email.";
            return View();
        }

        return RedirectToAction("Area", "Participante", new { id = participante.Id });
    }
}