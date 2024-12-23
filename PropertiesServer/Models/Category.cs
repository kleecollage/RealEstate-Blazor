using System.ComponentModel.DataAnnotations;

namespace PropertiesServer.Models;

public class Category
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string NameCategory { get; set; }

    public string Description { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public DateTime UpdatedAt { get; set; }
}