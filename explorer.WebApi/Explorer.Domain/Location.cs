using System.Collections.Generic;

namespace Explorer.Domain
{
    public class Location
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public string Description { get; set; }
        public double Rating { get; set; }
        public List<Comment> Comment { get; set; }
        public List<User> UsersSaved { get; set; }
        public string imageURL { get; set; }
    }
}