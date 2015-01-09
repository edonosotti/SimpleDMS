using System;

namespace SimpleDMS.Data.Models
{
    public class Document
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public string Category { get; set; }
        public string[] Tags { get; set; }

        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public DateTime Accessed { get; set; }

        public string Checksum { get; set; }

        public Page[] Pages { get; set; }

        public Comment[] Comments { get; set; }
    }
}
