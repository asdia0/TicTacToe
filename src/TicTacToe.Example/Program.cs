namespace TicTacToe.Example
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using TicTacToe;

    class Program
    {
        static void Main()
        {
            int length = 3;
            int breadth = 3;
            Grid grid = new(length, breadth);
            int players = 2;
            int toWin = 3;
            Game game = new(grid, players, toWin);

            while (!game.IsOver)
            {
                if (game.Turn == 0)
                {
                    Position toPlay = (Position)Solve.FindBestMove(game, game.Grid.Squares.Where(i => i.Player == null).Count()).Position;
                    game.Play(toPlay);
                    Console.WriteLine($"I have played {toPlay}.");
                    Console.WriteLine(game.Grid);
                }
                else
                {
                    Console.WriteLine("Enter the x-coordinate: ");
                    string stringX = Console.ReadLine();
                    int x = int.Parse(stringX);
                    Console.WriteLine("Enter the y-coordinate: ");
                    string stringY = Console.ReadLine();
                    int y = breadth + 1 - int.Parse(stringY);

                    game.Play(new(x, y));
                    Console.Write(game.Grid);
                }
            }

            if (game.IsDraw)
            {
                Console.WriteLine("Draw!");
            }
            else
            {
                Console.WriteLine("Good game!");
            }
        }
    }
}
