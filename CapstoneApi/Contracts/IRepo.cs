using CapstoneApi.Models;

namespace CapstoneApi.Contracts
{
    public interface IRepo
    {
        public IEnumerable<FoodOption> GetFoodOptions();
        public IEnumerable<Train> GetTrains();
        public IEnumerable<AccountTicket> GetTicketsByLocation(string destination);
        public IEnumerable<AccountTicket> GetTicketsForUser(AccountTicketRequest acc);
        public IEnumerable<AccountTicket> CreateNewTickets(NewTickets tickets);
        public IEnumerable<AccountTicket> CreateUser(Account acc);
        public IEnumerable<VerifyUser> VerifyUser(VerifyUserRequest acc);
    }
}
