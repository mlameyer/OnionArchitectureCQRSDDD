using System;
using VoucherService.Domain.SeedWork;

namespace VoucherService.Domain.VoucherAggregate
{
    public class Cost : Entity
    {
        private Guid _id;
        public DateTime? AddedDateTime { get; private init; }
        public string ItemDescription { get; private set; }
        public decimal UnitAmount { get; private set; }
        public decimal UnitQuantity { get; private set; }
        public bool IsTax { get; private set; }

        public static Cost NewCost()
        {
            Cost cost = new Cost();
            cost.Id = Guid.NewGuid();
            return cost;
        }

        protected Cost() { }

        public Cost(string itemDescription, decimal unitAmount, decimal unitQuantity, bool isTax)
        {
            AddedDateTime = DateTime.UtcNow;
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
