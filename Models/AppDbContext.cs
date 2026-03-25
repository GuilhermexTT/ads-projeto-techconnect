using Microsoft.EntityFrameworkCore;

namespace TechConnectBackend.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Participante> Participantes { get; set; }
    public DbSet<Inscricao> Inscricoes { get; set; }
    public DbSet<Certificado> Certificados { get; set; }
}