using System.Collections.Generic;

namespace Types.Models
{
    public class BlockModel
    {
        public string Title { get; set; }
        public IList<LinkModel> Links { get; set; }
    }
}