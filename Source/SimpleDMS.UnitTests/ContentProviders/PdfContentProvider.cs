using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SimpleDMS.UnitTests.ContentProviders
{
    [TestClass]
    public class PdfContentProvider
    {
        [TestMethod]
        public void ContentProvider_PdfContentProvider()
        {
            var response = new SimpleDMS.Content.Provider.PDF.PDFContentProvider().Acquire(new Uri("http://www.pdfpdf.com/samples/Sample1.PDF"));
            Assert.IsTrue(response.Length > 0);
        }
    }
}
