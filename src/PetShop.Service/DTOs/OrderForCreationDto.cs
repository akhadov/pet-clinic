namespace PetShop.Service.DTOs
{
    public class OrderForCreationDto
    {
        public int TotalPrice { get; set; }
        public bool IsPaid { get; set; } = false;
        public long CustomerId { get; set; }
        public ICollection<OrderPetForCreationDto> OrderPets { get; set; }
    }
}
