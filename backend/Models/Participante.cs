namespace TechConnectBackend.Models;

public class Participante : Pessoa
{
    public string Cpf { get; set; } = string.Empty;
    public string Instituicao { get; set; } = string.Empty;
    public ICollection<Inscricao> Inscricoes { get; set; } = new List<Inscricao>();
}