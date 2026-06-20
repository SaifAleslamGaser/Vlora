using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vlora.Data;
using Vlora.Models.Domain;
using Vlora.Models.DTOs;
using Vlora.Repositories;

namespace Vlora.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoriesController(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await categoryRepository.GetAllAsync();
            return Ok(categories);
        }
        [HttpPost]
        public async Task<IActionResult> Create(AddCategoryRequestDto dto)
        {
            var category = new Category
            {
                Name = dto.Name
            };
            await categoryRepository.CreateAsync(category);
            return Ok(category);
        }
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var isDeleted = await categoryRepository.DeleteAsync(id);
            if (!isDeleted)
                return NotFound();
            return NoContent();
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var category = await categoryRepository.GetByIdAsync(id);
            if (category == null)
                return NotFound();
            return Ok(category);
        }
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, UpdateCategoryRequestDto dto)
        {
            var updatedCategory = await categoryRepository.UpdateAsync(id, dto);
            if (updatedCategory == null)
                return NotFound();
            return Ok(updatedCategory);
        }
}
}