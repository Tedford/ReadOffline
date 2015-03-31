using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CodeFactory.Ebook.Opf
{
    /// <summary>
    /// Represents an Open Package Format document
    /// </summary>
    [XmlRoot("package")]
    public class OpfDocument
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        [XmlAttribute("unique-identifier")]
        public string Id { get; set; }

        [XmlElement("metadata", Order = 0)]
        public PublicationMetadata Metadata { get; set; }

        [XmlElement("manifest", Order = 1)]
        public Manifest Manifest { get; set; }

        [XmlElement("spine", Order = 2)]
        public Spine Spine { get; set; }

        /// <summary>
        /// Gets or sets optional structural specification of the publication.
        /// </summary>
        /// <value>The guide.</value>
        [XmlElement("guide", Order = 3)]
        public Guide Guide { get; set; }
    }
}
