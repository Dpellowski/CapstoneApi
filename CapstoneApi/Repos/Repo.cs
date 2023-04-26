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

        public IEnumerable<AccountTicket> GetRequestedRefunds()
        {
            var procedureName = "stp_GetAllTicketsRefunds_SM";

            using (var connection = _context.CreateConnection())
            {
                var repo = connection.Query<AccountTicket>
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

        public int CreateNewTickets(NewTickets tickets)
        {
            DateTime arrivalTime = DateTime.Parse(tickets.ArrivalTime, System.Globalization.CultureInfo.InvariantCulture);
            DateTime departTime = DateTime.Parse(tickets.DepartTime, System.Globalization.CultureInfo.InvariantCulture);

            var procedureName = "stp_CreateNewTickets";
            DynamicParameters dp = new DynamicParameters();

            dp.Add("OpenSeats", tickets.openSeats);
            dp.Add("Name", tickets.Name);
            dp.Add("Destination", tickets.Destination);
            dp.Add("DepartTime", departTime);
            dp.Add("ArrivalTime", arrivalTime);
            dp.Add("DepartStation", tickets.DepartStation);

            using (var connection = _context.CreateConnection())
            {
                try
                {
                    var repo = connection.Execute
                        (procedureName, dp, commandType: CommandType.StoredProcedure);

                    return repo;
                }
                catch
                {
                    return 0;
                }

            }
        }

        public int CreateUser(Account acc)
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
                try
                {
                    var repo = connection.Execute
                        (procedureName, dp, commandType: CommandType.StoredProcedure);

                    return repo;
                }
                catch
                {
                    return 0;
                }

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

        public int PurchaseTicket(PurchaseTicketRequest ptr)
        {
            var procedureName = "stp_PurchaseTicket";
            DynamicParameters dp = new DynamicParameters();
            dp.Add("TicketSID", ptr.ticketSID);
            dp.Add("AccountSID", ptr.accountSID);
            dp.Add("FoodOptionSID", ptr.foodOptionSID);

            using (var connection = _context.CreateConnection())
            {
                try
                {
                    var repo = connection.Execute
                        (procedureName, dp, commandType: CommandType.StoredProcedure);

                    return repo;
                }
                catch { return 0; }

            }
        }

        public int RequestRefund(RefundReq rf)
        {
            var procedureName = "stp_RequestRefund";
            DynamicParameters dp = new DynamicParameters();
            dp.Add("TicketSID", rf.TicketSID);

            using (var connection = _context.CreateConnection())
            {
                try
                {
                    var repo = connection.Execute
                        (procedureName, dp, commandType: CommandType.StoredProcedure);

                    return repo;
                }
                catch { return 0; }

            }
        }

        public int ApproveRefund(RefundReq rf)
        {
            var procedureName = "stp_ApproveRefund";
            DynamicParameters dp = new DynamicParameters();
            dp.Add("TicketSID", rf.TicketSID);

            using (var connection = _context.CreateConnection())
            {
                try
                {
                    var repo = connection.Execute
                        (procedureName, dp, commandType: CommandType.StoredProcedure);

                    return repo;
                }
                catch { return 0; }

            }
        }

        public int ReplacePassword(ReplacePasswordReq rpr)
        {
            var procedureName = "stp_ReplacePassword";
            DynamicParameters dp = new DynamicParameters();
            dp.Add("AccountSID", rpr.AccountSID);
            dp.Add("NewPassword", rpr.NewPassword);

            using (var connection = _context.CreateConnection())
            {
                try
                {
                    var repo = connection.Execute
                        (procedureName, dp, commandType: CommandType.StoredProcedure);

                    return repo;
                }
                catch { return 0; }

            }
        }

        public int CreateTrain(CreateTrainReq ctr)
        {
            var procedureName = "stp_CreateTrain";
            DynamicParameters dp = new DynamicParameters();
            dp.Add("TrainName", ctr.TrainName);
            dp.Add("PassengerCapacity", ctr.PassengerCapacity);

            using (var connection = _context.CreateConnection())
            {
                try
                {
                    var repo = connection.Execute
                        (procedureName, dp, commandType: CommandType.StoredProcedure);

                    return repo;
                }
                catch { return 0; }

            }
        }

        public int CreateFoodOption(CreateFoodReq cfr)
        {
            var procedureName = "stp_CreateFoodOption";
            DynamicParameters dp = new DynamicParameters();
            dp.Add("FoodOption", cfr.FoodOption);
            dp.Add("Img", cfr.Img);

            using (var connection = _context.CreateConnection())
            {
                try
                {
                    var repo = connection.Execute
                        (procedureName, dp, commandType: CommandType.StoredProcedure);

                    return repo;
                }
                catch { return 0; }

            }
        }

        public int DeleteTicket(TicketDeleteReq tdr)
        {
            var procedureName = "stp_DeleteTicket";
            DynamicParameters dp = new DynamicParameters();
            dp.Add("TicketSID", tdr.TicketSid);

            using (var connection = _context.CreateConnection())
            {
                try
                {
                    var repo = connection.Execute
                        (procedureName, dp, commandType: CommandType.StoredProcedure);

                    return repo;
                }
                catch { return 0; }

            }
        }
    }
}
