using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechConnectBackend.Models;

namespace TechConnectBackend.Controllers;

public class CertificadoController : Controller
{
    private readonly AppDbContext _context;

    public CertificadoController(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        return View(await _context.Certificados.Include(c => c.Inscricao).ThenInclude(i => i.Participante).ToListAsync());
    }

    public IActionResult Emitir(int inscricaoId)
    {
        var inscricao = _context.Inscricoes.Include(i => i.Participante).FirstOrDefault(i => i.Id == inscricaoId);
        if (inscricao == null || !inscricao.Participou)
        {
            return NotFound("Inscrição não encontrada ou participante não confirmou participação.");
        }
        ViewBag.Inscricao = inscricao;
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Emitir(Certificado certificado)
    {
        if (ModelState.IsValid)
        {
            _context.Add(certificado);
            await _context.SaveChangesAsync();
            return RedirectToAction("Area", "Participante", new { id = certificado.Inscricao.ParticipanteId });
        }
        var inscricao = _context.Inscricoes.Include(i => i.Participante).FirstOrDefault(i => i.Id == certificado.InscricaoId);
        ViewBag.Inscricao = inscricao;
        return View(certificado);
    }

    public async Task<IActionResult> Consultar(string codigo)
    {
        if (string.IsNullOrEmpty(codigo))
        {
            return View("Consultar");
        }
        var certificado = await _context.Certificados
            .Include(c => c.Inscricao)
            .ThenInclude(i => i.Participante)
            .FirstOrDefaultAsync(c => c.CodigoVerificacao == codigo);
        if (certificado == null)
        {
            return View("NaoEncontrado");
        }
        return View("Detalhes", certificado);
    }
}