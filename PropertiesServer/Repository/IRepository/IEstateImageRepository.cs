using PropertiesServer.Models.DTO;

namespace PropertiesServer.Repository.IRepository;

public interface IEstateImageRepository
{
    public Task<int> CreateEstateImage(EstateImageDto imageDto);
    public Task<int> DeleteEstateImageByIdImage(int imageId);
    public Task<int> DeleteEstateImageByIdEstate(int estateId);
    public Task<int> DeleteEstateImageByUrl(string url);
    public Task<IEnumerable<EstateImageDto>> GetEstateImages(int estateId);
}