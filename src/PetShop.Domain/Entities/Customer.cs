using PetShop.Domain.Common;
using PetShop.Domain.Enums;

namespace PetShop.Domain.Entities
{
    public class Customer : Auditable
    {
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
    }
}
