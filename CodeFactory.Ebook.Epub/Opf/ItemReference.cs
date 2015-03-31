using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CodeFactory.Ebook.Opf
{
    [XmlRoot("itemref")]
    public class ItemReference
    {
        [XmlAttribute("idref")]
        public string Reference { get; set; }

        [XmlAttribute("linear")]
        public bool Linear { get; set; }
    }
}
