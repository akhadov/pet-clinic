using PetShop.Domain.Common;

namespace PetShop.Domain.Entities
{
    public class OrderPet : Auditable
    {
        public int Quantity { get; set; }
        public long PetId { get; set; }
        public Pet Pet { get; set; }
        public long CustomerId { get; set; }
        public Category Customer { get; set; }
    }
}
