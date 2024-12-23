using System.ComponentModel.DataAnnotations;

namespace PropertiesServer.Models.DTO;

public class CategoryDTO
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Category name is required")]
    public string NameCategory { get; set; }
    
    public string Description { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public DateTime UpdatedAt { get; set; }
}