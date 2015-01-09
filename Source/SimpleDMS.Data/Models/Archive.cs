
namespace SimpleDMS.Data.Models
{
    public class Archive
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public string PrivateAndPublicKey { get; set; }
        public bool EnableEncryption { get; set; }

        public string ProviderType { get; set; }
        public string ProviderVersion { get; set; }

        public Document[] Documents { get; set; }
    }
}
