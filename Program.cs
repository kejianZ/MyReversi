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
            Console.ReadKey();
        }
    }
}
