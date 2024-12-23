using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PropertiesServer.Data;
using PropertiesServer.Models;
using PropertiesServer.Models.DTO;
using PropertiesServer.Repository.IRepository;

namespace PropertiesServer.Repository;

public class CategoryRepository: ICategoryRepository
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public CategoryRepository(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<CategoryDto>> GetAllCategories()
    {
        try
        {
            IEnumerable<CategoryDto> categoriesDto = 
                _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDto>>(_context.Categories);
            return (categoriesDto);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return null;
        }
    }

    public async Task<CategoryDto> GetCategory(int categoryId)
    {
        try
        {
            CategoryDto categoryDto = 
                _mapper.Map<Category, CategoryDto>(await _context.Categories.FirstOrDefaultAsync(
                    c => c.Id == categoryId)
                );
            return (categoryDto);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return null;
        }
    }

    public async Task<CategoryDto> CreateCategory(CategoryDto categoryDto)
    {
        Category category = _mapper.Map<CategoryDto, Category>(categoryDto);
        category.CreatedAt = DateTime.Now;
        var addCategory = await _context.Categories.AddAsync(category);
        await _context.SaveChangesAsync();
        return _mapper.Map<Category, CategoryDto>(addCategory.Entity);
    }

    public async Task<CategoryDto> UpdateCategory(int categoryId, CategoryDto categoryDto)
    {
        try
        {
            if (categoryId == categoryDto.Id)
            {
                Category category = await _context.Categories.FindAsync(categoryId);
                Category categoryToUpdate = _mapper.Map<CategoryDto, Category>(categoryDto, category);
                categoryToUpdate.UpdatedAt = DateTime.Now;
                var updatedCategory = _context.Categories.Update(categoryToUpdate);
                await _context.SaveChangesAsync();
                return _mapper.Map<Category, CategoryDto>(updatedCategory.Entity);
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

    public async Task<CategoryDto> ExistsNameCategory(string nameCategory)
    {
        try
        {
            CategoryDto categoryDto = _mapper.Map<Category, CategoryDto>(
                await _context.Categories.FirstOrDefaultAsync(
                    c => c.NameCategory.ToLower().Trim() == nameCategory.ToLower().Trim())
            );
            return categoryDto;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return null;
        }
    }

    public async Task<int> DeleteCategory(int categoryId)
    {
        var category = await _context.Categories.FindAsync(categoryId);
        if (category != null)
        {
            _context.Categories.Remove(category);
            return await _context.SaveChangesAsync();
        }

        return 0;
    }
}











