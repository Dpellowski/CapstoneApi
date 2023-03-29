using CapstoneApi.Models;

namespace CapstoneApi.Contracts
{
    public interface IRepo
    {
        public IEnumerable<FoodOption> GetFoodOptions();
        public IEnumerable<Train> GetTrains();
        public IEnumerable<AccountTicket> GetTicketsByLocation(string destination);
        public IEnumerable<AccountTicket> GetTicketsForUser(AccountTicketRequest acc);
        public int CreateNewTickets(NewTickets tickets);
        public int CreateUser(Account acc);
        public IEnumerable<VerifyUser> VerifyUser(VerifyUserRequest acc);
        public int PurchaseTicket(PurchaseTicketRequest ptr);
    }
}
