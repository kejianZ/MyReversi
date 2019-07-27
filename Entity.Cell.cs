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
        checking = 2,
        needflip = 3
    }

    internal enum ReleatedDir : int
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
        public int x {get;}
        public int y {get;}
        public Color color;
        CellStatus status;
        ReleatedDir direction;
        Color checkingcolor;
        List<IObserver<Cell>> observers = new List<IObserver<Cell>>();

        public Cell(int x, int y, int color = 0, int status = 1)
        {
            this.x = x;
            this.y = y;
            this.color = (Color)color;
            this.status = (CellStatus)status;
        }

        public bool TextDisplayHelper(out int color)
        {
            color = -1;
            if (status == CellStatus.needflip || status == CellStatus.newplaced) 
            {
                color = (this.color == Color.white)? 0:1;
                return true;
            }
            return false;
        }

        public void PlaceChess(int pcolor) 
        {
            color = (Color)pcolor;
            status = CellStatus.newplaced;
            checkingcolor = color;
            AnnounceObservers();
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
            if (status == CellStatus.empty)
            {
                return;
            }
            
            switch(subject.status)
            {
                case CellStatus.newplaced:
                    {
                        if (color != subject.color)
                        {
                            checkingcolor = subject.color;
                            direction = CalDir(subject);
                            status = CellStatus.checking;
                            AnnounceObservers();
                        }
                    }
                    break;

                case CellStatus.checking:
                    {
                        ReleatedDir dir = CalDir(subject);
                        if (dir == subject.direction)
                        {
                            if (subject.checkingcolor == color)
                            {
                                direction = ReverseDir(subject.direction);
                                status = CellStatus.needflip;
                            }
                            else
                            {
                                direction = dir;
                                checkingcolor = subject.checkingcolor;
                                status = CellStatus.checking;
                            }
                            AnnounceObservers();
                        }
                    }
                    break;

                case CellStatus.needflip:
                    {
                        ReleatedDir dir = CalDir(subject);
                        if (dir == subject.direction)
                        {
                            if(status == CellStatus.newplaced) return;
                            direction = dir;
                            color = (Color)(3 - (int)color);
                            status = CellStatus.needflip;
                            AnnounceObservers();
                        }
                    }
                    break;
            }
        }

        ReleatedDir CalDir(Cell cell)
        {
            if(x == cell.x - 1) 
            {
                if(y == cell.y - 1) return ReleatedDir.nw;
                else if(y == cell.y) return ReleatedDir.n;
                else return ReleatedDir.ne;
            }
            else if (x == cell.x + 1)
            {
                if(y == cell.y - 1) return ReleatedDir.sw;
                else if(y == cell.y) return ReleatedDir.s;
                else return ReleatedDir.se;
            }
            else if (y == cell.y - 1) return ReleatedDir.w;
            else return ReleatedDir.e;
        }

        ReleatedDir ReverseDir(ReleatedDir dir) => (ReleatedDir)(7-(int)dir);
    }
}