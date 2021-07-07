using System;

namespace Types.Models
{
    public class UserModel
    {
        public Guid UserId { get; set; }
        public DateTime ModifyDate { get; set; }
        public string Email { get; set; }

        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Lastname { get; set; }
        public DateTime PersonalModifyDate { get; set; }
    }
}