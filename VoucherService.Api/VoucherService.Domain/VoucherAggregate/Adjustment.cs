using System;
using VoucherService.Domain.SeedWork;

namespace VoucherService.Domain.VoucherAggregate
{
    public class Adjustment : Entity
    {
        public DateTime AdjustmentDate { get; private set; }

        public AdjustmentCode AdjustmentCode { get; private set; }

        public AdjustmentType AdjustmentType { get; private set; }

        public int AdjustmentSequence { get; private set; }

        public decimal ComputeAmount { get; private set; }

        public decimal Delta { get; private set; }

        protected Adjustment()
        {
            Id = Guid.NewGuid();
            AdjustmentDate = DateTime.UtcNow;
            AdjustmentCode = new AdjustmentCode();
            AdjustmentType = new AdjustmentType();
        }

        public Adjustment(DateTime adjustmentDate, AdjustmentCode adjustmentCode, AdjustmentType adjustmentType, int adjustmentSequence, decimal computeAmount, decimal delta)
        {
            AdjustmentDate = adjustmentDate;
            AdjustmentCode = adjustmentCode;
            AdjustmentType = adjustmentType;
            AdjustmentSequence = adjustmentSequence;
            ComputeAmount = computeAmount;
            Delta = delta;
        }
        
        public void SetAdjustmentSequence(int sequence)
        {
            AdjustmentSequence = sequence;
        }
    }
}
