namespace PetShop.Service.DTOs
{
    public class OrderPetForCreationDto
    {
        public int Quantity { get; set; }
        public long PetId { get; set; }
        public long CustomerId { get; set; }
    }
}