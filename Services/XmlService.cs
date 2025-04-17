using System.Text.Json;
using System.Xml.Linq;
using GamesExporter.Models;

namespace GamesExporter.Services;

public class XmlService
{
    public void ExportToXml(List<Game> games, string filePath)
    {
        var xml = new XElement("Games",
            from game in games
            select new XElement("Game",
                new XElement("Id", game.Id),
                new XElement("Name", game.Name),
                new XElement("Amount", game.Amount),
                new XElement("Score", game.Score),
                new XElement("ReleaseDate", game.ReleaseDate),
                new XElement("Editor", game.Editor)
            )
        );
        xml.Save(filePath);
        Console.WriteLine("Export XML terminé !");
    }
}