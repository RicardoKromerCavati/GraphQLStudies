using System.Collections.ObjectModel;
using System.Text;
using System.Text.Json.Serialization;

namespace Client.Models;

public class Category
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("imageUrl")]
    public string ImageUrl { get; set; } = string.Empty;
    
    [JsonPropertyName("products")]
    public ICollection<Product> Products { get; set; } = new Collection<Product>();

    public override string ToString()
    {
        var stringBuilder = new StringBuilder();

        foreach (var product in Products)
        {
            stringBuilder.Append($"Name: {product.Name} - " +
                                 $"Description: {product.Description} - " +
                                 $"ImageUrl: {product.ImageUrl} - " +
                                 $"Price: {product.Price} - Stock: " +
                                 $"{product.Stock} - " +
                                 $"RegisterDate: {product.RegisterDate}\n");
        }
        
        return $"Name: {Name}\nImageUrl: {ImageUrl}\nProducts:\n{stringBuilder}";
    }
}