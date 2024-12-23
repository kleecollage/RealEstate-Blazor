using PropertiesServer.Models.DTO;

namespace PropertiesServer.Repository.IRepository;

public interface ICategoryRepository
{
    public Task<IEnumerable<CategoryDTO>> GetAllCategories();
    public Task<CategoryDTO> GetCategory(int categoryId);
    public Task<CategoryDTO> CreateCategory(CategoryDTO categoryDto);
    public Task<CategoryDTO> UpdateCategory(int categoryId, CategoryDTO categoryDto);
    public Task<CategoryDTO> ExistsNameCategory(string nameCategory);
    public Task<int> DeleteCategory(int categoryId);
    // public Task<IEnumerable<CategoryDTO>> GetDropDownCategories(int categoryId);
}