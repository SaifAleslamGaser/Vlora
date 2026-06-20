using Microsoft.EntityFrameworkCore;
using Vlora.Data;
using Vlora.Models.Domain;
using Vlora.Models.DTOs;

namespace Vlora.Repositories
{
    public class CategoryRepository : ICategoryRepository{
        private readonly VloraDbContext dbContext;

        public CategoryRepository(VloraDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<Category>> GetAllAsync()
        {
            return await dbContext.Categories.ToListAsync();
        }




        public async Task<Category> CreateAsync(Category category)
        {
            await dbContext.Categories.AddAsync(category);
            await dbContext.SaveChangesAsync();
            return category;
        }



        public async Task<CategoryDto?> GetByIdAsync(Guid id)
        {
            var category = await dbContext.Categories.FirstOrDefaultAsync(x => x.Id == id);

            if (category == null)
                return null;

            return new CategoryDto
            {
                Name = category.Name
               
            };
        }



        public async Task<CategoryDto> UpdateAsync(Guid id, UpdateCategoryRequestDto dto)
        {
            var category = await dbContext.Categories.FirstOrDefaultAsync(x => x.Id == id);
            if (category == null)
                return null;
            category.Name = dto.Name;
           
            await dbContext.SaveChangesAsync();
            return new CategoryDto
            {
                Name = category.Name
            };
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var category = await dbContext.Categories
                .FirstOrDefaultAsync(x => x.Id == id);

            if ( category == null)
                return false;

            dbContext.Categories.Remove(category);
            await dbContext.SaveChangesAsync();

            return true;
        }
    }
}
