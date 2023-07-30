namespace VoucherService.Domain.VoucherAggregate
{
    public class FlatCostAdjustment : Adjustment
    {
        public FlatCostAdjustment(AdjustmentCode adjustmentCode, AdjustmentType adjustmentType, decimal amount) 
        {
            //AdjustmentCode = adjustmentCode;
        }

        public override void ApplyAdjustment()
        {
            throw new System.NotImplementedException();
        }
    }
}
