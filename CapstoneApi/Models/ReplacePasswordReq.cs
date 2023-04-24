namespace CapstoneApi.Models
{
    public class ReplacePasswordReq
    {
        public int AccountSID { get; set; }
        public string NewPassword { get; set; }
    }
}
