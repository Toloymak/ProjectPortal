using System.Collections.Generic;

namespace Entity.Models
{
    public class Project : EntityBase
    {
        public string Name { get; set; }
        
        public IList<UserProject> UserProjects { get; set; }
    }
}