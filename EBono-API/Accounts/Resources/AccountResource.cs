namespace EBono_API.Accounts.Resources
{
    public class AccountResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string CreatedAt { get; set; }
    }
}