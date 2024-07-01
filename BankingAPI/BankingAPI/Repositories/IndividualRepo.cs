
namespace BankingAPI.Repositories
{
    public class IndividualRepo : ICustomerRepo
    {
        public Task<Customer> GetCustomerByAccountNo(long accountNo)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Customer>> GetCustomerByContactNo(long contactNo)
        {
            throw new NotImplementedException();
        }

        public Task<Customer> UpdateCustomerAddress(long aaccountNo, Address address)
        {
            throw new NotImplementedException();
        }

        public Task<Customer> UpdateCustomerContactNo(long accountNo, long contactNo)
        {
            throw new NotImplementedException();
        }

        public Task<Customer> UpdateCustomerEmail(long aaccountNo, string email)
        {
            throw new NotImplementedException();
        }
    }
}
