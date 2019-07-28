using System;
using logic;

namespace chessTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            Game game = new Game();
            game.Play();
            Console.ReadKey();
        }
    }
}
