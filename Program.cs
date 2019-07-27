using System;
using logic;

namespace chessTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            Board game = new Board();
            game.DisplayBoard();
            game.DisplayBoardTest();
            game.PlaceChess(2,3,2);
            game.DisplayBoard();
            game.DisplayBoardTest();
            Console.ReadKey();
        }
    }
}
