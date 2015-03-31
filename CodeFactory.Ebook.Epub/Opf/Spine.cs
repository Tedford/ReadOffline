using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CodeFactory.Ebook.Opf
{
    [XmlRoot("spine")]
    public class Spine
    {
        [XmlAttribute("toc")]
        public string Toc { get; set; }

        [XmlElement("itemref")]
        public List<ItemReference> Items { get; set; }
    }
}
