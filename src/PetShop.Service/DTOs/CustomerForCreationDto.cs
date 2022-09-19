using PetShop.Domain.Enums;

namespace PetShop.Service.DTOs
{
    public class CustomerForCreationDto
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public Gender Gender { get; set; }
    }
}
