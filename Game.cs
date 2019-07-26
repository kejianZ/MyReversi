using System;
using System.Collections.Generic;

namespace logic
{
    class Cell 
    {
        int x;
        int y;
        internal enum status: int
        {
            empty = 0,
            black = 1,
            white = 2
        };
        internal status color {get ; set;}

        internal Cell(int x, int y, int status = 0) 
        {
            this.x = x;
            this.y = y;
        }
    }

    class Board
    {
        readonly List<Cell> board;
        public Board() {
            board = new List<Cell>(64);
            for(int x = 0; x < 8; x++) 
            {
                for (int y = 0; y < 8; y++)
                {
                    board.Add(new Cell(x, y));
                }
            }
            board[27].color = Cell.status.black;
            board[28].color = Cell.status.white;
            board[35].color = Cell.status.white;
            board[36].color = Cell.status.black;
        }

        public void DisplayBoard() 
        {
            for(int x = 0; x < 8; x++) 
            {
                for (int y = 0; y < 8; y++)
                {
                    Cell.status color = board[x*8 + y].color;
                    switch (color) 
                    {
                        case Cell.status.empty:
                            Console.Write("O ");
                            break;
                        case Cell.status.black:
                            Console.Write("B ");
                            break;
                        case Cell.status.white:
                            Console.Write("W ");
                            break;
                    }
                }
                Console.WriteLine();
            }
        }
    }
}