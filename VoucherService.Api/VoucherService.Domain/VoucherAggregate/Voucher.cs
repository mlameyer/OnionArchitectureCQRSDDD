using System;
using System.Collections.Generic;
using VoucherService.Domain.SeedWork;

namespace VoucherService.Domain.VoucherAggregate
{
    public class Voucher : Entity, IAggregateRoot
    {
        private DateTime _VoucherDate;

        public Payee Payee { get; private set; }
        public Address Address { get; private set; }
        public VoucherFinancialStatus VoucherFinancialStatus { get; private set; }
        private int _voucherFinancialStatusId;

        private readonly List<Cost> _costItems;
        private readonly List<Adjustment> _adjustmentItems;
        private readonly List<Payment> _paymentItems;

        public static Voucher NewVoucher()
        {
            var voucher = new Voucher();
            return voucher;
        }

        protected Voucher()
        {
            _costItems = new List<Cost>();
        }
    }
}
