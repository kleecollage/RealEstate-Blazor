using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PropertiesServer.Models.DTO;

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
    
    // Relation N:1 Category:Estate
    public virtual ICollection<Estate> Estates { get; set; }
}