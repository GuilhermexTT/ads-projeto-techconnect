namespace TechConnectBackend.Models;

public class Inscricao
{
    public int Id { get; set; }
    public int ParticipanteId { get; set; }
    public Participante Participante { get; set; } = null!;
    public string Evento { get; set; } = string.Empty;
    public DateTime DataInscricao { get; set; } = DateTime.Now;
    public bool Participou { get; set; } = false;
    public ICollection<Certificado> Certificados { get; set; } = new List<Certificado>();
}