
namespace SimpleDMS.Storage
{
    public class Common
    {
        public enum AuthType
        {
            NoAuth,
            OAuthLike
        }

        public struct ProviderCapabilities
        {
            public AuthType AuthType { get; set; }
            public bool SupportsFormsUI { get; set; }
        }

        public struct ProviderInfo
        {
            public string Name { get; set; }
            public string Version { get; set; }
            public string Description { get; set; }
            public string Url { get; set; }
        }
    }
}
