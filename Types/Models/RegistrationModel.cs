using System.ComponentModel.DataAnnotations;
using Types.Copnstants;

namespace Types.Models
{
    public class RegistrationModel
    {
        [RegularExpression(RegexpPatterns.Email, ErrorMessage = "Email has not correct format")]
        public string Email { get; set; }
        
        [MaxLength(256)]
        public string FirstName { get; set; }
        
        [MaxLength(256)]
        public string MiddleName { get; set; }
        
        [MaxLength(256)]
        public string LastName { get; set; }
        
        [MaxLength(256)]
        public string Password { get; set; }
    }
}