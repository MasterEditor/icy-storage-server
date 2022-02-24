namespace IcyStorageServer.Models
{
    public class FSNode
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public FSNodeType Type { get; set; }
        public FSNode Parent { get; set; }
        public ICollection<FSNode> Children { get; set; }

        public User User { get; set; }
        public int UserId { get; set; }
    }

    public enum FSNodeType
    {
        File,
        Folder
    }
}
