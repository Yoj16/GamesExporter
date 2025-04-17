using System.Text.Json;
using System.Xml.Linq;
using GamesExporter.Models;

namespace GamesExporter.Services;

public class PrintGames
{
    public void PrintValues(IEnumerable<Game> list)
    {
        foreach (var game in list)
        {
            Console.WriteLine($"Nom du jeu: {game.Name} - Note: {game.Score}/10 - Editeur: {game.Editor} - Date de sortie: {game.ReleaseDate}");
        }
    }
}