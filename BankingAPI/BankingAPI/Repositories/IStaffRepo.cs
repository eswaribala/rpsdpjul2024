namespace BankingAPI.Repositories
{
    public interface IStaffRepo
    {
        Task<Customer> CreateCustomer(Customer customer);
        Task<Customer> UpdateCustomerAddress(long aaccountNo, Address address);
        Task<Customer> UpdateCustomerEmail(long aaccountNo, string email);
        Task<Customer> UpdateCustomerContactNo(long accountNo, long contactNo);
        Task<bool> DeleteCustomer(long accountNo);
        Task<Customer> GetCustomerByAccountNo(long accountNo);
        Task<IEnumerable<Customer>> GetCustomerByContactNo(long contactNo);
        Task<IEnumerable<Customer>> GetAllCustomers();
        Task<Corporate> ODLimit(long odLimit);
       
         
        
    }
}
