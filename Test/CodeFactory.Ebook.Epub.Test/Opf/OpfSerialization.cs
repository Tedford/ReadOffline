using System.IO;
using System.Reflection;
using System.Xml.Serialization;
using CodeFactory.Ebook.Opf;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeFactory.Epub.Test
{
    [TestClass]
    public class OpfSerialization
    {
        [TestMethod]
        public void Deserialize()
        {
            OpfDocument document;
            XmlSerializer serializer = new XmlSerializer(typeof(OpfDocument));
            using (Stream s = Assembly.GetExecutingAssembly().GetManifestResourceStream("CodeFactory.Ebook.Test.Exemplars.MsdnMagazine.opf"))
            //using (Stream s = new FileStream(@"C:\Projects\GitHub\MsdnMagazineOnKindle\Test\CodeFactory.Epub.Test\Exemplars\MsdnMagazine.opf", FileMode.Open))
            {
                document = serializer.Deserialize(s) as OpfDocument;
            }

            Assert.IsNotNull(document);
            Assert.IsNotNull(document.Metadata);
            Assert.AreEqual("MSDN Magazine 3 2015", document.Metadata.Title);
            CollectionAssert.Contains(document.Metadata.Language, "en-us");
            Assert.AreEqual("3/25/2015", document.Metadata.Date);

            Assert.IsNotNull(document.Manifest);
            Assert.AreEqual(13, document.Manifest.Items.Count);
            Assert.AreEqual("item1", document.Manifest.Items[0].Id);
            Assert.AreEqual("application/xhtml+xml", document.Manifest.Items[0].ContentType);
            Assert.AreEqual("toc.html", document.Manifest.Items[0].Href);
            Assert.AreEqual("item2", document.Manifest.Items[1].Id);
            Assert.AreEqual("application/xhtml+xml", document.Manifest.Items[1].ContentType);
            Assert.AreEqual(@"C:\Users\ted_000\Desktop\msdn\MSDN Magazine 3 2015\Go Cross-Platform with the _NET Framework.html", document.Manifest.Items[1].Href);
            Assert.AreEqual("item13", document.Manifest.Items[12].Id);
            Assert.AreEqual("application/xhtml+xml", document.Manifest.Items[12].ContentType);
            Assert.AreEqual(@"C:\Users\ted_000\Desktop\msdn\MSDN Magazine 3 2015\Using Printf with Modern C.html", document.Manifest.Items[12].Href);

            Assert.IsNotNull(document.Spine);
            Assert.AreEqual(13, document.Spine.Items.Count);
            Assert.AreEqual("item1", document.Spine.Items[0].Reference);
            Assert.AreEqual("item2", document.Spine.Items[1].Reference);
            Assert.AreEqual("item13", document.Spine.Items[12].Reference);

            Assert.IsNotNull(document.Guide);
            Assert.AreEqual(1, document.Guide.References.Count);
            Assert.AreEqual("toc", document.Guide.References[0].Type);
            Assert.AreEqual("able of Contents", document.Guide.References[0].Title);
            Assert.AreEqual("toc.html", document.Guide.References[0].Href);
        }
    }
}
