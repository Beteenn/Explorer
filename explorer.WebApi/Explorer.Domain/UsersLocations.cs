namespace Explorer.Domain
{
    public class UsersLocations
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int LocationId { get; set; }
        public Location Location { get; set; }
    }
}