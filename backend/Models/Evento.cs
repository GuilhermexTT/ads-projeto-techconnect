namespace TechConnectBackend.Models;

public class Evento
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public DateTime DataInicio { get; set; }
    public DateTime DataFim { get; set; }
    public string Local { get; set; } = string.Empty;
    public ICollection<Atividade> Atividades { get; set; } = new List<Atividade>();
}