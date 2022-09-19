using PetShop.Domain.Common;
using PetShop.Domain.Enums;

namespace PetShop.Domain.Entities
{
    public class Pet : Auditable
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Gender? Gender { get; set; }

        public long? CategoryId { get; set; }
        public Category Category { get; set; }


    }
}
