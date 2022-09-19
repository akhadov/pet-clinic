﻿using PetShop.Domain.Enums;

namespace PetShop.Domain.Common
{
    public abstract class Auditable
    {
        public long Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public ItemState ItemState { get; set; }

    }
}
