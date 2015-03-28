using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.XPath;
using HtmlAgilityPack;

namespace CodeFactory.Syndication
{
    /// <summary>
    /// Class Rss20Crawler.
    /// </summary>
    public class WebSiteCrawler
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WebSiteCrawler"/> class.
        /// </summary>
        public WebSiteCrawler()
        {
        }

        /// <summary>
        /// Crawls the specified article.
        /// </summary>
        /// <param name="article">The article.</param>
        /// <returns>WebSite.</returns>
        /// <exception cref="System.ArgumentNullException">article</exception>
        /// <exception cref="System.ArgumentException">A URL to the base article is required;article</exception>
        public void Crawl(WebSite webSite)
        {
            if (webSite == null)
            {
                throw new ArgumentNullException("webSite");
            }

            HtmlDocument document = new HtmlDocument();
            document.LoadHtml(webSite.Html);

            IEnumerable<HtmlNode> imageTags = document.DocumentNode
                                                      .Descendants("img")
                                                      .Where(i => !string.IsNullOrWhiteSpace(i.GetAttributeValue("src", null)));

            // TODO handle this asynchronously
            foreach (var image in imageTags)
            {
                Uri uri = new Uri(image.GetAttributeValue("src", null), UriKind.RelativeOrAbsolute);

                if (!uri.IsAbsoluteUri)
                {
                    Uri siteBase = GetSiteBase(webSite.Url);
                    uri = new Uri(siteBase, uri);
                }

                SiteAsset asset = GetAsset(uri);
                image.SetAttributeValue("src", asset.RelativePath.ToString());
                webSite.Add(asset);
            }
        }

        /// <summary>
        /// retrieve the remote asset.
        /// </summary>
        /// <param name="uri">The URI to the asset.</param>
        /// <returns>The binary representation of the asset;.</returns>
        private SiteAsset GetAsset(Uri uri)
        {
            List<byte> buffer = new List<byte>(2048);

            string contentType;
            try
            {
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(uri);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                using (Stream s = response.GetResponseStream())
                {

                    byte[] bytes = new byte[256];
                    while (s.Read(bytes, 0, bytes.Length) > 0)
                    {
                        buffer.AddRange(bytes);
                    }
                }
                contentType = response.ContentType;
            }
            catch
            {
                using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("CodeFactory.Syndication.Resources.Images.image-not-found.png"))
                {
                    byte[] bytes = new byte[256];
                    while (stream.Read(bytes, 0, bytes.Length) > 0)
                    {
                        buffer.AddRange(bytes);
                    }
                    contentType = "image/jpg";
                }
            }

            string id = Guid.NewGuid().ToString() + ExtensionForContentType(contentType);
            SiteAsset asset = new SiteAsset
            {
                Value = buffer.ToArray(),
                MediaType = contentType,
                Name = id,
                RelativePath = new Uri(@".\Assets\" + id, UriKind.Relative)
            };
            return asset;
        }

        private Uri GetSiteBase(Uri uri)
        {
            var pieces = uri.GetComponents(UriComponents.Host | UriComponents.Path, UriFormat.Unescaped).Split('/');
            string baseUri = string.Concat(uri.Scheme, "://", string.Join("/", pieces.Take(pieces.Count() - 1)));
            return new Uri(baseUri);
        }


        /// <summary>
        /// Get the file extension for the specified content-type.
        /// </summary>
        /// <param name="contentType">Type of the content.</param>
        /// <returns>System.String.</returns>
        private string ExtensionForContentType(string contentType)
        {
            ContentTypeMap map = new ContentTypeMap();
            return map.Lookup(contentType);
        }
    }
}
