using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
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
    public class ArticleCrawler
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ArticleCrawler"/> class.
        /// </summary>
        public ArticleCrawler()
        {
        }

        /// <summary>
        /// Crawls the specified article.
        /// </summary>
        /// <param name="article">The article.</param>
        /// <returns>WebSite.</returns>
        /// <exception cref="System.ArgumentNullException">article</exception>
        /// <exception cref="System.ArgumentException">A URL to the base article is required;article</exception>
        public void Crawl(Article article)
        {
            if (article == null)
            {
                throw new ArgumentNullException("article");
            }

            if (article.Url == null)
            {
                throw new ArgumentException("A URL to the base article is required", "article");

            }
            WebClient client = new WebClient();

            HtmlDocument document = new HtmlDocument();
            document.LoadHtml(article.Html);

            // TODO handle this asynchronously
            //XDocument document = XDocument.Parse(article.Html);
            //foreach (XElement element in document.Descendants().Where(i => string.Equals(i.Name.LocalName, "img", StringComparison.CurrentCultureIgnoreCase)))
            //{
            //    var attribute = element.Attributes().FirstOrDefault(i => string.Equals(i.Name.LocalName, "src", StringComparison.CurrentCultureIgnoreCase));
            //    if (attribute != null)
            //    {
            //        Uri uri;
            //        if (Uri.TryCreate(attribute.Value, UriKind.RelativeOrAbsolute, out uri))
            //        {
            //            string path = uri.GetComponents(UriComponents.Path, UriFormat.Unescaped);
            //            string name = Path.GetFileName(path);
            //            SiteAsset asset = new SiteAsset
            //            {
            //                Name = name,
            //                RelativePath = new Uri("file:///./images/" + path),
            //                Value = client.DownloadData(uri)
            //            };
            //            attribute.Value = asset.RelativePath.ToString();
            //        }
            //    }
            //}
        }



    }
}
