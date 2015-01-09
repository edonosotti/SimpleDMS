
namespace SimpleDMS.Security
{
    public class Credentials
    {
        public enum CredentialsType
        {
            AsymmetricKey,
            UsernameAndPassword
        }

        public CredentialsType Type
        {
            get
            {
                return (!string.IsNullOrEmpty(PublicAndPrivateKey) || !string.IsNullOrEmpty(PublicKey)) ? 
                    CredentialsType.AsymmetricKey : CredentialsType.UsernameAndPassword;
            }
        }

        public string Username { get; set; }
        public string Password { get; set; }

        public string PublicAndPrivateKey { get; set; }
        public string PublicKey { get; set; }
    }
}
