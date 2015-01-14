using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using PdfSharp.Pdf;
using PdfSharp.Pdf.Content;
using PdfSharp.Pdf.Content.Objects;
using PdfSharp.Pdf.IO;
using SimpleDMS.Content.DTO;

namespace SimpleDMS.Content.Provider.PDF
{
    // Taken and adapted from https://github.com/DavidS/PdfTextract/blob/master/PdfTextract/PdfTextExtractor.cs
    
    internal static class PdfTextExtractor
    {
        public static ContentItem GetText(byte[] file, ICredentials credentials = null)
        {
            var parsed = "";
            var title = "PDF";

            try
            {
                var reader = (credentials == null) ?
                        PdfReader.Open(new MemoryStream(file)) :
                        PdfReader.Open(new MemoryStream(file), ((NetworkCredential)credentials).Password, PdfDocumentOpenMode.ReadOnly);

                title = (reader.Info != null && !string.IsNullOrEmpty(reader.Info.Title)) ? reader.Info.Title : "PDF";

                var result = new StringBuilder();
                foreach (var page in reader.Pages.OfType<PdfPage>())
                {
                    ExtractText(ContentReader.ReadContent(page), result);
                    result.AppendLine();
                }

                parsed = result.ToString();
                reader.Dispose();
            }
            catch
            {
                // Currently, PDFSharp does not support all PDF formats.
                // Yet, this is not an error ;)
            }

            return new ContentItem()
            {
                Name = title,
                BinaryContent = file,
                ParsedContent = parsed
            };
        }

        private static void ExtractText(CObject obj, StringBuilder target)
        {
            if (obj is CArray)
                ExtractText((CArray)obj, target);
            else if (obj is CComment)
                ExtractText((CComment)obj, target);
            else if (obj is CInteger)
                ExtractText((CInteger)obj, target);
            else if (obj is CName)
                ExtractText((CName)obj, target);
            else if (obj is CNumber)
                ExtractText((CNumber)obj, target);
            else if (obj is COperator)
                ExtractText((COperator)obj, target);
            else if (obj is CReal)
                ExtractText((CReal)obj, target);
            else if (obj is CSequence)
                ExtractText((CSequence)obj, target);
            else if (obj is CString)
                ExtractText((CString)obj, target);
        }

        private static void ExtractText(CArray obj, StringBuilder target)
        {
            foreach (var element in obj)
            {
                ExtractText(element, target);
            }
        }

        private static void ExtractText(COperator obj, StringBuilder target)
        {
            if (obj.OpCode.OpCodeName == OpCodeName.Tj || obj.OpCode.OpCodeName == OpCodeName.TJ)
            {
                foreach (var element in obj.Operands)
                {
                    ExtractText(element, target);
                }
                target.Append(" ");
            }
        }

        private static void ExtractText(CSequence obj, StringBuilder target)
        {
            foreach (var element in obj)
            {
                ExtractText(element, target);
            }
        }

        private static void ExtractText(CString obj, StringBuilder target)
        {
            target.Append(obj.Value);
        }

        private static void ExtractText(CComment obj, StringBuilder target) {  }

        private static void ExtractText(CInteger obj, StringBuilder target) {  }

        private static void ExtractText(CName obj, StringBuilder target) {  }

        private static void ExtractText(CNumber obj, StringBuilder target) {  }

        private static void ExtractText(CReal obj, StringBuilder target) {  }
    }
}
