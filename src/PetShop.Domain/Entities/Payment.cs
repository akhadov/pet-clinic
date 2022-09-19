using PetShop.Domain.Common;
using PetShop.Domain.Enums;

namespace PetShop.Domain.Entities
{
    public class Payment : Auditable
    {
        public PaymentType Type { get; set; }
        public decimal PaidPrice { get; set; }

        public long PetId { get; set; }
        public Pet Pet { get; set; }
    }
}
