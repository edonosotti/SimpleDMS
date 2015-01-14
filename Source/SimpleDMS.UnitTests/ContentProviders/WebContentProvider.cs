using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SimpleDMS.UnitTests.ContentProviders
{
    [TestClass]
    public class WebContentProvider
    {
        [TestMethod]
        public void ContentProvider_WebContentProvider()
        {
            var response = new SimpleDMS.Content.Provider.Web.WebContentProvider().Acquire(new Uri("http://edoardonosotti.info"));
            Assert.IsTrue(response.Length > 0);
        }
    }
}
