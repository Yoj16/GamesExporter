
using System.Text.Json;
using System.Xml.Linq;
using GamesExporter;

List<Game> games;

using (var reader = new StreamReader("/Users/joyheurtaux/Sites/ipi/linq/GamesExporter/GamesExporter/games.json"))
{
    var json = reader.ReadToEnd();
    games = JsonSerializer.Deserialize<List<Game>>(json);
}

bool running = true;

while (running)
{
    Console.WriteLine("\n1. Rechercher par nom");
    Console.WriteLine("2. Trier par score");
    Console.WriteLine("3. Grouper par éditeur");
    Console.WriteLine("4. Exporter en XML");
    Console.WriteLine("5. Quitter");
    Console.Write("Choix : ");
    var input = Console.ReadLine();

    switch (input)
    {
        case "1":
            Console.Write("Nom à chercher : ");
            string search = Console.ReadLine().ToLower();
            var searchResults = 
                from game in games
                where game.Name.ToLower().Contains(search)
                select game;
            PrintGames(searchResults);
            break;

        case "2":
            var sorted = 
                from game in games
                orderby game.Score descending
                select game;
            PrintGames(sorted);
            break;

        case "3":
            var grouped = 
                from game in games
                group game by game.Editor into editor
                select editor;
            foreach (var group in grouped)
            {
                Console.WriteLine($"\nÉditeur: {group.Key}");
                foreach (var game in group)
                {
                    Console.WriteLine($" - {game.Name} ({game.Score})");
                }
            }
            break;

        case "4":
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
            xml.Save("/Users/joyheurtaux/Sites/ipi/linq/GamesExporter/GamesExporter/games_export.xml");
            Console.WriteLine("Export XML terminé !");
            break;

        case "5":
            running = false;
            break;

        default:
            Console.WriteLine("Choix invalide.");
            break;
    }
}

void PrintGames(IEnumerable<Game> list)
{
    foreach (var game in list)
    {
        Console.WriteLine($"{game.Name} | {game.Score}/10 | {game.Editor} | {game.ReleaseDate}");
    }
}