using PropertiesServer.Models.DTO;

namespace PropertiesServer.Repository.IRepository;

public interface ICategoryRepository
{
    public Task<IEnumerable<CategoryDto>> GetAllCategories();
    public Task<CategoryDto> GetCategory(int categoryId);
    public Task<CategoryDto> CreateCategory(CategoryDto categoryDto);
    public Task<CategoryDto> UpdateCategory(int categoryId, CategoryDto categoryDto);
    public Task<CategoryDto> ExistsNameCategory(string nameCategory);
    public Task<int> DeleteCategory(int categoryId);
    // public Task<IEnumerable<CategoryDTO>> GetDropDownCategories(int categoryId);
}