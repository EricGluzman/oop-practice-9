using oop_practice_9.Exceptions;
using oop_practice_9.PostGroup;
namespace oop_practice_9.UserGroup
{
    
    public class User
    {
        #region Properties
        private CreditCard _creditcard;
        private List<User> _connections;
        private List<Employment> _pastJobs = new();
        private List<Post> _pastposts = new();
        private List<UserAction> _activityLog = new();
        public IReadOnlyList<UserAction> ActivityLog => _activityLog;
        public IReadOnlyList<Post> PastPosts => _pastposts;
        public Employment CurrentJob { get; private set; }
        public IReadOnlyList<Employment> PastJobs => _pastJobs;
        public IReadOnlyList<User> Connections => _connections;
        public string UserName { get; private set; }
        public string ID { get; private set; }
        public string Email { get; private set; }
        public int Age { get; private set; }
        public Profession Prof { get; private set; }
        public string BIO { get; private set; }
        public bool IsPremium { get; private set; }
        #endregion
        #region Ctor
        public User(string userName, string iD, string email, int age, Profession prof, CreditCard creditcard,string bio)
        {
            UserName = userName;
            ID = iD;
            Email = email;
            Age = age;
            Prof = prof;
            _creditcard = creditcard;
            BIO = bio;
        }
        #endregion
        #region Method
        public void AddConnecion(User other)
        {
            if (other == null) throw new ConnectionsException("Cannot add null user.");
            _connections.Add(other);
            other._connections.Add(this);
            AddLog(ActionType.ConnectedWith, "Connected");
        }
        public void RemoveConnection(User other)
        {
            if (_connections.Remove(other)) other._connections.Remove(this);
            else throw new ConnectionsException("Cannot find the user to remove.");
            AddLog(ActionType.RemoveConnection, "Removed Connection");
        }

        public void ChangeJob(Employment job) // for claude. is it better to create a new instance of 'job' ? or just leave it CurrentJob = job; ?
        {
            if (job == null) throw new ArgumentNullException(nameof(job), "Cannot work with null job.");
            _pastJobs.Add(CurrentJob);
            CurrentJob = job;
            AddLog(ActionType.ChangedJob, "ChangedJob");
        }
        public void ChangeBio(string bio)
        {
            if (bio == null) throw new ArgumentNullException(nameof(bio), "Provided null bio.");
            BIO = bio;
            AddLog(ActionType.ProfileUpdated, "Updated Bio");
        }
        public void UploadPost(string text)
        {
            if (text == null) throw new ArgumentNullException();
            _pastposts.Add(new Post(text,this));
            AddLog(ActionType.Post, "Added A new post");
        }
        public void CommentOnPost(Post post, string text)
        {
            if (post == null) throw new ArgumentNullException();
            else if(text == null) throw new ArgumentNullException();
            post.AddCommnet(new(text,this));
            AddLog(ActionType.Comment, "Added a comment to post");
        }
        public void LikePost(Post post)
        {
            if (post == null) throw new ArgumentNullException();
            post.AddLike(this);
            AddLog(ActionType.Like, "liked post");
        }
        public void RemoveLike(Post post)
        {
            if (post == null) throw new ArgumentNullException();
            post.RemoveLike(this);
            AddLog(ActionType.RemovedLike, "Removed like");
        }
        public void MakeUserPremium()
        {
            if (IsPremium == true) throw new ChangeStatusException("User Already Has Premium");
            IsPremium = true;
        }
        public void RemoveUserPremiun()
        {
            if (IsPremium != true) throw new ChangeStatusException("User has no premium to remove.");
            IsPremium = false;
        }
        #endregion
        #region Private
        private void AddLog(ActionType action,string info)
        {
            _activityLog.Add(new(action, DateTime.Now, info));
        }
        #endregion
        public override string ToString()
        {
            return $"Name: {UserName}, etc etc etc, IsPremium {IsPremium}";
        }
        public override bool Equals(object? obj)
        {
            if (obj is not User other) throw new ArgumentException("Cannot Equal non user.");
            return UserName == other.UserName && ID == other.ID && Email == other.Email && IsPremium == other.IsPremium;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(UserName, ID, Email, IsPremium );
        }
    }
}
