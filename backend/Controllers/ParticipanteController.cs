using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechConnectBackend.Models;

namespace TechConnectBackend.Controllers;

public class ParticipanteController : Controller
{
    private readonly AppDbContext _context;

    public ParticipanteController(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        return View(await _context.Participantes.ToListAsync());
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Participante participante)
    {
        if (ModelState.IsValid)
        {
            _context.Add(participante);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(participante);
    }

    public async Task<IActionResult> Area(int id)
    {
        var participante = await _context.Participantes
            .Include(p => p.Inscricoes)
            .ThenInclude(i => i.Certificados)
            .FirstOrDefaultAsync(p => p.Id == id);
        if (participante == null)
        {
            return NotFound();
        }

        // Simula que todas as inscrições foram concluídas (100%)
        // Para fins de demonstração, marca como participado
        foreach (var inscricao in participante.Inscricoes)
        {
            inscricao.Participou = true;
        }

        var mensagens = new[]
        {
            "Não se trata do que você tem ou não tem. Trata-se do que você faz com o que tem. - Stephen Curry",
            "Quando você conhece a sensação de fracasso, a determinação persegue o sucesso. - Kobe Bryant",
            "Eu posso aceitar o fracasso, todo mundo falha em alguma coisa. Mas eu não posso aceitar não tentar. - Michael Jordan",
            "O sucesso não é um acidente, o sucesso é uma escolha. - Stephen Curry",
            "Algumas pessoas gostariam que algo acontecesse. Algumas desejam que aconteça. E outras fazem acontecer. - Michael Jordan",
            "Nem sempre teremos os melhores lugares para treinar. Mas treinaremos em qualquer lugar, para sermos melhores. - Patrícia Eickhoff",
            "Um homem pode ser fundamental numa equipe, mas um homem não faz uma equipe. - Kareem Abdul-Jabbar",
            "O trabalho árduo vence o talento, quando o talento não trabalhou arduamente. - Kevin Durant",
            "Procure alcançar grandes objetivos e não pare até conseguir. - Bo Jackson"
        };

        var random = new Random();
        ViewBag.MensagemMotivacional = mensagens[random.Next(mensagens.Length)];
        ViewBag.TodasMensagens = mensagens;

        return View(participante);
    }
}