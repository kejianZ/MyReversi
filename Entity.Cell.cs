using System;
using System.Collections.Generic;

namespace logic
{
    internal enum status : int
    {
        empty = 0,
        black = 1,
        white = 2
    };

    internal class Cell: Subject
    {
        int x;
        int y;
        internal status color {get ; set;}

        public Cell(int x, int y, int status = 0)
        {
            this.x = x;
            this.y = y;
        }        
    }
}