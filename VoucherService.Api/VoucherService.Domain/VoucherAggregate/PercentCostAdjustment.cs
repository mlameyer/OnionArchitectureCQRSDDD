namespace VoucherService.Domain.VoucherAggregate
{
    public class PercentCostAdjustment : Adjustment
    {
        public PercentCostAdjustment(AdjustmentCode adjustmentCode, AdjustmentType adjustmentType, decimal amount)
            : base(adjustmentCode, adjustmentType, amount) { }

        public override decimal CalculateAdjustment(decimal costAmount)
        {
            return costAmount * _amount;
        }
    }
}
