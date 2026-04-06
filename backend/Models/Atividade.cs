namespace TechConnectBackend.Models;

public class Atividade
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public int DuracaoMinutos { get; set; }
    public int EventoId { get; set; }
    public Evento? Evento { get; set; }
}