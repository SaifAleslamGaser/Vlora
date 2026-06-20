using Microsoft.EntityFrameworkCore;
using Vlora.Data;
using Vlora.Models.Domain;
using Vlora.Models.DTOs;

namespace Vlora.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly VloraDbContext dbContext;

        public ProductRepository(VloraDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<ProductDto>> GetAllAsync()
        {
            var products = await dbContext.Products
               .Include(x => x.Category)
               .ToListAsync();

            return products.Select(x => new ProductDto
            {
                Name = x.Name,
                Price = x.Price,
                CategoryName = x.Category.Name
            }).ToList();

        }
        public async Task<Product> CreateAsync(Product product)
        {
            await dbContext.Products.AddAsync(product);
            await dbContext.SaveChangesAsync();
            return product;
        }
        public async Task<ProductDto?> GetByIdAsync(Guid id)
        {
            var product = await dbContext.Products
                .Include(x => x.Category)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (product == null)
                return null;

            return new ProductDto
            {
                Name = product.Name,
                Price = product.Price,
                CategoryName = product.Category.Name
            };
        }

        public async Task<ProductDto> UpdateAsync(Guid id, UpdateProductRequestDto dto)
        {
            var product = await dbContext.Products
                .Include(x => x.Category)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (product == null)
                return null;
            product.Name = dto.Name;
            product.Price = dto.Price;
            product.CategoryId = dto.CategoryId;
            product.Description = dto.Description;
            product.StockQuantity = dto.StockQuantity;
            await dbContext.SaveChangesAsync();
            return new ProductDto
            {
                Name = product.Name,
                Price = product.Price,
                CategoryName = (await dbContext.Categories.FindAsync(product.CategoryId))?.Name
            };
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var product = await dbContext.Products
                .FirstOrDefaultAsync(x => x.Id == id);

            if (product == null)
                return false;

            dbContext.Products.Remove(product);
            await dbContext.SaveChangesAsync();

            return true;
        }

    }
}