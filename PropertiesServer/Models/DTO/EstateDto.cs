using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PropertiesServer.Models.DTO;

public class EstateDto
{
    [Key]
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Estate name is required")]
    [StringLength(30, MinimumLength = 5, ErrorMessage = "Estate name must be between 5 and 30 characters")]
    public string EstateName { get; set; }
    
    [Required(ErrorMessage = "Estate description is required")]
    [StringLength(300, MinimumLength = 20, ErrorMessage = "Estate description must be between 20 and 300 characters")]
    public string EstateDescription { get; set; }
    
    [Required(ErrorMessage = "Area of the estate is required")]
    [Range(1, 5000, ErrorMessage = "Area of the estate must be between 1 and 5000 square meters")]
    public int Area  { get; set; }
    
    [Required(ErrorMessage = "Number of rooms are required")]
    [Range(1, 10, ErrorMessage = "Must enter a valid number")]
    public int Rooms { get; set; }

    [Required(ErrorMessage = "Number of bathrooms are required")]
    [Range(1, 5, ErrorMessage = "Must enter a valid number")]
    public int Bathrooms { get; set; }
    
    [Required(ErrorMessage = "Number of parking lots are required")]
    [Range(1, 20, ErrorMessage = "Must enter a valid number")]
    public int ParkingLots {get; set;}
    
    [Required(ErrorMessage = "Price is required")]
    public double Price { get; set; }

    [Required]
    public bool Active { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    
    public DateTime UpdatedAt { get; set; }
    
    // Relation 1:N Estate:Category
    public int CategoryId { get; set; }
    
    public virtual ICollection<EstateImage> EstateImages { get; set; }
    public List<string> UrlImages { get; set; }
}