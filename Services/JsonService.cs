using System.Text.Json;
using GamesExporter.Models;

namespace GamesExporter.Services;

public class JsonService
{
    public List<Game> ReadJson(string filePath)
    {
        try
        {
            using (var reader = new StreamReader(filePath))
            {
                var json = reader.ReadToEnd();
                return JsonSerializer.Deserialize<List<Game>>(json) ?? new List<Game>();
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Erreur : Le fichier JSON est introuvable.");
            return new List<Game>();
        }
        catch (JsonException)
        {
            Console.WriteLine("Erreur : Le fichier JSON est mal formaté.");
            return new List<Game>();
        }
    }
}