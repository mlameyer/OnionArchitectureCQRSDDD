using VoucherService.Domain.SeedWork;

namespace VoucherService.Domain.VoucherAggregate
{
    public class Payee : ValueObject
    {
        public string CompanyName { get; private set; }

        public string FirstName { get; private set; } 

        public string LastName { get; private set; }

        public Payee() { }

        public Payee(string companyName, string firstName, string lastname)
        {
            CompanyName = companyName;
            FirstName = firstName;
            LastName = lastname;
        }

    }
}
