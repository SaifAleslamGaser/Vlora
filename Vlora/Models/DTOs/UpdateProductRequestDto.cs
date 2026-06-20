using Vlora.Models.Domain;

namespace Vlora.Models.DTOs
{
    public class UpdateProductRequestDto
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int StockQuantity { get; set; }

        public Guid CategoryId { get; set; }


    }
}
