using oop_practice_9.UserGroup;
namespace oop_practice_9.PostGroup
{
    public class Comment
    {
        public string Text { get; private set; }
        public User Author { get; init; }
        public DateTime Time { get; init; }

        public Comment(string text, User author)
        {
            Text = text;
            Author = author;
            Time = DateTime.Now;
        }
    }
}
