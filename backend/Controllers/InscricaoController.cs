using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechConnectBackend.Models;

namespace TechConnectBackend.Controllers;

public class InscricaoController : Controller
{
    private readonly AppDbContext _context;

    public InscricaoController(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        return View(await _context.Inscricoes.Include(i => i.Participante).ToListAsync());
    }

    public IActionResult Create()
    {
        ViewBag.Participantes = _context.Participantes.ToList();
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreateFromForm(string name, string email, string cpf, string evento = "TechConnect 2026")
    {
        try
        {
            var participante = new Participante { Nome = name, Email = email, Cpf = cpf };
            _context.Add(participante);
            await _context.SaveChangesAsync();

            var inscricao = new Inscricao { ParticipanteId = participante.Id, Evento = evento };
            _context.Add(inscricao);
            await _context.SaveChangesAsync();

            return RedirectToAction("Area", "Participante", new { id = participante.Id });
        }
        catch (Exception ex)
        {
            // Registrar log de erro
            Console.Error.WriteLine($"Erro ao salvar inscrição: {ex.Message}");

            // Retornar mensagem amigável para a View
            ViewBag.ErrorMessage = "Ocorreu um erro ao processar sua inscrição. Por favor, tente novamente.";
            ViewBag.Participantes = _context.Participantes.ToList();
            return View("Create");
        }
    }

    [HttpPost]
    public async Task<IActionResult> MarcarParticipacao(int id)
    {
        var inscricao = await _context.Inscricoes.FindAsync(id);
        if (inscricao != null)
        {
            inscricao.Participou = true;
            await _context.SaveChangesAsync();
        }
        return RedirectToAction(nameof(Index));
    }
}