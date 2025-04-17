using System.Text.Json.Serialization;

namespace GamesExporter;

public class Game
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    
    [JsonPropertyName("name")] 
    public string Name { get; set; }
    
    [JsonPropertyName("amount")]
    public double Amount { get; set; }
    
    [JsonPropertyName("score")]
    public double Score { get; set; }
    
    [JsonPropertyName("release_date")]
    public string ReleaseDate { get; set; }
    
    [JsonPropertyName("editor")]
    public string Editor { get; set; }
}