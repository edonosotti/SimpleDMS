using System;

namespace SimpleDMS.Content.Provider.DTO
{
    public class ContentItem
    {
        public string Source { get; set; }
        public string Name { get; set; }
        public string TextContent { get; set; }
        public byte[] BinaryContent { get; set; }
        public string ParsedContent { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}
