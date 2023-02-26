using System.Data;
using CapstoneApi.Context;
using CapstoneApi.Contracts;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using CapstoneApi.Models;

namespace CapstoneApi.Repos
{
    public class Repo : IRepo
    {
        private readonly DapperContext _context;
        //Constructor
        public Repo(DapperContext context)
        {
            _context = context;
        }

        public IEnumerable<FoodOption> GetFoodOptions()
        {
            var procedureName = "stp_GetFood_SM";

            using (var connection = _context.CreateConnection())
            {
                var repo = connection.Query<FoodOption>
                    (procedureName, commandType: CommandType.StoredProcedure);

                return repo;
            }
        }

        public IEnumerable<Train> GetTrains()
        {
            var procedureName = "stp_GetTrains_SM";

            using (var connection = _context.CreateConnection())
            {
                var repo = connection.Query<Train>
                    (procedureName, commandType: CommandType.StoredProcedure);

                return repo;
            }
        }

        public IEnumerable<AccountTicket> GetTicketsForUser(AccountTicketRequest acc)
        {
            var procedureName = "stp_GetAccountTickets_SM";
            DynamicParameters dp = new DynamicParameters();
            dp.Add("Email", acc.email);

            using (var connection = _context.CreateConnection())
            {
                var repo = connection.Query<AccountTicket>
                    (procedureName, dp, commandType: CommandType.StoredProcedure);

                return repo;
            }
        }

        public IEnumerable<AccountTicket> GetTicketsByLocation(string destination)
        {
            var procedureName = "stp_OpenTicketsByLocation";
            DynamicParameters dp = new DynamicParameters();
            dp.Add("Destination", destination);

            using (var connection = _context.CreateConnection())
            {
                var repo = connection.Query<AccountTicket>
                    (procedureName, dp, commandType: CommandType.StoredProcedure);

                return repo;
            }
        }

        public IEnumerable<AccountTicket> CreateNewTickets(NewTickets tickets)
        {
            var procedureName = "stp_CreateNewTickets";
            DynamicParameters dp = new DynamicParameters();
            dp.Add("OpenSeats", tickets.openSeats);
            dp.Add("TrainSID", tickets.trainSID);
            dp.Add("Destination", tickets.Destination);
            dp.Add("DepartTime", tickets.DepartTime);
            dp.Add("ArrivalTime", tickets.ArrivalTime);

            using (var connection = _context.CreateConnection())
            {
                var repo = connection.Query<AccountTicket>
                    (procedureName, dp, commandType: CommandType.StoredProcedure);

                return repo;
            }
        }

        public IEnumerable<AccountTicket> CreateUser(Account acc)
        {
            var procedureName = "stp_CreateUser";
            DynamicParameters dp = new DynamicParameters();
            dp.Add("Name", acc.name);
            dp.Add("Password", acc.password);
            dp.Add("Email", acc.email);
            dp.Add("FirstName", acc.firstName);
            dp.Add("LastName", acc.lastName);

            using (var connection = _context.CreateConnection())
            {
                var repo = connection.Query<AccountTicket>
                    (procedureName, dp, commandType: CommandType.StoredProcedure);

                return repo;
            }
        }

        public IEnumerable<VerifyUser> VerifyUser(VerifyUserRequest acc)
        {
            var procedureName = "stp_VerifyUser";
            DynamicParameters dp = new DynamicParameters();
            dp.Add("Password", acc.password);
            dp.Add("Email", acc.email);

            using (var connection = _context.CreateConnection())
            {
                var repo = connection.Query<VerifyUser>
                    (procedureName, dp, commandType: CommandType.StoredProcedure);

                return repo;
            }
        }
    }
}
