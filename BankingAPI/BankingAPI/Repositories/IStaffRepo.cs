namespace BankingAPI.Repositories
{
    public interface IStaffRepo : ICustomerRepo
    {
        Task<Customer> CreateCustomer(Customer customer);

        Task<bool> DeleteCustomer(long accountNo);
        Task<Corporate> ODLimit(long odLimit);
       
         
        
    }
}
