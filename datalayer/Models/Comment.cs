namespace datalayer.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public int? CommentId { get; set; }
        public Comment? Reply { get; set; }
    }
}