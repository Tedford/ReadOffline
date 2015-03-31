using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace CodeFactory.Ebook.Opf
{
    [XmlRoot("identifier", Namespace = Namespaces.DublinCore)]
    public class Identifier
    {
        [XmlAttribute("id")]
        public string Id { get; set; }

        [XmlText]
        public string Value { get; set; }
    }
}
