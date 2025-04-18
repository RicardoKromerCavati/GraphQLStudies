using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace GraphQLSample.Entities;

public class Category
{
    public Category()
    {
        Products = new Collection<Product>();
    }

    public int Id { get; set; }
    
    [Required]
    [MaxLength(80)]
    public string Name { get; set; }

    [Required] [MaxLength(80)] public string ImageUrl { get; set; }

    public IList<Product> Products { get; set; }
}