using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleDMS.Data;
using SimpleDMS.Data.Models;

namespace SimpleDMS.UnitTests.Data
{
    [TestClass]
    public class Query
    {
        [TestMethod]
        public void Data_Query()
        {
            var ctx = GetFakeContext();
            var result = ctx.Search(null, "for page 1");
            Assert.IsNotNull(result);
        }

        private Context GetFakeContext()
        {
            var ctx = new Context();

            ctx.Archive = new Archive();
            ctx.Archive.Name = "Fake archive";
            ctx.Archive.Description = "Unit test";

            List<Page> pages = new List<Page>();
            for (int i = 0; i < 10; i++)
            {
                pages.Add(new Page()
                {
                    Title = string.Format("Title for page {0}", i),
                    Description = string.Format("Description for page {0}", i),
                    Content = string.Format("Content for page {0}", i),
                    Mime = "text/plain",
                    Author = "System"
                });
            }

            List<Document> documents = new List<Document>();
            for (int i = 0; i < 10; i++)
            {
                documents.Add(new Document()
                {
                    Title = string.Format("Title for document {0}", i),
                    Description = string.Format("Description for document {0}", i),
                    Tags = new string[] { "dms" },
                    Pages = pages.ToArray()
                });
            }

            ctx.Archive.Documents = documents.ToArray();

            return ctx;
        }
    }
}
