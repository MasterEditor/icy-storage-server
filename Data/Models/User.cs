namespace IcyStorageServer.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public FSNode RootNode { get; set; }
        public byte[] ConcurrencyTimestamp { get; set; }

    }
}
