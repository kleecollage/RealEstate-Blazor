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
    
    public async Task<IEnumerable<CategoryDTO>> GetAllCategories()
    {
        try
        {
            IEnumerable<CategoryDTO> categoriesDto = 
                _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDTO>>(_context.Categories);
            return (categoriesDto);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return null;
        }
    }

    public async Task<CategoryDTO> GetCategory(int categoryId)
    {
        try
        {
            CategoryDTO categoryDto = 
                _mapper.Map<Category, CategoryDTO>(await _context.Categories.FirstOrDefaultAsync(
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

    public async Task<CategoryDTO> CreateCategory(CategoryDTO categoryDto)
    {
        Category category = _mapper.Map<CategoryDTO, Category>(categoryDto);
        category.CreatedAt = DateTime.Now;
        var addCategory = await _context.Categories.AddAsync(category);
        return _mapper.Map<Category, CategoryDTO>(addCategory.Entity);
    }

    public async Task<CategoryDTO> UpdateCategory(int categoryId, CategoryDTO categoryDto)
    {
        try
        {
            if (categoryId == categoryDto.Id)
            {
                Category category = await _context.Categories.FindAsync(categoryId);
                Category categoryToUpdate = _mapper.Map<CategoryDTO, Category>(categoryDto, category);
                categoryToUpdate.UpdatedAt = DateTime.Now;
                var updatedCategory = _context.Categories.Update(categoryToUpdate);
                await _context.SaveChangesAsync();
                return _mapper.Map<Category, CategoryDTO>(updatedCategory.Entity);
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

    public async Task<CategoryDTO> ExistsNameCategory(string nameCategory)
    {
        try
        {
            CategoryDTO categoryDto = _mapper.Map<Category, CategoryDTO>(
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











