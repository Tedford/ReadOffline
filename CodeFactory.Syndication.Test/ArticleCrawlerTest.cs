using System.Linq;
using System;
using System.Reflection;
using System.ServiceModel.Syndication;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml;
using System.IO;
using NSubstitute;
using NSubstitute.Core;

namespace CodeFactory.Syndication.Test
{
    [TestClass]
    public class ArticleCrawlerTest
    {
        [TestMethod, Description("Validate that an instance of the class can be created")]
        public void Instantiate()
        {
            WebSiteCrawler crawler = new WebSiteCrawler();
        }

        [TestMethod]
        public void Crawl()
        {
            IWebSite site = CreateSite();
            WebSiteCrawler crawler = new WebSiteCrawler();
            crawler.Crawl(site);
            site.Received(4).Add(Arg.Any<SiteAsset>());
        }

        private static IWebSite CreateSite()
        {
            string html;

            var asm = Assembly.GetExecutingAssembly();
            var resource = asm.GetManifestResourceNames().First(i => i.Contains("MsdnArticle.html"));
            using (var stream = asm.GetManifestResourceStream(resource))
            using (var reader = new StreamReader(stream))
            {
                html = reader.ReadToEnd();
            }

            IWebSite site = Substitute.For<IWebSite>();

            site.Url.Returns(new Uri("http://msdn.microsoft.com/en-us/magazine/dn890368.aspx"));
            site.Html.Returns(new Maybe<string>(html));

            return site;
        }
    }
}
