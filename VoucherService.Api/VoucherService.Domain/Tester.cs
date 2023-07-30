using VoucherService.Domain.VoucherAggregate;

namespace VoucherService.Domain
{
    public class Tester
    {
        FlatCostAdjustment flatCostAdjustment = new FlatCostAdjustment(AdjustmentCode.Flat_Amount, AdjustmentType.CostAdjustment, 10);
        Cost newCost = new Cost("cost", 100, 100, false);


    }
}
