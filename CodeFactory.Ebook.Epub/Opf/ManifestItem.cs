using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CodeFactory.Ebook.Opf
{
    [XmlRoot("item", Namespace = Namespaces.DublinCore)]
    public class ManifestItem
    {
        [XmlAttribute("id")]
        public string Id { get; set; }

        [XmlAttribute("href")]
        public string Href { get; set; }

        [XmlAttribute("media-type")]
        public string ContentType { get; set; }
    }
}
