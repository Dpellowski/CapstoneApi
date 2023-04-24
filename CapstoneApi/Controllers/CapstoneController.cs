using CapstoneApi.Contracts;
using CapstoneApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace CapstoneApi.Controllers
{
    [Route("api/capstone")]
    [ApiController]
    public class CapstoneController : ControllerBase
    {
        private readonly IRepo _repo;

        //Create our connection when we create our singleton
        public CapstoneController(IRepo repo)
        {
            _repo = repo;
        }

        [HttpGet]
        [Route("GetFoodOptions")]
        public IActionResult GetFoodOptions()
        {
            var repo = _repo.GetFoodOptions();
            return Ok(repo);
        }

        [HttpGet]
        [Route("GetTrains")]
        public IActionResult GetTrains()
        {
            var repo = _repo.GetTrains();
            return Ok(repo);
        }

        [HttpPost]
        [Route("GetAccountTickets")]
        public IActionResult GetAccountTickets(AccountTicketRequest acc)
        {
            var repo = _repo.GetTicketsForUser(acc);
            return Ok(repo);
        }
        [HttpPost]
        [Route("GetTicketsByLocation")]
        public IActionResult GetTicketsByDestination(string destination)
        {
            var repo = _repo.GetTicketsByLocation(destination);
            return Ok(repo);
        }

        [HttpPost]
        [Route("CreateNewTickets")]
        public IActionResult CreateNewTickets(NewTickets tickets)
        {
            var repo = _repo.CreateNewTickets(tickets);
            return Ok(repo);
        }
        [HttpPost]
        [Route("CreateUser")]
        public IActionResult CreateUser(Account acc)
        {
            var repo = _repo.CreateUser(acc);
            return Ok(repo);
        }
        [HttpPost]
        [Route("Login")]
        public IActionResult VerifyUser(VerifyUserRequest acc)
        {
            var repo = _repo.VerifyUser(acc);
            return Ok(repo);
        }

        [HttpPost]
        [Route("PurchaseTicket")]
        public IActionResult PurchaseTicket(PurchaseTicketRequest ptr)
        {
            var repo = _repo.PurchaseTicket(ptr);
            return Ok(repo);
        }

        [HttpPost]
        [Route("RequestRefund")]
        public IActionResult RequestRefund(RefundReq rf)
        {
            var repo = _repo.RequestRefund(rf);
            return Ok(repo);
        }

        [HttpPost]
        [Route("ApproveRefund")]
        public IActionResult ApproveRefund(RefundReq rf)
        {
            var repo = _repo.ApproveRefund(rf);
            return Ok(repo);
        }

        [HttpPost]
        [Route("ReplacePassword")]
        public IActionResult ReplacePassword(ReplacePasswordReq rpr)
        {
            var repo = _repo.ReplacePassword(rpr);
            return Ok(repo);
        }

        [HttpPost]
        [Route("CreateTrain")]
        public IActionResult CreateTrain(CreateTrainReq ctr)
        {
            var repo = _repo.CreateTrain(ctr);
            return Ok(repo);
        }

        [HttpPost]
        [Route("CreateFoodOption")]
        public IActionResult CreateFoodOption(CreateFoodReq cfr)
        {
            var repo = _repo.CreateFoodOption(cfr);
            return Ok(repo);
        }

        [HttpPost]
        [Route("DeleteTicket")]
        public IActionResult DeleteTicket(TicketDeleteReq tdr)
        {
            var repo = _repo.DeleteTicket(tdr);
            return Ok(repo);
        }


    }
}
