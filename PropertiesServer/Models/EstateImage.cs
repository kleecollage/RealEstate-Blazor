using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace PropertiesServer.Models;

public class EstateImage
{
    [Key]
    public int Id { get; set; }
    
    public string ImageUrl { get; set; }

    public int EstateId { get; set; }
    
    [ForeignKey("EstateId")]
    public virtual Estate Estate { get; set; }
}