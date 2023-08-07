using System.Threading.Tasks;

namespace VoucherService.Domain.VoucherAggregate
{
    public interface IVoucherRepository
    {
        Voucher Add(Voucher voucher);

        void Update(Voucher voucher);

        Task<Voucher> GetAsync(int voucherId);
    }
}
