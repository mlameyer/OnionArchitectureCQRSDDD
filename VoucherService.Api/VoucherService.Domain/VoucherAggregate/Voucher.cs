using System;
using System.Collections.Generic;
using VoucherService.Domain.SeedWork;

namespace VoucherService.Domain.VoucherAggregate
{
    public class Voucher : Entity, IAggregateRoot
    {
        private Guid _id;

        private DateTime _VoucherDate;

        public string VoucherNumber { get; private set; }

        public Payee Payee { get; private set; }

        public Address Address { get; private set; }

        public VoucherFinancialStatus VoucherFinancialStatus { get; private set; }
        private int _voucherFinancialStatusId;

        private readonly List<Cost> _costItems;

        public IReadOnlyCollection<Cost> Costs => _costItems;

        private readonly List<Adjustment> _adjustmentItems;

        public IReadOnlyCollection<Adjustment> Adjustments => _adjustmentItems;

        private readonly List<Payment> _paymentItems;

        public IReadOnlyCollection<Payment> Payments => _paymentItems;


        public static Voucher NewVoucher()
        {
            var voucher = new Voucher();
            voucher._voucherFinancialStatusId = (int) VoucherFinancialStatus.Deferred;
            return voucher;
        }

        protected Voucher()
        {
            _id = Guid.NewGuid();
            _costItems = new List<Cost>();
            _adjustmentItems = new List<Adjustment>();
            _paymentItems = new List<Payment>();
            VoucherFinancialStatus = new VoucherFinancialStatus();
        }

        public Voucher(string voucherNumber)
        {
            VoucherNumber = voucherNumber;
        }
    }
}
