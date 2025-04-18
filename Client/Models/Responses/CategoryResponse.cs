using System.Text.Json.Serialization;

namespace Client.Models.Responses;

public class CategoryResponse
{
    [JsonPropertyName("categories")]
    public List<Category> Categories { get; set; }
}