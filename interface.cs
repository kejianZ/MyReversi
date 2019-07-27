using System;
using System.Collections.Generic;

namespace logic
{
    public interface ISubject
    {
        void AttachObserver(IObesever observer);
        void AnnounceObservers();
    }

    public interface IObesever
    {
        void update(ISubject subject);
    }
}