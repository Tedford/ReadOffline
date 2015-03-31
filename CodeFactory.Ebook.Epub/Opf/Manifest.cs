using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CodeFactory.Ebook.Opf
{
    [XmlRoot("manifest")]
    public class Manifest
    {
        [XmlElement("item")]
        public List<ManifestItem> Items { get; set; }

        public Manifest()
        {
            Items = new List<ManifestItem>();
        }
    }
}
