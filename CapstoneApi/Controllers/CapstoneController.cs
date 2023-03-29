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

    }
}
