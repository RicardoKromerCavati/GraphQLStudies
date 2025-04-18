using System.ComponentModel.DataAnnotations;

namespace GraphQLSample.Entities;

public class Product
{
    public int Id { get; set; }

    [Required]
    [StringLength(80)]
    public string Name { get; set; }

    [Required]
    [StringLength(300)]
    public string Description { get; set; }
    
    [Required]
    public decimal Price { get; set; }

    [Required]
    [StringLength(300)]
    public string ImageUrl { get; set; }

    public float Stock { get; set; }
    public DateTime RegisterDate { get; set; }


    // public Category Category { get; set; }
    // public int CategoryId { get; set; }
}