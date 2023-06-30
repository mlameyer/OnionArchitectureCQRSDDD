using System;
using VoucherService.Domain.SeedWork;

namespace VoucherService.Domain.VoucherAggregate
{
    public class Cost : Entity
    {
        public DateTime? Created { get; private init; }
        public string ItemDescription { get; private set; }
        public decimal UnitAmount { get; private set; }
        public decimal UnitQuantity { get; private set; }
        public bool IsTax { get; private set; }

        protected Cost() { }

        public Cost(string itemDescription, decimal unitAmount, decimal unitQuantity, bool isTax)
        {
            Created = DateTime.UtcNow;
            ItemDescription = itemDescription;
            UnitAmount = unitAmount;
            UnitQuantity = unitQuantity;
            IsTax = isTax;
        }

        public decimal GetCostTotal () 
        { 
            return UnitAmount * UnitQuantity; 
        }
    }
}
