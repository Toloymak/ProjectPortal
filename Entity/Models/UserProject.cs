using System;

namespace Entity.Models
{
    public class UserProject : EntityBase
    {
        public Guid UserId { get; set; }
        public User User { get; set; }
        
        public Guid ProjectId { get; set; }
        public Project Project { get; set; }
    }
}