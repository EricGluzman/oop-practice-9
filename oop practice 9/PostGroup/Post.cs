using oop_practice_9.Exceptions;
using System.Drawing;
using oop_practice_9.UserGroup;
using System.Security.Cryptography.X509Certificates;

namespace oop_practice_9.PostGroup
{
    public class Post
    {
        private List<Comment> _commets = new(); // claude, another question, is it better to write new() or write it in Ctor ? and how does it work.
        private HashSet<User> _likes = new();
        public IReadOnlyList<Comment> Comments => _commets;
        public IReadOnlyCollection<User> Likes => _likes;
        public string Text { get; private set; }
        public Color[,] Photo { get; private set; }
        public User Author { get; init; }

        public Post(string text, Color[,] photo, User author)
        {
            Text = text;
            Photo = photo;
            Author = author;
        }
        public Post(string text, User author)
        {
            Text = text;
            Author = author;
        }
        public void AddCommnet(Comment comment)
        {
            if(comment == null) throw new ArgumentNullException();
            _commets.Add(comment);
        }
        public void AddLike(User user)
        {
            if(user == null ) throw new ArgumentNullException();
            if (!_likes.Add(user)) throw new LikeException("User Has Already Liked That Post");
        }
        public void RemoveLike(User user)
        {
            if (user == null) throw new ArgumentNullException();
            else if (!_likes.Remove(user)) throw new Exception("User has not liked the post / not exsist to remove the like");
        }
    }
}
