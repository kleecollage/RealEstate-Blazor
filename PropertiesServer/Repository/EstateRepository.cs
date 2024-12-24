using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PropertiesServer.Data;
using PropertiesServer.Models;
using PropertiesServer.Models.DTO;
using PropertiesServer.Repository.IRepository;

namespace PropertiesServer.Repository;

public class EstateRepository: IEstateRepository
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public EstateRepository(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<EstateDto>> GetAllEstates()
    {
        try
        {
            IEnumerable<EstateDto> estatesDto = 
                _mapper.Map<IEnumerable<Estate>, IEnumerable<EstateDto>>(_context.Estates);
            return (estatesDto);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return null;
        }
    }

    public async Task<EstateDto> GetEstate(int estateId)
    {
        try
        {
            EstateDto estateDto = 
                _mapper.Map<Estate, EstateDto>(await _context.Estates.FirstOrDefaultAsync(
                    c => c.Id == estateId)
                );
            return (estateDto);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return null;
        }
    }

    public async Task<EstateDto> CreateEstate(EstateDto estateDto)
    {
        Estate estate = _mapper.Map<EstateDto, Estate>(estateDto);
        estate.CreatedAt = DateTime.Now;
        var addEstate = await _context.Estates.AddAsync(estate);
        await _context.SaveChangesAsync();
        return _mapper.Map<Estate, EstateDto>(addEstate.Entity);
    }

    public async Task<EstateDto> UpdateEstate(int estateId, EstateDto estateDto)
    {
        try
        {
            if (estateId == estateDto.Id)
            {
                Estate estate = await _context.Estates.FindAsync(estateId);
                Estate estateToUpdate = _mapper.Map<EstateDto, Estate>(estateDto, estate);
                estateToUpdate.UpdatedAt = DateTime.Now;
                var updatedEstate = _context.Estates.Update(estateToUpdate);
                await _context.SaveChangesAsync();
                return _mapper.Map<Estate, EstateDto>(updatedEstate.Entity);
            }
            else // Invalid
                return null;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return null;
        }
    }

    public async Task<EstateDto> ExistsNameEstate(string nameEstate)
    {
        try
        {
            EstateDto estateDto = _mapper.Map<Estate, EstateDto>(
                await _context.Estates.FirstOrDefaultAsync(
                    c => c.EstateName.ToLower().Trim() == nameEstate.ToLower().Trim())
            );
            return estateDto;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return null;
        }
    }

    public async Task<int> DeleteEstate(int estateId)
    {
        var estate = await _context.Estates.FindAsync(estateId);
        if (estate != null)
        {
            _context.Estates.Remove(estate);
            return await _context.SaveChangesAsync();
        }

        return 0;
    }
}