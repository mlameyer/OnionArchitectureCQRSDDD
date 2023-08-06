using System;
using VoucherService.Domain.SeedWork;

namespace VoucherService.Domain.VoucherAggregate
{
    public class Adjustment : Entity
    {
<<<<<<< Updated upstream
        protected Guid _id { get; init; }

        protected DateTime AdjustmentDate { get; private set; }
=======
        public DateTime AdjustmentDate { get; private set; }
>>>>>>> Stashed changes

        protected AdjustmentCode AdjustmentCode { get; private set; }

        protected AdjustmentType AdjustmentType { get; private set; }

<<<<<<< Updated upstream
        protected decimal _amount { get; private set; }

        protected Adjustment()
        {
            _id = Guid.NewGuid();
=======
        public int AdjustmentSequence { get; private set; }

        public decimal ComputeAmount { get; private set; }

        public decimal Delta { get; private set; }

        protected Adjustment()
        {
            Id = Guid.NewGuid();
>>>>>>> Stashed changes
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
<<<<<<< Updated upstream

        public abstract decimal CalculateAdjustment(decimal amount);

=======
>>>>>>> Stashed changes
    }
}
