using SimpleDMS.Content.Provider.DTO;
using System;
using System.Net;
using System.Windows.Forms;

namespace SimpleDMS.Content.Provider.Scanner
{
    public class ScannerContentProvider : IContentProvider
    {
        public ContentItem[] Acquire()
        {
            var dialog = new Forms.Acquire();
            if (dialog.ShowDialog() == DialogResult.OK)
            {

            }
            // read dialog
            dialog.Dispose();

            return new ContentItem[] { };
        }

        public ContentItem[] Acquire(Uri source, ICredentials credentials = null)
        {
            throw new NotImplementedException();
        }
    }
}
