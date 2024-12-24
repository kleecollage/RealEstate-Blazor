using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PropertiesServer.Data;
using PropertiesServer.Models;
using PropertiesServer.Models.DTO;
using PropertiesServer.Repository.IRepository;

namespace PropertiesServer.Repository;

public class EstateImageRepository: IEstateImageRepository
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public EstateImageRepository(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<int> CreateEstateImage(EstateImageDto imageDto)
    {
        var image = _mapper.Map<EstateImageDto, EstateImage>(imageDto);
        await _context.EstateImages.AddAsync(image);
        return await _context.SaveChangesAsync();
    }

    public async Task<int> DeleteEstateImageByIdImage(int imageId)
    {
        var image = await _context.EstateImages.FindAsync(imageId);
        if (image != null) _context.EstateImages.Remove(image);
        return await _context.SaveChangesAsync();
    }

    public async Task<int> DeleteEstateImageByIdEstate(int estateId)
    {
        var imagesList = await _context.EstateImages.Where(i => i.Id == estateId).ToListAsync();
        _context.EstateImages.RemoveRange(imagesList);
        return await _context.SaveChangesAsync();
    }

    public async Task<int> DeleteEstateImageByUrl(string imageUrl)
    {
        var image = await _context.EstateImages.FirstOrDefaultAsync(
            i => i.ImageUrl.ToLower().Trim() == imageUrl.ToLower().Trim()
        );
        
        if (image == null) return 0;
        
        _context.EstateImages.Remove(image);
        return await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<EstateImageDto>> GetEstateImages(int estateId)
    {
        return _mapper.Map<IEnumerable<EstateImage>, IEnumerable<EstateImageDto>>(
            await _context.EstateImages.Where(i => i.Id == estateId).ToListAsync());
    }
}