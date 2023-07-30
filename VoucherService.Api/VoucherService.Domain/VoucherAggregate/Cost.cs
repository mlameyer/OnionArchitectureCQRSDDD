using System;
using System.Collections.Generic;
using VoucherService.Domain.SeedWork;

namespace VoucherService.Domain.VoucherAggregate
{
    public class Cost : Entity
    {
        public DateTime? AddedDateTime { get; private init; }
        public string ItemDescription { get; private set; }
        public decimal UnitAmount { get; private set; }
        public decimal UnitQuantity { get; private set; }
        public bool IsTax { get; private set; }

        public List<Adjustment> adjustments { get; private set; }

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

        public void AddAdjustment(Adjustment adjustment)
        {

            if (adjustment.CalculateAdjustment(GetCostTotal()) < 0) 
            {
                throw new ArgumentException("Can't adjust a cost lower than 0");
            }

            adjustments.Add(adjustment);

        }

        public decimal GetCostTotal() 
        { 
            decimal total = UnitAmount * UnitQuantity;

            foreach (Adjustment adjustment in adjustments) 
            {
                total += adjustment.CalculateAdjustment(total);
            }

            return total; 
        }
    }
}
