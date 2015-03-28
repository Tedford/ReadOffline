using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFactory.Epub.Models
{
    public class TableOfContents
    {
        public string Title { get; set; }

        public List<ContentItem> Contents { get; set; }

        public TableOfContents()
        {
            Contents = new List<ContentItem>();
        }
    }
}
