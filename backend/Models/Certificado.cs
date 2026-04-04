namespace TechConnectBackend.Models;

public class Certificado
{
    public int Id { get; set; }
    public int InscricaoId { get; set; }
    public Inscricao Inscricao { get; set; } = null!;
    public string Tipo { get; set; } = string.Empty; // e.g., "Semanas Acadêmicas", "Jornadas", "Hackathons"
    public int HorasAcademicas { get; set; }
    public string? Descricao { get; set; } // Descrição opcional do certificado
    public DateTime DataEmissao { get; set; } = DateTime.Now;
    public string CodigoVerificacao { get; set; } = Guid.NewGuid().ToString();
}