using System;
using System.Collections.Generic;

namespace logic
{
    public interface ISubject
    {
        void AttachObserver(IObserver observer);
        void AnnounceObservers();
    }

    public interface IObserver
    {
        void update(ISubject subject);
    }
}