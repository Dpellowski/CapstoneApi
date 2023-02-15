namespace CapstoneApi.Models
{
    public class NewTickets
    {
        public int openSeats { get; set; }
        public int trainSID { get; set; }
        public string Destination { get; set; }
        public DateTime DepartTime { get; set; }
        public DateTime ArrivalTime { get; set; }

    }
}
