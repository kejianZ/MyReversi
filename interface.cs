using System;
using System.Collections.Generic;

namespace logic
{
    /// <summary>
    /// Subject interface
    /// </summary>
    /// <typeparam name="T"> T states the ISubject's type</typeparam>
    public interface ISubject<T>
    {
        void AttachObserver(IObserver<T> observer);
        void AnnounceObservers();
    }

    /// <summary>
    /// Observer interface
    /// </summary>
    /// <typeparam name="T"> T states the type of Subject it's subscribing</typeparam>
    public interface IObserver<T>
    {
        void Update(T subject);
    }
}