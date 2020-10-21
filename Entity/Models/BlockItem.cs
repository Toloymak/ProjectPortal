using System;

namespace Entity.Models
{
    public class BlockItem : EntityBase
    {
        public string Name { get; set; }
        
        public Guid BlockId { get; set; }
        public Block Block { get; set; }
    }
}