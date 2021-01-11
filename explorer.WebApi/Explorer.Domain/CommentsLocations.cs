namespace Explorer.Domain
{
    public class CommentsLocations
    {
        public int LocationId { get; set; }
        public Location Location { get; set; }
        public int CommentId { get; set; }
        public Comment Comment { get; set; }
    }
}