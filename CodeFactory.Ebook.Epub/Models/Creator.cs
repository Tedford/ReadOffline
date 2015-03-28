using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CodeFactory.Epub.Models
{
    [XmlRoot("creator", Namespace = Namespaces.DublinCore)]
    public class Creator
    {
        [XmlAttribute("file-as", Namespace = Namespaces.Opf)]
        public string FileAs { get; set; }

        [XmlAttribute("role", Namespace = Namespaces.Opf)]
        public string Role { get; set; }

        [XmlText]
        public string Value { get; set; }
    }
}
