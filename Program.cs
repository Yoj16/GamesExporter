using GamesExporter.Services;

var jsonService = new JsonService();
var xmlService = new XmlService();
var printGames = new PrintGames();

var games = jsonService.ReadJson("/Users/joyheurtaux/Sites/ipi/linq/GamesExporter/GamesExporter/Json/games.json");

var running = true;

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
            string search = Console.ReadLine()!.ToLower();
            var searchResults = 
                from game in games
                where game.Name.Contains(search, StringComparison.CurrentCultureIgnoreCase)
                select game;
            printGames.PrintValues(searchResults);
            break;

        case "2":
            var sorted = 
                from game in games
                orderby game.Score descending
                select game;
            printGames.PrintValues(sorted);
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
            xmlService.ExportToXml(games, "/Users/joyheurtaux/Sites/ipi/linq/GamesExporter/GamesExporter/XML/games.xml");
            break;

        case "5":
            running = false;
            break;

        default:
            Console.WriteLine("Choix invalide.");
            break;
    }
}