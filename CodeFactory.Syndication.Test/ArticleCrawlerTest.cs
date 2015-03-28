using System.Linq;
using System;
using System.Reflection;
using System.ServiceModel.Syndication;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml;
using System.IO;

namespace CodeFactory.Syndication.Test
{
    [TestClass]
    public class ArticleCrawlerTest
    {
        [TestMethod, Description("Validate that an ")]
        public void Instantiate()
        {
            WebSiteCrawler crawler = new WebSiteCrawler();
        }

        [TestMethod]
        public void Crawl()
        {
            Article article = CreateArticle();
            WebSiteCrawler crawler = new WebSiteCrawler();
            crawler.Crawl(article);
            Assert.AreEqual(14, article.Assets.Count());
        }

        private static Article CreateArticle()
        {
            //SyndicationFeed feed;
            Article article = new Article(new Uri("http://msdn.microsoft.com/en-us/magazine/dn890368.aspx"));

            var asm = Assembly.GetExecutingAssembly();
            var resource = asm.GetManifestResourceNames().First(i => i.Contains("MsdnArticle.xml"));
            using (var stream = asm.GetManifestResourceStream(resource))
            using (var reader = new StreamReader(stream))
            {
                article.Html = reader.ReadToEnd();
            }

            //return feed;


            return article;
        }
    }
}
