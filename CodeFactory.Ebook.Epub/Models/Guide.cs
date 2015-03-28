using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CodeFactory.Epub.Models
{
    [XmlRoot("guide")]
    public class Guide
    {
        [XmlElement("reference")]
        public List<Reference> References { get; set; }

        public Guide()
        {
            References = new List<Reference>();
        }
    }
}
