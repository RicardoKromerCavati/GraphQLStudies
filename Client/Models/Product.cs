using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Client.Models;

public class Product
{
    [JsonPropertyName("name")]
    public string Name { get; set; }
    
    [JsonPropertyName("description")]
    public string Description { get; set; }
    
    [JsonPropertyName("price")]
    public decimal Price { get; set; }
    
    [JsonPropertyName("imageUrl")]
    public string ImageUrl { get; set; }

    public float Stock { get; set; }
    
    [JsonPropertyName("registerDate")]
    public string RegisterDate { get; set; }


    // public Category Category { get; set; }
    // public int CategoryId { get; set; }
}