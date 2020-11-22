using System;

namespace MagicApp.Stores
{
    public interface IStore<T>
    {
        T State { get; }

        void AddListener(Action listener);

        void RemoveListener(Action listener);

        void BroadCast();
    }
}