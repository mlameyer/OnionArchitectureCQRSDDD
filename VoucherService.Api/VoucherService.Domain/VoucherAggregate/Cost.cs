using System;
using System.Collections.Generic;
using System.Linq;
using VoucherService.Domain.SeedWork;

namespace VoucherService.Domain.VoucherAggregate
{
    public class Cost : Entity
    {
        public string CostCode { get; private set; }

        public DateTime? CreatedDateTime { get; private set; }

        public string Description { get; private set; }

        public decimal Price { get; private set; }

        public decimal Quantity { get; private set; }

        public bool IsTax { get; private set; }


        private readonly List<Adjustment> adjustments;

        public IReadOnlyCollection<Adjustment> Adjustments => adjustments;

        protected Cost() 
        {
            adjustments = new List<Adjustment>();
        }

        public Cost(string costCode, string description, decimal price, decimal quantity, bool isTax, Guid? id = null)
        {
            Id = id.HasValue ? id.Value : Guid.NewGuid();
            CostCode = costCode;
            CreatedDateTime = DateTime.UtcNow;
            Description = description;
            Price = price;
            Quantity = quantity;
            IsTax = isTax;
        }
        public decimal GetCostAmount() 
        {
            decimal newPrice = Price + adjustments.Where(x => x.AdjustmentType.Equals(AdjustmentType.CostPriceAdjustment)).Sum(x => x.Delta);
            decimal newQuantity = Quantity + adjustments.Where(x => x.AdjustmentType.Equals(AdjustmentType.CostPriceAdjustment)).Sum(x => x.Delta);
            return newPrice * newQuantity; 
        }

        public decimal GetOriginalCostAmount()
        {
            return Price * Quantity;
        }

        public void AddAdjustment(Adjustment adjustment)
        {
            decimal currentPrice = Price + adjustments.Where(x => x.AdjustmentType.Equals(AdjustmentType.CostPriceAdjustment)).Sum(x => x.Delta);
            decimal currentQuantity = Quantity + adjustments.Where(x => x.AdjustmentType.Equals(AdjustmentType.CostQuantityAdjustment)).Sum(x => x.Delta);

            if (adjustment.AdjustmentType.Equals(AdjustmentType.CostQuantityAdjustment))
            {
                if((currentQuantity + adjustment.Delta) < 0)
                {
                    throw new ArgumentException($"Quantity can not be adjusted lower then 0 for Cost Id: {Id}, Cost Description: {Description}");
                }
            }

            if (adjustment.AdjustmentType.Equals(AdjustmentType.CostPriceAdjustment))
            {
                if ((currentPrice + adjustment.Delta) < 0)
                {
                    throw new ArgumentException($"Price can not be adjusted lower then 0 for Cost Id: {Id}, Cost Description: {Description}");
                }
            }

            adjustment.SetAdjustmentSequence( adjustments.Count + 1 );

            adjustments.Add(adjustment);
        }
    }
}
