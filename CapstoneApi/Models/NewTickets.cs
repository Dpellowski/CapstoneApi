namespace CapstoneApi.Models
{
    public class NewTickets
    {
        public int openSeats { get; set; }
        public string Name { get; set; }
        public string Destination { get; set; }
        public string DepartStation { get; set; }
        public string DepartTime { get; set; }
        public string ArrivalTime { get; set; }

    }
}
