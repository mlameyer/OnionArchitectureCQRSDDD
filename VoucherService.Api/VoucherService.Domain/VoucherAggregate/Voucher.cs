using System;
using System.Collections.Generic;
using System.Linq;
using VoucherService.Domain.SeedWork;

namespace VoucherService.Domain.VoucherAggregate
{
    public class Voucher : Entity, IAggregateRoot
    {
        private DateTime _VoucherDate;

        private int _version;

        public string VoucherNumber { get; private set; }

        public Payee Payee { get; private set; }

        public Address Address { get; private set; }

        private int _voucherFinancialStatusId;

        public VoucherFinancialStatus VoucherFinancialStatus { get; private set; }
        

        private readonly Dictionary<string, Cost> _costItems;

        public IReadOnlyCollection<Cost> Costs => _costItems.Values;

        private readonly List<Adjustment> _adjustmentItems;

        public IReadOnlyCollection<Adjustment> Adjustments => _adjustmentItems;

        private readonly List<Payment> _paymentItems;

        public IReadOnlyCollection<Payment> Payments => _paymentItems;


        public static Voucher NewVoucher()
        {
            var voucher = new Voucher();
            voucher.Id = Guid.NewGuid();
            voucher._VoucherDate = DateTime.UtcNow;
            voucher._voucherFinancialStatusId = (int) VoucherFinancialStatus.Deferred;
            return voucher;
        }

        protected Voucher()
        {
            Id = Guid.NewGuid();
            _version = 0;
            _costItems = new Dictionary<string, Cost>();
            _adjustmentItems = new List<Adjustment>();
            _paymentItems = new List<Payment>();
            VoucherFinancialStatus = new VoucherFinancialStatus();
        }

        public Voucher(string voucherNumber, Payee payee, Address address) : this()
        {
            VoucherNumber = voucherNumber;
            Payee = payee;
            Address = address;
        }

        public void AddNewCost(string costCode, string description, decimal price, decimal quantity, bool isTax)
        {
            if (_costItems.TryGetValue(costCode, out Cost existing))
            {
                throw new ArgumentNullException($"Cost {existing.CostCode} already exists. Create a cost adjustment.");
            }

            Cost cost = new Cost(costCode, description, price, quantity, isTax);
            _costItems.Add(costCode, cost);
            _version++;
        }

        public void AdjustCostOnVoucher(string costCode, Adjustment adjustment)
        {
            if (_costItems.TryGetValue(costCode, out Cost existing))
            {
                try
                {
                    existing.AddAdjustment(adjustment);
                    _version++;
                }
                catch
                {
                    throw;
                }
            }
            else
            {
                throw new ArgumentNullException($"Cost {existing.CostCode} not found. Try adding Cost to Voucher first.");
            }
        }

        public void AdjustVoucher(Adjustment adjustment)
        {
            decimal currentVoucherBalance = _costItems.Values.Sum(x => x.GetCostAmount()) + _adjustmentItems.Sum(x => x.Delta) + _paymentItems.Sum(x => x.Amount);

            if ((currentVoucherBalance + adjustment.Delta) < 0)
            {
                throw new ArgumentNullException($"Balance can not be less than 0 for Voucher");
            }

            _adjustmentItems.Add(adjustment);
            _version++;
        }

        public decimal GetOriginalVoucherAmount()
        {
            return _costItems.Sum(x => x.Value.GetOriginalCostAmount());
        }

        public decimal GetCurrentVoucherAmount()
        {
            return _costItems.Sum(x => x.Value.GetCostAmount());
        }

        public decimal GetCurrentVoucherBalance()
        {
            return _costItems.Values.Sum(x => x.GetCostAmount()) + _adjustmentItems.Sum(x => x.Delta) + _paymentItems.Sum(x => x.Amount);
        }

        public decimal GetPaymentAmounts()
        {
            return _paymentItems.Sum(x => x.Amount);
        }
    }
}
