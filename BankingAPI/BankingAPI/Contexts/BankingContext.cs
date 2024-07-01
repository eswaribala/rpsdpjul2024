using Microsoft.EntityFrameworkCore;

namespace BankingAPI.Contexts
{
    public class BankingContext:DbContext
    {
        public BankingContext(DbContextOptions<BankingContext> options) : base(options){
            this.Database.EnsureCreated();

        }


    }
}
