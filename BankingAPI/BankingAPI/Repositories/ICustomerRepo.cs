namespace BankingAPI.Repositories
{
    public interface ICustomerRepo
    {
        
        Task<Customer> UpdateCustomerAddress(long aaccountNo, Address address);
        Task<Customer> UpdateCustomerEmail(long aaccountNo, string email);
        Task<Customer> UpdateCustomerContactNo(long accountNo, long contactNo);
       
        Task<Customer> GetCustomerByAccountNo(long accountNo);
        Task<IEnumerable<Customer>> GetCustomerByContactNo(long contactNo);
      
       
         
        
    }
}
