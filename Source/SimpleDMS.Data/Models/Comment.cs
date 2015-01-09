using System;

namespace SimpleDMS.Data.Models
{
    public class Comment
    {
        public string Text { get; set; }
        public string Author { get; set; }

        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }
}
