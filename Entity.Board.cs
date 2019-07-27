using System;
using System.Collections.Generic;

namespace logic
{
    class Board
    {
        readonly List<Cell> board;
        public Board() 
        {
            board = new List<Cell>(64);
            for(int x = 0; x < 8; x++) 
            {
                for (int y = 0; y < 8; y++)
                {
                    board.Add(new Cell(x, y));
                }
            }
            board[27].color = status.black;
            board[28].color = status.white;
            board[35].color = status.white;
            board[36].color = status.black;
        }

        public void DisplayBoard() 
        {
            for(int x = 0; x < 8; x++) 
            {
                for (int y = 0; y < 8; y++)
                {
                    status color = board[x*8 + y].color;
                    switch (color) 
                    {
                        case status.empty:
                            Console.Write("O ");
                            break;
                        case status.black:
                            Console.Write("B ");
                            break;
                        case status.white:
                            Console.Write("W ");
                            break;
                    }
                }
                Console.WriteLine();
            }
        }
    }
}