namespace TicTacToe
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Represents an <see href="https://en.wikipedia.org/wiki/M,n,k-game">m,n,k game</see>.
    /// </summary>
    public class Game
    {
        /// <summary>
        /// Gets or sets the <see cref="List{T}"/> of <see cref="Player"/>s participating in the <see cref="Game"/>.
        /// </summary>
        public List<Player> Players { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="TicTacToe.Grid"/> the <see cref="Game"/> is being played on.
        /// </summary>
        public Grid Grid { get; set; }

        /// <summary>
        /// Gets or sets the number of tokens needed in a row to win.
        /// </summary>
        public int ToWin { get; set; }

        /// <summary>
        /// Gets the current <see cref="Player"/> to move.
        /// </summary>
        public Player Turn
        {
            get
            {
                return this.Players[this.MoveList.Count % this.Players.Count];
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="List{T}"/> of <see cref="Move"/>s played during the <see cref="Game"/>.
        /// </summary>
        public List<Move> MoveList { get; set; }

        /// <summary>
        /// Gets a list of all possible streaks.
        /// </summary>
        public List<List<Square>> Streaks
        {
            get
            {
                List<List<Square>> streaks = new();

                // Rows
                for (int y = 0; y < this.Grid.Breadth; y++)
                {
                    for (int x = 0; x < this.Grid.Length - this.ToWin; x++)
                    {
                        int initialID = (this.Grid.Length * y) + x;
                        List<Square> squareList = new();

                        for (int j = 0; j < this.ToWin; j++)
                        {
                            squareList.Add(this.Grid.Squares.Where(i => i.ID == initialID + j).FirstOrDefault());
                        }

                        streaks.Add(squareList);
                    }
                }

                // Columns
                for (int y = 0; y < this.Grid.Breadth - this.ToWin; y++)
                {
                    for (int x = 0; x < this.Grid.Length; x++)
                    {
                        int initialID = (this.Grid.Length * y) + x;
                        List<Square> squareList = new();

                        for (int j = 0; j < this.ToWin; j++)
                        {
                            squareList.Add(this.Grid.Squares.Where(i => i.ID == initialID + (this.Grid.Length * j)).FirstOrDefault());
                        }

                        streaks.Add(squareList);
                    }
                }

                // Negative diagonal
                for (int y = 0; y < this.Grid.Breadth; y++)
                {
                    for (int x = 0; x < this.Grid.Length; x++)
                    {
                        try
                        {
                            int initialID = (this.Grid.Length * y) + x;
                            List<Square> squareList = new();

                            for (int j = 0; j < this.ToWin; j++)
                            {
                                squareList.Add(this.Grid.Squares.Where(i => i.ID == initialID + (this.Grid.Length * j) + 1).FirstOrDefault());
                            }

                            streaks.Add(squareList);
                        }
#pragma warning disable
                        catch (IndexOutOfRangeException ex)
#pragma warning restore
                        { }
                    }
                }

                // Positive diagonal
                for (int y = 0; y < this.Grid.Breadth; y++)
                {
                    for (int x = 0; x < this.Grid.Length; x++)
                    {
                        try
                        {
                            int initialID = (this.Grid.Length * y) + x;
                            List<Square> squareList = new();

                            for (int j = 0; j < this.ToWin; j++)
                            {
                                squareList.Add(this.Grid.Squares.Where(i => i.ID == initialID + (this.Grid.Length * j) - 1).FirstOrDefault());
                            }

                            streaks.Add(squareList);
                        }
#pragma warning disable
                        catch (IndexOutOfRangeException ex)
#pragma warning restore
                        { }
                    }
                }

                return streaks;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the <see cref="Game"/> is over.
        /// </summary>
        public bool IsOver
        {
            get
            {
                if (this.IsDraw || this.Winner != null)
                {
                    return true;
                }

                return false;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the <see cref="Game"/> is a draw.
        /// </summary>
        public bool IsDraw
        {
            get
            {
                // Has winner
                if (this.Winner != null)
                {
                    return false;
                }

                // No empty square and no winner
                if (this.Grid.Squares.Where(i => i.Player == null).Count() == 0)
                {
                    return true;
                }

                // Have empty squares and no winner
                return false;
            }
        }

        /// <summary>
        /// Gets the <see cref="Player"/> that won the <see cref="Game"/>.
        /// </summary>
        public Player? Winner
        {
            get
            {
                foreach (List<Square> streak in this.Streaks)
                {
                    (bool succeed, Player? winner) = this.CheckForWinner(streak);

                    if (succeed)
                    {
                        return winner;
                    }
                }

                return null;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Game"/> class.
        /// </summary>
        /// <param name="grid">The <see cref="TicTacToe.Grid"/> the <see cref="Game"/> is being played on.</param>
        /// <param name="players">The <see cref="List{T}"/> of <see cref="Player"/>s participating in the <see cref="Game"/>.</param>
        /// <param name="toWin">The number of tokens needed in a row to win.</param>
        public Game(Grid grid, List<Player> players, int toWin)
        {
            if (toWin < 1)
            {
                throw new TicTacToeException("Game.ToWin too small.");
            }
            else if (grid.Breadth > toWin && grid.Length > toWin)
            {
                throw new TicTacToeException("Number of tokens to win too big.");
            }

            this.Grid = grid;
            this.Players = players;
            this.ToWin = toWin;
            this.MoveList = new();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Game"/> class from another game.
        /// </summary>
        /// <param name="game">The <see cref="Game"/> to clone.</param>.
        public Game(Game game)
        {
            this.Grid = new Grid(game.Grid);
            this.ToWin = game.ToWin;
            this.MoveList = game.MoveList.ToList();
        }

        /// <summary>
        /// Checks if a <see cref="List{T}"/> of <see cref="Square"/>s have been played by the same <see cref="Player"/>.
        /// </summary>
        /// <param name="streak">The <see cref="List{T}"/> of <see cref="Square"/>s to check.</param>
        /// <returns>A tuple. The first item indicates if there is a winner. The second item contains the <see cref="Player"/> that won.</returns>
        public (bool, Player?) CheckForWinner(List<Square> streak)
        {
            if (streak.Count != this.ToWin)
            {
                throw new Exception("Number of squares must be equal to the number of squares required to win.");
            }

            if (streak.Where(i => i.Player != null).Select(i => i.Player).Distinct().Count() == 1)
            {
                return (true, streak.First().Player);
            }

            return (false, null);
        }

        /// <summary>
        /// Adds a token to the a <see cref="Position"/>.
        /// </summary>
        /// <param name="position">The column to play in. <c>0</c> means the leftmost column.</param>
        public void Play(Position position)
        {
            Square? square = this.Grid.Squares.Where(i => i.Position == position).FirstOrDefault();

            if (square == null)
            {
                throw new TicTacToeException("Invalid position.");
            }

            square.Player = this.Turn;

            this.MoveList.Add(new Move(this.Turn, position));
        }

        /// <summary>
        /// Undoes the latest <see cref="Move"/>.
        /// </summary>
        public void Undo()
        {
            Move move = this.MoveList.Last();
            Square? square = this.Grid.Squares.Where(i => i.Position == move.Position).FirstOrDefault();

            if (square == null)
            {
                throw new TicTacToeException("Invalid position");
            }

            square.Player = null;

            this.MoveList.Remove(move);
        }

        /// <summary>
        /// Gets a <see cref="List{T}"/> of legal moves.
        /// </summary>
        /// <returns>A <see cref="List{T}"/> of all legal moves.</returns>
        public List<Position> LegalMoves()
        {
            return this.Grid.Squares.Where(i => i.Player == null).ToList().Select(i => i.Position).ToList();
        }

        /// <summary>
        /// Evaluates the current <see cref="Game"/> state with respect to the current player. Only works with 2 players.
        /// </summary>
        /// <returns>The evaluation of the current <see cref="Game"/> state.</returns>
        public int Evalutation()
        {
            if (this.Players.Count != 2)
            {
                throw new TicTacToeException("Number of players must be 2 for evaluation to work.");
            }

            // Game ended in a draw.
            if (this.IsDraw)
            {
                return 0;
            }

            // Game ended decicively.
            if (this.Winner != null)
            {
                // Current player won.
                if ((Player)this.Winner == this.Turn)
                {
                    return int.MaxValue;
                }

                // Current player lost.
                return int.MinValue;
            }

            // Evaluate the current position.
            // If a streak only has one player in it (excluding `null), assign it a value.
            // The more tokens in the streak, the better.
            // Assignment uses 2^x, where x is the number of tokens placed.
            // This value is negated if the opponent is the player that placed those tokens.
            int evaluation = 0;

            foreach (List<Square> streak in this.Streaks)
            {
                List<Player?> players = streak.Where(i => i.Player != null).Select(i => i.Player).ToList();

                if (players.Distinct().Count() == 1)
                {
                    int value = (int)Math.Pow(2, streak.Where(i => i.Player != null).Count());
                    int multiplier = (players[0] == this.Turn) ? 1 : -1;

                    evaluation += multiplier * value;
                }
            }

            return evaluation;
        }
    }
}
