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
            board[27].color = Color.black;
            board[28].color = Color.white;
            board[35].color = Color.white;
            board[36].color = Color.black;
        }

        public void DisplayBoard() 
        {
            for(int x = 0; x < 8; x++) 
            {
                for (int y = 0; y < 8; y++)
                {
                    Color color = board[x*8 + y].color;
                    switch (color) 
                    {
                        case Color.empty:
                            Console.Write("O ");
                            break;
                        case Color.black:
                            Console.Write("B ");
                            break;
                        case Color.white:
                            Console.Write("W ");
                            break;
                    }
                }
                Console.WriteLine();
            }
        }
    }
}