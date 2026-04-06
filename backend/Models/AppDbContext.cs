using Microsoft.EntityFrameworkCore;

namespace TechConnectBackend.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Participante> Participantes { get; set; }
    public DbSet<Inscricao> Inscricoes { get; set; }
    public DbSet<Certificado> Certificados { get; set; }
    public DbSet<Evento> Eventos { get; set; }
    public DbSet<Atividade> Atividades { get; set; }
    public DbSet<UsuarioAdministrador> UsuariosAdministradores { get; set; }
}