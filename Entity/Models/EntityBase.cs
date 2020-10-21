using System;

namespace Entity.Models
{
    public class EntityBase
    {
        public Guid Id { get; set; }
        public DateTime ModifyingDate  { get; set; }
    }
}