using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using SimpleDMS.Content.DTO;

namespace SimpleDMS.Content.Provider.PDF
{
    public class PDFContentProvider : IContentProvider
    {
        public ContentItem[] Acquire(Uri source, ICredentials credentials = null)
        {
            var response = new List<ContentItem>();

            try
            {
                var file = (source.IsFile) ?
                        File.ReadAllBytes(source.LocalPath) :
                        new WebClient().DownloadData(source);

                response.Add(PdfTextExtractor.GetText(file, credentials));

            }
            catch (Exception error)
            {
                LogManager.Error(LogManager.LogType.Content, error);
            }

            return response.ToArray();
        }
    }
}
