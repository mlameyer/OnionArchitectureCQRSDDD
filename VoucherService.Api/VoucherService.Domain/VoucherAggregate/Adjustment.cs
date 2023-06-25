using System;
using System.Collections.Generic;
using VoucherService.Domain.SeedWork;

namespace VoucherService.Domain.VoucherAggregate
{
    public class Adjustment : Entity
    {
        public DateTime AdjustmentDate { get; private set; }

        public AdjustmentCode AdjustmentCode { get; private set; }

        public AdjustmentType AdjustmentType { get; private set; }

        private decimal? _amount;

        private decimal _balance;

        public static Adjustment NewAdjustment()
        {
            var adjustment = new Adjustment();
            return adjustment;
        }

        protected Adjustment()
        {
            AdjustmentCode = new AdjustmentCode();
            AdjustmentType = new AdjustmentType();
        }

        public Adjustment(AdjustmentCode adjustmentCode, AdjustmentType adjustmentType, decimal? amount, decimal balance)
        {
            AdjustmentCode = adjustmentCode;
            AdjustmentType = adjustmentType;
            _amount = amount;
            _balance = balance;
        }

        public void ApplyAdjustment(decimal currentAmount, decimal currentBalance, decimal adjustmentAmount, AdjustmentCode adjustmentCode, AdjustmentType adjustmentType)
        {
            decimal deltaAmount;
            decimal deltaBalance;

            Dictionary<AdjustmentType, bool> adjustmentTypeRule = new Dictionary<AdjustmentType, bool>();
            adjustmentTypeRule.Add(AdjustmentType.AmountAndBalance, true);
            adjustmentTypeRule.Add(AdjustmentType.BalanceOnly, false);

            Dictionary<AdjustmentCode, bool> adjustmentCodeRule = new Dictionary<AdjustmentCode, bool>();
            adjustmentCodeRule.Add(AdjustmentCode.Flat_Amount, true);
            adjustmentCodeRule.Add(AdjustmentCode.Flat_Discount, true);
            adjustmentCodeRule.Add(AdjustmentCode.Flat_Fee, true);
            adjustmentCodeRule.Add(AdjustmentCode.Percent_Discount, false);
            adjustmentCodeRule.Add(AdjustmentCode.Percent_Fee, false);

            adjustmentTypeRule.TryGetValue(adjustmentType, out bool isBalanceOnly);

            adjustmentCodeRule.TryGetValue(adjustmentCode, out bool isFlat);

            AdjustmentDate = DateTime.UtcNow;
            AdjustmentCode = adjustmentCode;
            AdjustmentType = adjustmentType;

            if (isFlat)
            {
                deltaAmount = adjustmentAmount;
                deltaBalance = adjustmentAmount;
            }
            else
            {

                deltaAmount = currentAmount * (adjustmentAmount / 100);
                deltaBalance = currentBalance * (adjustmentAmount / 100);
            }

            if (isBalanceOnly)
            {
                _balance = deltaBalance;
            }
            else
            {
                _amount = deltaAmount;
                _balance = deltaBalance;
            }
        }
    }
}
