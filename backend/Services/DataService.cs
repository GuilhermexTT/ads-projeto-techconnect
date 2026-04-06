using System.Text.Json;
using System.Text.Json.Serialization;
using TechConnectBackend.Models;

namespace TechConnectBackend.Services;

public class DataService
{
    private readonly string _dataFolder;
    private readonly string _dataFilePath;

    public DataService()
    {
        _dataFolder = Path.Combine(AppContext.BaseDirectory, "Data");
        _dataFilePath = Path.Combine(_dataFolder, "inscricoes.json");
    }

    public async Task<bool> SaveInscricoesAsync(List<Inscricao> inscricoes)
    {
        try
        {
            if (inscricoes is null)
            {
                throw new ArgumentNullException(nameof(inscricoes), "A lista de inscrições não pode ser nula.");
            }

            Directory.CreateDirectory(_dataFolder);

            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                ReferenceHandler = ReferenceHandler.IgnoreCycles
            };

            string json = JsonSerializer.Serialize(inscricoes, options);
            await File.WriteAllTextAsync(_dataFilePath, json);
            return true;
        }
        catch (IOException ioEx)
        {
            // Tratar falhas de disco ou bloqueio do arquivo
            Console.Error.WriteLine($"Erro de I/O ao salvar inscrições: {ioEx.Message}");
            return false;
        }
        catch (JsonException jsonEx)
        {
            // Tratar entradas inválidas ou falha na serialização
            Console.Error.WriteLine($"Erro ao serializar inscrições: {jsonEx.Message}");
            return false;
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Erro inesperado ao salvar inscrições: {ex.Message}");
            return false;
        }
    }

    public async Task<List<Inscricao>> LoadInscricoesAsync()
    {
        try
        {
            if (!File.Exists(_dataFilePath))
            {
                return new List<Inscricao>();
            }

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                ReferenceHandler = ReferenceHandler.IgnoreCycles
            };

            string json = await File.ReadAllTextAsync(_dataFilePath);
            return JsonSerializer.Deserialize<List<Inscricao>>(json, options) ?? new List<Inscricao>();
        }
        catch (IOException ioEx)
        {
            // Tratar falhas de disco ou bloqueio do arquivo
            Console.Error.WriteLine($"Erro de I/O ao carregar inscrições: {ioEx.Message}");
            return new List<Inscricao>();
        }
        catch (JsonException jsonEx)
        {
            // Tratar entradas inválidas ou falha na desserialização
            Console.Error.WriteLine($"Erro ao desserializar inscrições: {jsonEx.Message}");
            return new List<Inscricao>();
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Erro inesperado ao carregar inscrições: {ex.Message}");
            return new List<Inscricao>();
        }
    }

    public static List<Inscricao> FiltrarParticipantesPresentesOrdenados(List<Inscricao> inscricoes)
    {
        if (inscricoes is null)
        {
            return new List<Inscricao>();
        }

        return inscricoes
            .Where(i => i.Participou && i.Participante is not null)
            .OrderBy(i => i.Participante!.Nome)
            .ToList();
    }
}
