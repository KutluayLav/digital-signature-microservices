namespace AuthService.Models
{
    public class UserModel
    {
        public string? Username { get; set; }
        public string? Email { get; set; }
        public IEnumerable<string>? Roles { get; set; }
    }
}
