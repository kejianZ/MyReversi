using System;
using System.Collections.Generic;

namespace logic
{
    internal enum Color : int
    {
        empty = 0,
        black = 1,
        white = 2
    };

    internal enum CellStatus : int
    {
        newplaced = 0,
        empty = 1,
        occupied = 2
    }

    internal enum PDirection : int
    {
        nw = 0,
        n = 1,
        ne = 2,
        w = 3,
        e = 4,
        sw = 5,
        s = 6,
        se = 7
    }

    internal class Cell: ISubject<Cell>, IObserver<Cell>
    {
        int x;
        int y;
        internal Color color {get; set;}
        Chessplaced info;
        List<IObserver<Cell>> observers;

        public Cell(int x, int y, int color = 0, int status = 1)
        {
            this.x = x;
            this.y = y;
        }

        public void AttachObserver(IObserver<Cell> observer) => observers.Add(observer);

        public void AnnounceObservers()
        {
            foreach(IObserver<Cell> observer in observers)
            {
                observer.Update(this);
            }
        }

        public void Update(Cell subject)
        {
            throw new NotImplementedException();
        }

        struct Chessplaced
        {
            CellStatus status;
            PDirection dir;
        }
    }
}