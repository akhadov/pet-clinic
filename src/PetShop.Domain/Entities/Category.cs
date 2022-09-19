using PetShop.Domain.Common;

namespace PetShop.Domain.Entities
{
    public class Category : Auditable
    {
        public string Name { get; set; }
    }
}
