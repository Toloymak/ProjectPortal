using System.Collections.Generic;

namespace Web.Models
{
    public class LinkModel
    {
        public string Title { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }
    }

    public class BlockModel
    {
        public string Title { get; set; }
        public IList<LinkModel> Links { get; set; }
    }
}