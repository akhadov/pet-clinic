using PetShop.Domain.Enums;

namespace PetShop.Service.DTOs
{
    public class PetForCreationDto
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Gender? Gender { get; set; }
        public long? CategoryId { get; set; }
    }
}
