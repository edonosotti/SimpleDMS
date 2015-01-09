using System;

namespace SimpleDMS.Data.Models
{
    public class Page
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }

        public string Category { get; set; }
        public string[] Tags { get; set; }

        public string Author { get; set; }
        public string Version { get; set; }
        public string Revision { get; set; }
        public string Source { get; set; }

        public DateTime Modified { get; set; }

        public string Checksum { get; set; }
        public int Size { get; set; }
        public string Mime { get; set; }

        public string Path { get; set; }
        public string FileName { get; set; }

        public Comment[] Comments { get; set; }
    }
}
