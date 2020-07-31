namespace Entity.Models
{
    public class Account : EntityBase
    {
        public string Login { get; set; }
        
        public User User { get; set; }
    }
}