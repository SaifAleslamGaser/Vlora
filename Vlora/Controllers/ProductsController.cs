using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.AspNetCore.Mvc;
using Vlora.Data;
using Vlora.Models.Domain;
using Vlora.Models.DTOs;
using Vlora.Repositories;
//using AutoMapper;

namespace Vlora.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        //private readonly IMapper mapper;
        private readonly IProductRepository productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
            //this.mapper = mapper;
        }
       
        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await productRepository.GetAllAsync();
            return Ok(products);
        }
        
        
        [HttpPost]
        public async Task<IActionResult> Create(AddProductRequestDto dto)
        {
            
            //var product = mapper.Map<Product>(dto);
            var product = new Product
            {
                Name = dto.Name,
                Description = dto.Description,
                Price = dto.Price,
                StockQuantity = dto.StockQuantity,
                CategoryId = dto.CategoryId
            };

            await productRepository.CreateAsync(product);

            return Ok(product);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var product = await productRepository.GetByIdAsync(id);

            if (product == null)
                return NotFound();

            return Ok(product);
        }


        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, UpdateProductRequestDto dto)
        {
            var updatedProduct = await productRepository.UpdateAsync(id, dto);
            if (updatedProduct == null)
                return NotFound();
            return Ok(updatedProduct);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await productRepository.DeleteAsync(id);

            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}
