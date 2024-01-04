using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class UserToken
    {
        [ForeignKey("user")]
        public int Id { get; set; }
        public string Token { get; set; }
        public DateTime Expire { get; set; }
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenExp { get; set; }
        public User user { get; set; }
    }
}
