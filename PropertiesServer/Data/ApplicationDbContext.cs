using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PropertiesServer.Models;

namespace PropertiesServer.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : IdentityDbContext<ApplicationUser>(options)
{
    // MODELS
    public DbSet<Category> Categories { get; set; }
    public DbSet<Estate> Estates { get; set; }
    
    public DbSet<EstateImage> EstateImages { get; set; }
}
