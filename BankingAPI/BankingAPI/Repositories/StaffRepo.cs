
namespace BankingAPI.Repositories
{
    public class StaffRepo : IStaffRepo
    {
        public Task<Customer> CreateCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteCustomer(long accountNo)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Customer>> GetAllCustomers()
        {
            throw new NotImplementedException();
        }

        public Task<Customer> GetCustomerByAccountNo(long accountNo)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Customer>> GetCustomerByContactNo(long contactNo)
        {
            throw new NotImplementedException();
        }

        public Task<Corporate> ODLimit(long odLimit)
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
