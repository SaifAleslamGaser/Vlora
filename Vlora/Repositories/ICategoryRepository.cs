using Vlora.Models.Domain;
using Vlora.Models.DTOs;

namespace Vlora.Repositories
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAllAsync();
        Task<Category> CreateAsync(Category category);
        Task<CategoryDto?> GetByIdAsync(Guid id);
        Task<CategoryDto?> UpdateAsync(Guid id, UpdateCategoryRequestDto dto);
        Task<bool> DeleteAsync(Guid id);
    }
}
