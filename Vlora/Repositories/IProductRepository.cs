using Vlora.Models.Domain;
using Vlora.Models.DTOs;

namespace Vlora.Repositories
{
    public interface IProductRepository
    {
        Task<List<ProductDto>> GetAllAsync();
        Task<Product> CreateAsync(Product product);
        Task<ProductDto?> GetByIdAsync(Guid id);
        Task<ProductDto?> UpdateAsync(Guid id, UpdateProductRequestDto dto);
        Task<bool> DeleteAsync(Guid id);
    }
}
