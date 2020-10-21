using System;
using System.Collections.Generic;

namespace Entity.Models
{
    public class Block : EntityBase
    {
        public string Name { get; set; }
        
        public Guid PageId { get; set; }
        public Page Page { get; set; }
        
        public IList<BlockItem> BlockItems { get; set; }
    }
}