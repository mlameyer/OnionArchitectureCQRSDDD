using VoucherService.Domain.VoucherAggregate;

namespace VoucherService.Application
{
    public class testDomain
    {
        //Voucher voucher = new Voucher("1234");
        FlatCostAdjustment flatCostAdjustment = new FlatCostAdjustment(AdjustmentCode.Flat_Amount, AdjustmentType.CostAdjustment, 10);
        Cost newCost = new Cost("cost", 100, 100, false);

        public testDomain()
        {
                
        }

        public void test()
        {
            newCost.AddAdjustment(flatCostAdjustment);
        }

    }
}
