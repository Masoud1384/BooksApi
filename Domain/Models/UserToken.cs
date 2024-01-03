namespace Domain.Models
{
    public class UserToken
    {
        public int Id { get; set; }
        public string Token { get; set; }
        public DateTime Expire { get; set; }
        public User user { get; set; }
    }
}
