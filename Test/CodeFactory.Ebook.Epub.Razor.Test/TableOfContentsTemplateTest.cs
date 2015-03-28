using System;
using System.Linq;
using CodeFactory.Epub.Models;
using CodeFactory.Epub;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RazorGenerator.Testing;
using HtmlAgilityPack;
using System.Xml;
using System.Xml.XPath;

namespace CodeFactory.Epub.Razor.Test
{
    [TestClass]
    public class TableOfContentsTemplateTest
    {
        [TestMethod, Description("Validate that an instance of the class can be created")]
        public void Instantiate()
        {
            var template = new TableOfContentsTemplate();
        }

        [TestMethod]
        public void EmptyContents()
        {
            string title = "Test Document";
            var template = new TableOfContentsTemplate
            {
                Model = new TableOfContents
                {
                    Title = title
                }
            };

            string html = template.TransformText().Trim();

            var document = new HtmlDocument();
            document.LoadHtml(html);
            Assert.AreEqual(0, document.ParseErrors.Count());

            Assert.AreEqual(title, document.DocumentNode.SelectSingleNode("/html/head/title/text()").InnerText);
            Assert.AreEqual("TABLE OF CONTENTS", document.DocumentNode.SelectSingleNode("/html/body/div/h1/b/text()").InnerText);
            Assert.IsNull(document.DocumentNode.SelectNodes("//html/body/div/ul/li/a"));
        }

        [TestMethod]
        public void OneEntry()
        {
            string title = "Test Document";
            var template = new TableOfContentsTemplate
            {
                Model = new TableOfContents
                {
                    Title = title,
                    Contents =
                    {
                        new ContentItem
                        { 
                            Category= ".NET Core Framework"
                            , Reference = @"C:\Users\ted_000\Desktop\msdn\MSDN Magazine 3 2015\Go Cross-Platform with the _NET Framework.html"
                            , Title="Go Cross-Platform with the .NET Framework"
                        }
                    }
                }
            };

            string html = template.TransformText().Trim();

            var document = new HtmlDocument();
            document.LoadHtml(html);
            Assert.AreEqual(0, document.ParseErrors.Count());

            Assert.AreEqual(title, document.DocumentNode.SelectSingleNode("/html/head/title/text()").InnerText);
            Assert.AreEqual("TABLE OF CONTENTS", document.DocumentNode.SelectSingleNode("/html/body/div/h1/b/text()").InnerText);
            Assert.AreEqual(1, document.DocumentNode.SelectNodes("//html/body/div/ul/li/a").Count);

            HtmlNode node = document.DocumentNode.SelectSingleNode("//html/body/div/ul/li/a[1]");
            Assert.AreEqual(template.Model.Contents.First().Title, node.InnerText);
            Assert.AreEqual(template.Model.Contents.First().Reference, node.Attributes["href"].Value);
            node = document.DocumentNode.SelectSingleNode("//html/body/div/b[following-sibling::ul/li/a]");
            Assert.AreEqual(template.Model.Contents.First().Category, node.InnerText);
        }

        [TestMethod]
        public void MultipleEntries()
        {
            string title = "Test Document";
            var template = new TableOfContentsTemplate
            {
                Model = new TableOfContents
                {
                    Title = title,
                    Contents =
                    {
                        new ContentItem
                        { 
                            Category= ".NET Core Framework"
                            , Reference = @"C:\Users\ted_000\Desktop\msdn\MSDN Magazine 3 2015\Go Cross-Platform with the _NET Framework.html"
                            , Title="Go Cross-Platform with the .NET Framework"
                        },
                        new ContentItem
                        { 
                            Category= ".NET Micro Framework"
                            , Reference = @"C:\Users\ted_000\Desktop\msdn\MSDN Magazine 3 2015\The Microsoft _NET Framework in Embedded Applications.html"
                            , Title="The Microsoft .NET Framework in Embedded Applications"
                        },
                        new ContentItem
                        { 
                            Category= "ASP.NET 5"
                            , Reference = @"C:\Users\ted_000\Desktop\msdn\MSDN Magazine 3 2015\A Deep Dive into the ASP_NET 5 Runtime.html"
                            , Title="A Deep Dive into the ASP.NET 5 Runtime"
                        }
                    }
                }
            };

            string html = template.TransformText().Trim();

            var document = new HtmlDocument();
            document.LoadHtml(html);
            Assert.AreEqual(0, document.ParseErrors.Count());

            Assert.AreEqual(title, document.DocumentNode.SelectSingleNode("/html/head/title/text()").InnerText);
            Assert.AreEqual("TABLE OF CONTENTS", document.DocumentNode.SelectSingleNode("/html/body/div/h1/b/text()").InnerText);
            Assert.AreEqual(3, document.DocumentNode.SelectNodes("//html/body/div/ul/li/a").Count);

            HtmlNode node = document.DocumentNode.SelectSingleNode("(/html/body/div/ul/li/a)[1]");
            Assert.AreEqual(template.Model.Contents.First().Title, node.InnerText);
            Assert.AreEqual(template.Model.Contents.First().Reference, node.Attributes["href"].Value);
            node = document.DocumentNode.SelectSingleNode("//html/body/div/b[following-sibling::ul/li/a]");
            Assert.AreEqual(template.Model.Contents.First().Category, node.InnerText);


            node = document.DocumentNode.SelectSingleNode("(/html/body/div/ul/li/a)[3]");
            Assert.AreEqual(template.Model.Contents.ElementAt(2).Title, node.InnerText);
            Assert.AreEqual(template.Model.Contents.ElementAt(2).Reference, node.Attributes["href"].Value);
            node = document.DocumentNode.SelectSingleNode("(/html/body/div/b[following-sibling::ul/li/a])[3]");
            Assert.AreEqual(template.Model.Contents.ElementAt(2).Category, node.InnerText);
        }
    }
}
