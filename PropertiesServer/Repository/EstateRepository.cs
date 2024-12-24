using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PropertiesServer.Data;
using PropertiesServer.Models;
using PropertiesServer.Models.DTO;
using PropertiesServer.Repository.IRepository;

namespace PropertiesServer.Repository;

public class EstateRepository (ApplicationDbContext context, IMapper mapper): IEstateRepository
{
    public async Task<IEnumerable<EstateDto>> GetAllEstates()
    {
        /* VERSION 1
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
        }*/
        try
        {
            IEnumerable<EstateDto> estatesDto = 
                mapper.Map<IEnumerable<Estate>, IEnumerable<EstateDto>>
                    (context.Estates.Include(e => e.EstateImages)
                        .Include(e => e.Category));
            return estatesDto;
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
                mapper.Map<Estate, EstateDto>(await context.Estates.FirstOrDefaultAsync(
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
        Estate estate = mapper.Map<EstateDto, Estate>(estateDto);
        estate.CreatedAt = DateTime.Now;
        var addEstate = await context.Estates.AddAsync(estate);
        await context.SaveChangesAsync();
        return mapper.Map<Estate, EstateDto>(addEstate.Entity);
    }

    public async Task<EstateDto> UpdateEstate(int estateId, EstateDto estateDto)
    {
        try
        {
            if (estateId == estateDto.Id)
            {
                Estate estate = await context.Estates.FindAsync(estateId);
                Estate estateToUpdate = mapper.Map<EstateDto, Estate>(estateDto, estate);
                estateToUpdate.UpdatedAt = DateTime.Now;
                var updatedEstate = context.Estates.Update(estateToUpdate);
                await context.SaveChangesAsync();
                return mapper.Map<Estate, EstateDto>(updatedEstate.Entity);
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
            EstateDto estateDto = mapper.Map<Estate, EstateDto>(
                await context.Estates.FirstOrDefaultAsync(
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
        var estate = await context.Estates.FindAsync(estateId);
        if (estate != null)
        {
            var images = await context.EstateImages.Where(e => e.Id == estateId).ToListAsync();
            context.EstateImages.RemoveRange(images);
            context.Estates.Remove(estate);
            return await context.SaveChangesAsync();
        }

        return 0;
    }
}