using System;
using System.Collections.Generic;

namespace logic
{
    class Subject: ISubject
    {
        readonly List<IObserver> observers;

        internal Subject() {
            observers = new List<IObserver> ();
        }

        void ISubject.AttachObserver(IObserver obesever) => observers.Add(obesever);

        void ISubject.AnnounceObservers()
        {
            foreach(IObserver observer in observers) 
            {
                observer.update(this);
            }
        }  
    }
}