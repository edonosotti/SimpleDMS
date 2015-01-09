
namespace SimpleDMS.Storage.DTO
{
    public class StorageOperationResult
    {
        public bool Success { get; set; }
        public string Error { get; set; }

        public string Path { get; set; }
        public byte[] Content { get; set; }
    }
}
