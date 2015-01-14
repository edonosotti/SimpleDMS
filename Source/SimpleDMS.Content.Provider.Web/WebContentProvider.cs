using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using HtmlAgilityPack;
using SimpleDMS.Content.DTO;

namespace SimpleDMS.Content.Provider.Web
{
    public class WebContentProvider : IContentProvider
    {
        private HtmlDocument Document { get; set; }
        private WebClient WebClient { get; set; }
        private Uri Source { get; set; }
        private Uri BaseUrl { get; set; }

        private Dictionary<string, string> Replace { get; set; }

        private bool IsValid
        {
            get
            {
                return (Document != null && Document.DocumentNode.ChildNodes.Any());
            }
        }

        public ContentItem[] Acquire(Uri source, ICredentials credentials = null)
        {
            var response = new List<ContentItem>();

            Source = source;
            WebClient = new WebClient();

            if (credentials != null)
            {
                WebClient.Credentials = credentials;
            }

            BaseUrl = (Source.AbsoluteUri.Contains("/")) ?
                new Uri(Source.AbsoluteUri.Substring(0, Source.AbsoluteUri.LastIndexOf("/") + 1)) :
                new Uri(Source.AbsoluteUri + "/");

            Replace = new Dictionary<string, string>();

            GetHtml();

            var title = Document.DocumentNode.Descendants("title").Any() ?
                Document.DocumentNode.Descendants("title").FirstOrDefault().InnerText :
                string.Format("{0}: {1}", Res.Labels.WebPageTitle, Source.AbsoluteUri);

            response.Add(new ContentItem()
            {
                Name = string.Format("{0} ({1})", title, Res.Labels.WebPageOriginalSource),
                TextContent = Document.DocumentNode.OuterHtml
            });

            if (IsValid)
            {
                GetStylesheets();
                GetScripts();
                GetImages();
            }

            var html = Document.DocumentNode.OuterHtml;

            foreach (var kv in Replace)
            {
                html = html.Replace(kv.Key, kv.Value);
            }

            response.Add(new ContentItem()
            {
                Name = string.Format("{0} ({1})", title, Res.Labels.WebPageLocalCache),
                TextContent = html
            });

            return response.ToArray();
        }

        private void GetHtml()
        {
            var html = (Source.IsFile) ?
                File.ReadAllText(Source.LocalPath) :
                DownloadString(Source.AbsoluteUri);

            Document = new HtmlDocument();

            Document.LoadHtml(html);
        }

        private void GetStylesheets()
        {
            var elements = Document.DocumentNode.Descendants("link")
                .Where(
                    w =>
                        w.Attributes.Any() &&
                        w.Attributes["rel"] != null &&
                        w.Attributes["rel"].Value.Equals("stylesheet") &&
                        w.Attributes["href"] != null &&
                        !string.IsNullOrEmpty(w.Attributes["href"].Value)
                )
                .ToArray();

            foreach (var element in elements)
            {
                var content = DownloadString(element.GetAttributeValue("href", string.Empty));
                var search = new Regex(@"@import ([""'])(?<url>[^""']+)\1|url\(([""']?)(?<url>[^""')]+)\2\)");
                foreach (var import in search.Matches(content))
                {
                    var sub = ((Match)import).Value;
                    content = content.Replace("@import " + sub, DownloadString(sub.Substring(5, sub.Length - 7)));
                }
                var attribute = element.GetAttributeValue("media", "all");
                var tag = string.Format("<style type=\"text/css\" media=\"{1}\">{0}</style>", content, attribute);
                Replace.Add(element.OuterHtml, tag);
            }
        }

        private void GetScripts()
        {
            var elements = Document.DocumentNode.Descendants("script")
                .Where(
                    w =>
                        w.Attributes.Any() &&
                        w.Attributes["src"] != null &&
                        !string.IsNullOrEmpty(w.Attributes["src"].Value)
                )
                .ToArray();

            foreach (var element in elements)
            {
                var content = DownloadString(element.GetAttributeValue("src", string.Empty));
                var attribute = element.GetAttributeValue("type", "");
                var tag = string.Format("<script type=\"{1}\">{0}</script>", content, attribute);
                Replace.Add(element.OuterHtml, tag);
            }
        }

        private void GetImages()
        {
            var elements = Document.DocumentNode.Descendants("img")
                .Where(
                    w =>
                        w.Attributes.Any() &&
                        w.Attributes["src"] != null &&
                        !string.IsNullOrEmpty(w.Attributes["src"].Value)
                )
                .ToArray();

            foreach (var element in elements)
            {
                var content = DownloadBytes(element.GetAttributeValue("src", string.Empty));
                var attribute1 = element.GetAttributeValue("id", "");
                var attribute2 = element.GetAttributeValue("class", "");
                var attribute3 = element.GetAttributeValue("width", "");
                var attribute4 = element.GetAttributeValue("height", "");
                var tag = string.Format("<img src=\"{0}\" id=\"{1}\" class=\"{2}\" width=\"{3}\" height=\"{4}\" />", content, attribute1, attribute2, attribute3, attribute4);
                Replace.Add(element.OuterHtml, tag);
            }
        }

        private string DownloadString(string url)
        {
            try
            {
                return WebClient.DownloadString(GetAbsoluteUrl(url));
            }
            catch
            {

            }

            return string.Empty;
        }

        private string DownloadBytes(string url)
        {
            try
            {
                return string.Format(
                        "data:{0};base64,{1}",
                        WebClient.ResponseHeaders.Get("Content-Type"),
                        Convert.ToBase64String(WebClient.DownloadData(GetAbsoluteUrl(url)))
                    );
            }
            catch
            {

            }

            return string.Empty;
        }

        private string GetAbsoluteUrl(string url)
        {
            if (!url.Contains("://"))
            {
                if (url.StartsWith("//"))
                {
                    url = BaseUrl.Scheme + ":" + url;
                }
                else
                {
                    url = BaseUrl + url.TrimStart('/');
                }
            }

            return url;
        }
    }
}
