using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Entity.Models
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
        
        public Guid AccountId { get; set; }
        public Account Account { get; set; }
        
        public IList<UserProject> UserProjects { get; set; }
        public IList<Project> Projects { get; set; }
    }
}