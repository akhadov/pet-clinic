using PetShop.Domain.Enums;

namespace PetShop.Service.DTOs
{
    public class PaymentForCreationDto
    {
        public PaymentType Type { get; set; }
        public decimal PaidPrice { get; set; }
        public long PetId { get; set; }
    }
}
