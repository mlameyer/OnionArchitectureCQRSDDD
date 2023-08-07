using VoucherService.Domain.SeedWork;

namespace VoucherService.Domain.VoucherAggregate
{
    public class Payment : Entity
    {
        public decimal Amount { get; private set; }
    }
}
