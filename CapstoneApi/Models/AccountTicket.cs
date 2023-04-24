namespace CapstoneApi.Models
{
    public class AccountTicket
    {
        public int SID { get; set; }
        public int TrainSID { get; set; }
        public int SeatNumber { get; set; }
        public string Destination { get; set; }
        public string DepartStation { get; set; }
        public DateTime DepartTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public int? AccountSID { get; set; }
        public int? FoodSID { get; set; }
        public int? Refund { get; set; }

    }
}
