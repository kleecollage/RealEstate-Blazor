using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace PropertiesServer.Models;

public class Estate
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    public string EstateName { get; set; }
    
    [Required]
    public string EstateDescription { get; set; }
    
    [Required]
    public int Area  { get; set; }
    
    [Required]
    public int Rooms { get; set; }

    [Required]
    public int Bathrooms { get; set; }
    
    [Required]
    public int ParkingLots {get; set;}
    
    [Required]
    public double Price { get; set; }

    [Required]
    public bool Active { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    
    public DateTime UpdatedAt { get; set; }
    
    // Relation 1:N Estate:Category
    public int CategoryId { get; set; }
    
    [ForeignKey("CategoryId")]
    public virtual Category Category { get; set; }
    
    // Relation 1:N Estate:EstateImage
    public virtual ICollection<EstateImage> EstateImages { get; set; }
}










