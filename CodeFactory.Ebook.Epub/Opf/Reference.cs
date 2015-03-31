using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace CodeFactory.Ebook.Opf
{
    [XmlRoot("reference")]
    public class Reference
    {
        [XmlAttribute("type")]
        public string Type { get; set; }

        [XmlAttribute("title")]
        public string Title { get; set; }

        [XmlAttribute("href")]
        public string Href { get; set; }
    }
}
