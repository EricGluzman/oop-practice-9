namespace oop_practice_9.UserGroup
{
        public class UserAction
        {
            public ActionType TypeAction { get; init; }
            public DateTime TimeOfAction { get; init; }
            public string Information { get; private set; }

            public UserAction(ActionType typeAction, DateTime timeOfAction, string information)
            {
                TypeAction = typeAction;
                TimeOfAction = timeOfAction;
                Information = information;
            }

            public void UpdateInformation(string info)
            {
                if (info == null) throw new ArgumentNullException();
                Information = info;
            }
        }
}
