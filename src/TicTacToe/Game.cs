namespace TicTacToe
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Game
    {
        public Grid Grid;

        public int ToWin;

        public bool Turn;

        public bool? Winner;

        public Game(Grid grid, int toWin)
        {
            if (toWin < 1)
            {
                throw new Exception("Game.ToWin must be at least 1.");
            }

            this.Grid = grid;
            this.ToWin = toWin;
            this.Turn = true;
            this.Winner = null;
        }

        public Game(Game game)
        {
            this.Grid = new Grid(game.Grid);
            this.ToWin = game.ToWin;
            this.Turn = game.Turn;
            this.Winner = game.Winner;
        }

        public void Play(int x, int y)
        {
            if (this.Winner != null)
            {
                throw new Exception($"Player {((bool)this.Winner ? 1 : 2)} has already won.");
            }

            if (x >= this.Grid.Squares.GetLength(1))
            {
                throw new Exception("X-Coordinate cannot be greater than the grid's length.");
            }

            if (y >= this.Grid.Squares.GetLength(0))
            {
                throw new Exception("Y-Coordinate cannot be greater than the grid's breadth.");
            }

            if (this.Grid.Squares[y, x] != null)
            {
                throw new Exception($"{(x, y)} has already been played");
            }

            this.Grid.Squares[y, x] = this.Turn;

            if (this.HasWinner())
            {
                return;
            }

            this.Turn ^= true;
        }

        public void Play((int, int) xy)
        {
            int x = xy.Item1, y = xy.Item2;

            if (this.Winner != null)
            {
                throw new Exception($"Player {((bool)this.Winner ? 1 : 2)} has already won.");
            }

            if (x >= this.Grid.Squares.GetLength(1))
            {
                throw new Exception("X-Coordinate cannot be greater than the grid's length.");
            }

            if (y >= this.Grid.Squares.GetLength(0))
            {
                throw new Exception("Y-Coordinate cannot be greater than the grid's breadth.");
            }

            if (this.Grid.Squares[y, x] != null)
            {
                throw new Exception($"{(x, y)} has already been played");
            }

            this.Grid.Squares[y, x] = this.Turn;

            if (this.HasWinner())
            {
                return;
            }

            this.Turn ^= true;
        }

        public void Undo(int x, int y)
        {
            if (this.Grid.Squares[y, x] == null)
            {
                throw new Exception("Cannot undo non-existant move.");
            }

            this.Grid.Squares[y, x] = null;

            this.Winner = null;

            this.Turn ^= true;
        }

        public void Undo((int, int) xy)
        {
            int x = xy.Item1, y = xy.Item2;

            if (this.Grid.Squares[y, x] == null)
            {
                throw new Exception("Cannot undo non-existant move.");
            }

            this.Grid.Squares[y, x] = null;

            this.Winner = null;

            this.Turn ^= true;
        }

        public bool HasWinner()
        {
            bool?[,] squares = this.Grid.Squares;

            int p1 = 0;
            int p2 = 0;

            // Get rows
            for (int x = 0; x < squares.GetLength(1); x++)
            {
                p1 = 0;
                p2 = 0;

                for (int y = 0; y < squares.GetLength(0); y++)
                {
                    switch (squares[x, y])
                    {
                        case null:
                            p1 = 0;
                            p2 = 0;
                            break;
                        case true:
                            p1++;
                            p2 = 0;
                            break;
                        case false:
                            p1 = 0;
                            p2++;
                            break;
                    }

                    if (p1 == this.ToWin)
                    {
                        this.Winner = true;
                        return true;
                    }
                    
                    if (p2 == this.ToWin)
                    {
                        this.Winner = false;
                        return true;
                    }
                }
            }

            // Get columns
            for (int y = 0; y < squares.GetLength(0); y++)
            {
                p1 = 0;
                p2 = 0;

                for (int x = 0; x < squares.GetLength(1); x++)
                {
                    switch (squares[x, y])
                    {
                        case null:
                            p1 = 0;
                            p2 = 0;
                            break;
                        case true:
                            p1++;
                            p2 = 0;
                            break;
                        case false:
                            p1 = 0;
                            p2++;
                            break;
                    }

                    if (p1 == this.ToWin)
                    {
                        this.Winner = true;
                        return true;
                    }

                    if (p2 == this.ToWin)
                    {
                        this.Winner = false;
                        return true;
                    }
                }
            }

            // Get positive diagonals
            for (int y = squares.GetLength(0) - 1; y >= this.ToWin - 1; y--)
            {
                for (int x = 0; x < squares.GetLength(1) - this.ToWin + 1; x++)
                {
                    p1 = 0;
                    p2 = 0;

                    for (int increment = 0; increment < this.ToWin; increment++)
                    {
                        switch (squares[y - increment, x + increment])
                        {
                            case null:
                                p1 = 0;
                                p2 = 0;
                                break;
                            case true:
                                p1++;
                                p2 = 0;
                                break;
                            case false:
                                p1 = 0;
                                p2++;
                                break;
                        }

                        if (p1 == this.ToWin)
                        {
                            this.Winner = true;
                            return true;
                        }

                        if (p2 == this.ToWin)
                        {
                            this.Winner = false;
                            return true;
                        }
                    }
                }
            }

            // Get negative diagonals
            for (int y = squares.GetLength(0) - 1; y >= this.ToWin - 1; y--)
            {
                for (int x = squares.GetLength(1) - 1; x >= this.ToWin - 1; x--)
                {
                    p1 = 0;
                    p2 = 0;

                    for (int increment = 0; increment < this.ToWin; increment++)
                    {
                        switch (squares[y - increment, x - increment])
                        {
                            case null:
                                p1 = 0;
                                p2 = 0;
                                break;
                            case true:
                                p1++;
                                p2 = 0;
                                break;
                            case false:
                                p1 = 0;
                                p2++;
                                break;
                        }

                        if (p1 == this.ToWin)
                        {
                            this.Winner = true;
                            return true;
                        }

                        if (p2 == this.ToWin)
                        {
                            this.Winner = false;
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        public List<(int, int)> LegalMoves()
        {
            List<(int, int)> legalMoves = new List<(int, int)>();

            for (int x = 0; x < this.Grid.Squares.GetLength(1); x++)
            {
                for (int y = 0; y < this.Grid.Squares.GetLength(0); y++)
                {
                    try
                    {
                        this.Play(x, y);
                        legalMoves.Add((x, y));
                        this.Undo(x, y);
                    }
                    catch
                    {

                    }
                }
            }

            return legalMoves;
        }

        public int Evalutation()
        {
            bool?[,] squares = this.Grid.Squares;

            int p1, p2, x1, x2, o1, o2;

            p1 = p2 = x1 = x2 = o1 = o2 = 0;

            if (this.Winner == true)
            {
                return int.MaxValue;
            }
            else if (this.Winner == false)
            {
                return int.MinValue;
            }

            if (!this.LegalMoves().Any())
            {
                return 0;
            }

            // Get rows
            for (int x = 0; x < squares.GetLength(0); x++)
            {
                p1 = 0;
                p2 = 0;

                for (int y = 0; y < squares.GetLength(1); y++)
                {
                    switch (squares[x, y])
                    {
                        case true:
                            p1++;
                            break;
                        case false:
                            p2++;
                            break;
                    }
                }

                switch (p1)
                {
                    case 1:
                        x1++;
                        break;
                    case 2:
                        x2++;
                        break;
                }
                switch (p2)
                {
                    case 1:
                        o1++;
                        break;
                    case 2:
                        o2++;
                        break;
                }
            }

            // Get columns
            for (int y = 0; y < squares.GetLength(1); y++)
            {
                p1 = 0;
                p2 = 0;

                for (int x = 0; x < squares.GetLength(0); x++)
                {
                    switch (squares[x, y])
                    {
                        case true:
                            p1++;
                            break;
                        case false:
                            p2++;
                            break;
                    }
                }

                switch (p1)
                {
                    case 1:
                        x1++;
                        break;
                    case 2:
                        x2++;
                        break;
                }
                switch (p2)
                {
                    case 1:
                        o1++;
                        break;
                    case 2:
                        o2++;
                        break;
                }
            }

            // Get positive diagonals
            for (int x = squares.GetLength(0) - 1; x >= this.ToWin - 1; x--)
            {
                for (int y = 0; y < squares.GetLength(1) - this.ToWin + 1; y++)
                {
                    p1 = 0;
                    p2 = 0;

                    for (int increment = 0; increment < this.ToWin; increment++)
                    {
                        switch (squares[x - increment, y + increment])
                        {
                            case true:
                                p1++;
                                break;
                            case false:
                                p2++;
                                break;
                        }
                    }

                    switch (p1)
                    {
                        case 1:
                            x1++;
                            break;
                        case 2:
                            x2++;
                            break;
                    }
                    switch (p2)
                    {
                        case 1:
                            o1++;
                            break;
                        case 2:
                            o2++;
                            break;
                    }
                }
            }

            // Get negative diagonals
            for (int x = squares.GetLength(0) - 1; x >= this.ToWin - 1; x--)
            {
                for (int y = squares.GetLength(1) - 1; y >= this.ToWin - 1; y--)
                {
                    p1 = 0;
                    p2 = 0;

                    for (int increment = 0; increment < this.ToWin; increment++)
                    {
                        switch (squares[x - increment, y - increment])
                        {
                            case true:
                                p1++;
                                break;
                            case false:
                                p2++;
                                break;
                        }
                    }

                    switch (p1)
                    {
                        case 1:
                            x1++;
                            break;
                        case 2:
                            x2++;
                            break;
                    }
                    switch (p2)
                    {
                        case 1:
                            o1++;
                            break;
                        case 2:
                            o2++;
                            break;
                    }
                }
            }

            return 3 * x2 + x1 - (3 * o2 + o1);
        }
    }
}
