using System;
using VoucherService.Domain.SeedWork;

namespace VoucherService.Domain.VoucherAggregate
{
    public abstract class Adjustment : Entity
    {
        private Guid _id;

        public DateTime AdjustmentDate { get; private set; }

        public AdjustmentCode AdjustmentCode { get; private set; }

        public AdjustmentType AdjustmentType { get; private set; }

        private decimal _amount;

        protected Adjustment()
        {
            _id = Guid.NewGuid();
            AdjustmentCode = new AdjustmentCode();
            AdjustmentType = new AdjustmentType();
        }

        public Adjustment(AdjustmentCode adjustmentCode, AdjustmentType adjustmentType, decimal amount)
        {
            AdjustmentCode = adjustmentCode;
            AdjustmentType = adjustmentType;
            _amount = amount;
        }

        public abstract void ApplyAdjustment();
        //{
            //decimal deltaAmount;
            //decimal deltaBalance;

            //AdjustmentDate = DateTime.UtcNow;
            //AdjustmentCode = adjustmentCode;
            //AdjustmentType = adjustmentType;

            //if (AdjustmentType.CostAdjustment.Equals(adjustmentType))
            //{
            //    deltaAmount = adjustmentAmount;
            //    deltaBalance = adjustmentAmount;
            //}
            //else if ((AdjustmentType.VoucherAdjustment.Equals(adjustmentType)))
            //{
            //    deltaBalance = currentBalance * (adjustmentAmount / 100);
            //}
            //else
            //{
            //    throw new ArgumentException("Unknown AdjustmentType. Cannot perform adjustment");
            //}
        //}
    }
}
