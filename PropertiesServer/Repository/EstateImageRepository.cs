using AutoMapper;
using PropertiesServer.Data;
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
    public Task<int> CreateEstateImage(EstateImageDto imageDto)
    {
        throw new NotImplementedException();
    }

    public Task<int> DeleteEstateImageByIdImage(int imageId)
    {
        throw new NotImplementedException();
    }

    public Task<int> DeleteEstateImageByIdEstate(int estateId)
    {
        throw new NotImplementedException();
    }

    public Task<int> DeleteEstateImageByUrl(string url)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<EstateImageDto>> GetEstateImages(int estateId)
    {
        throw new NotImplementedException();
    }
}