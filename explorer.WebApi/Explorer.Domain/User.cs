namespace Explorer.Domain
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string email { get; set; }
        public string PasswordHash { get; set; }
        public string Adress { get; set; }
        public int AvatarId { get; set; }
    }
}