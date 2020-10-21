using System;
using System.Collections.Generic;

namespace Entity.Models
{
    public class User : EntityBase
    {
        public string Name { get; set; }
        
        public Guid AccountId { get; set; }
        public Account Account { get; set; }
        
        public IList<UserProject> UserProjects { get; set; }
        public IList<Project> Projects { get; set; }
    }
}