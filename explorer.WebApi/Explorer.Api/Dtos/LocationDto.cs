using System.Collections.Generic;

namespace Explorer.Api.Dtos
{
    public class LocationDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public string Description { get; set; }
        public double Rating { get; set; }
        public List<CommentDto> Comment { get; set; }
        public List<UserDto> UsersSaved { get; set; }
        public string imageURL { get; set; }
    }
}