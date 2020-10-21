using System;
using System.Collections.Generic;

namespace Entity.Models
{
    public class Page: EntityBase
    {
        public string Name { get; set; }
        
        public Guid ProjectId { get; set; }
        public Project Project { get; set; }
        
        public IList<Page> Pages { get; set; }
        
    }
}