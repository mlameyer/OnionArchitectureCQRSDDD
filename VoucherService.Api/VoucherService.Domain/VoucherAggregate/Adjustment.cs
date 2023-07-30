using System;
using VoucherService.Domain.SeedWork;

namespace VoucherService.Domain.VoucherAggregate
{
    public abstract class Adjustment : Entity
    {
        protected Guid _id { get; init; }

        protected DateTime AdjustmentDate { get; private set; }

        protected AdjustmentCode AdjustmentCode { get; private set; }

        protected AdjustmentType AdjustmentType { get; private set; }

        protected decimal _amount { get; private set; }

        protected Adjustment()
        {
            _id = Guid.NewGuid();
            AdjustmentDate = DateTime.UtcNow;
            AdjustmentCode = new AdjustmentCode();
            AdjustmentType = new AdjustmentType();
        }

        public Adjustment(AdjustmentCode adjustmentCode, AdjustmentType adjustmentType, decimal amount)
        {
            AdjustmentCode = adjustmentCode;
            AdjustmentType = adjustmentType;
            _amount = amount;
        }

        public abstract decimal CalculateAdjustment(decimal amount);

    }
}
