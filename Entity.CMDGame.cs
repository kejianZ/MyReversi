using System;

namespace logic {
    public class Game 
    {
        Board game;
        int round;
        
        public Game() 
        {
            game = new Board();
            round = 0;
        }

        public void Play() 
        {
            game.DisplayBoard();
            while(true)
            {
                string[] placechessCMD = Console.ReadLine().Split(' ');
                if(placechessCMD.Length != 2)
                { 
                    throw new Exception("Please provide coordinate");
                }
                
                try
                {
                    int x = Int32.Parse(placechessCMD[0]);
                    int y = Int32.Parse(placechessCMD[1]);
                    int color = round%2 +1;
                    if(!game.PlaceChess(x, y, color))
                    {
                        Console.WriteLine("The cell is not allowed to place a chess");
                    }
                    else
                    {
                        game.DisplayBoardTest();
                        round++;
                    }
                }
                catch
                {
                    Console.WriteLine("Failed to parse");
                    continue;
                }
            }
        }
    }
}