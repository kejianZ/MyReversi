# MyReversi
This is an implementation of game reversi, it's using the observer pattern implemented in C# by using interface.

This project aim to allow user get familier with observer pattern and a way to realize it in C#, however, not necessary using obsever pattern, since this is not effient.

# How to play
After build with dotnet, you can play reversi with CMD. Input two int split by space to state the location you want to place a piece, the board is 8*8, so both coordinates should be in [0, 7]

Game will display message when the location is not allowed to place a piece or invalid instruction is consumed.

Use "quit" to quit the game.

