using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CodeFactory.Epub.Models
{
    [XmlRoot("metadata")]
    public class PublicationMetadata
    {
        [XmlElement("title", Namespace = Namespaces.DublinCore, Order = 0)]
        public string Title { get; set; }

        [XmlElement("creator", Namespace = Namespaces.DublinCore, Order = 1)]
        public Creator Creator { get; set; }

        [XmlElement("subject", Namespace = Namespaces.DublinCore, Order = 2)]
        public List<string> Subjects { get; set; }

        [XmlElement("description", Namespace = Namespaces.DublinCore, Order = 3)]
        public string Description { get; set; }

        [XmlElement("publisher", Namespace = Namespaces.DublinCore, Order = 4)]
        public string Publisher { get; set; }


        [XmlElement("contributor", Namespace = Namespaces.DublinCore, Order = 5)]
        public string Contributor { get; set; }

        /// <summary>
        /// Gets or sets the date.
        /// </summary>
        /// <value>The date.</value>
        /// <remarks>ISO-8601 format</remarks>
        [XmlElement("date", Namespace = Namespaces.DublinCore, Order = 6)]
        public string Date { get; set; }

        [XmlElement("type", Namespace = Namespaces.DublinCore, Order = 7)]
        public string Type { get; set; }

        [XmlElement("format", Namespace = Namespaces.DublinCore, Order = 8)]
        public string Format { get; set; }

        [XmlElement("identifier", Namespace = Namespaces.DublinCore, Order = 9)]
        public Identifier Identifier { get; set; }

        [XmlElement("source", Namespace = Namespaces.DublinCore, Order = 10)]
        public string Source { get; set; }

        /// <summary>
        /// Gets or sets the language.
        /// </summary>
        /// <value>The language.</value>
        /// <remarks>RFC 3066</remarks>
        [XmlElement("language", Namespace = Namespaces.DublinCore, Order = 11)]
        public List<string> Language { get; set; }

        [XmlElement("relation", Namespace = Namespaces.DublinCore, Order = 12)]
        public string Relation { get; set; }

        [XmlElement("coverage", Namespace = Namespaces.DublinCore, Order = 13)]
        public string Coverage { get; set; }

        [XmlElement("rights", Namespace = Namespaces.DublinCore, Order = 14)]
        public string Rights { get; set; }
    }
}
