using System;

namespace MagicApp.Stores.UserStore
{
    public class UserState
    {
        public UserState(string name, int iD)
        {
            Name = name;
            ID = iD;
        }

        public string Name { get; }
        public int ID { get; }
    }

    public class User : IStore<UserState>
    {
        private UserState _user;
        private string Name => _user.Name;
        private int ID => _user.ID;
        public UserState State => _user;
        public User()
        {
            _user = new UserState("Guest", 0);
        }
#nullable enable
        public void ChangeState(string? name, int? id) =>
            _user = new UserState(name ?? Name, id ?? ID);
        #region Implementation
        public void ChangeUser(string name, int id)
        {
            _user = new UserState(name, id);
        }

        private Action _listeners;

        public void AddListener(Action listener) => _listeners += listener;
#pragma warning disable CS8601 // Possible null reference assignment.
        public void RemoveListener(Action listener) => _listeners -= listener;
#pragma warning restore CS8601 // Possible null reference assignment.

        public void BroadCast() => _listeners.Invoke();
        #endregion
    }
}
