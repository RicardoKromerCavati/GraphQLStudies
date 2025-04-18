using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace Client.Models;

public class Category
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("imageUrl")]
    public string ImageUrl { get; set; } = string.Empty;
    
    public ICollection<Product> Products { get; set; } = new Collection<Product>();
}