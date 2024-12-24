using PropertiesServer.Models.DTO;

namespace PropertiesServer.Repository.IRepository;

public interface IEstateRepository
{
    public Task<IEnumerable<EstateDto>> GetAllEstates();
    public Task<EstateDto> GetEstate(int estateId);
    public Task<EstateDto> CreateEstate(EstateDto estateDto);
    public Task<EstateDto> UpdateEstate(int estateId, EstateDto estateDto);
    public Task<EstateDto> ExistsNameEstate(string nameEstate);
    public Task<int> DeleteEstate(int estateId);
}