using System;
using System.Collections.Generic;

namespace logic
{
    class Board : IObserver<Cell>
    {
        readonly List<Cell> board;
        readonly List<Char> textDisplay;

        public Board()
        {
            board = new List<Cell>(64);
            textDisplay = new List<char>(64);
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    int pos = x * 8 + y;
                    if (pos == 27 || pos == 36)
                    {
                        board.Add(new Cell(x, y, 1));
                        textDisplay.Add('B');
                    }
                    else if (pos == 28 || pos == 35)
                    {
                        board.Add(new Cell(x, y, 2));
                        textDisplay.Add('W');
                    }
                    else
                    {
                        board.Add(new Cell(x, y));
                        textDisplay.Add('O');
                    }
                }
            }
            initObservers();
        }

        public void initObservers()
        {
            foreach (Cell cell in board)
            {
                cell.AttachObserver(this);
                if (cell.x > 0 && cell.y > 0)
                {
                    cell.AttachObserver(board[(cell.x - 1) * 8 + cell.y - 1]);
                    cell.AttachObserver(board[(cell.x - 1) * 8 + cell.y]);
                    cell.AttachObserver(board[cell.x * 8 + cell.y - 1]);
                }
                if (cell.x < 7 && cell.y < 7)
                {
                    cell.AttachObserver(board[(cell.x + 1) * 8 + cell.y + 1]);
                    cell.AttachObserver(board[(cell.x + 1) * 8 + cell.y]);
                    cell.AttachObserver(board[cell.x * 8 + cell.y + 1]);
                }
                if (cell.x > 0 && cell.y < 7) cell.AttachObserver(board[(cell.x - 1) * 8 + cell.y + 1]);
                if (cell.x < 7 && cell.y > 0) cell.AttachObserver(board[(cell.x + 1) * 8 + cell.y - 1]);
            }
        }

        public void PlaceChess(int x, int y, int color) => board[x * 8 + y].PlaceChess(color);

        public void DisplayBoard()
        {
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    Console.Write(textDisplay[8 * x + y]);
                    Console.Write(' ');
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public void DisplayBoardTest()
        {
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    if(board[x*8 + y].color == Color.black) Console.Write("B ");
                    else if(board[x*8 + y].color == Color.white) Console.Write("W ");
                    else Console.Write("O ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public void Update(Cell subject)
        {
            if (subject.TextDisplayHelper(out int color))
            {
                if (color == 0)
                {
                    textDisplay[subject.x * 8 + subject.y] = 'W';
                }
                else
                {
                    textDisplay[subject.x * 8 + subject.y] = 'B';
                }
            }
        }
    }
}