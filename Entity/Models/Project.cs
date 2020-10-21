using System.Collections.Generic;

namespace Entity.Models
{
    public class Project : EntityBase
    {
        public string Name { get; set; }
        
        public IList<UserProject> UserProjects { get; set; }
        public IList<User> Users { get; set; }
        public IList<Page> Pages { get; set; }
    }
}