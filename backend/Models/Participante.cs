namespace TechConnectBackend.Models;

public class Participante
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Cpf { get; set; } = string.Empty;
    public string Instituicao { get; set; } = string.Empty;
    public ICollection<Inscricao> Inscricoes { get; set; } = new List<Inscricao>();
}