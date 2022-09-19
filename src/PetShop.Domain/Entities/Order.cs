using PetShop.Domain.Common;

namespace PetShop.Domain.Entities
{
    public class Order : Auditable
    {
        public int TotalPrice { get; set; }
        public bool IsPaid { get; set; } = false;
        public ICollection<OrderPet> OrderPets { get; set; }

        public long CustomerId { get; set; }
        public Category Customer { get; set; }
    }
}
