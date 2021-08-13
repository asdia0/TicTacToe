namespace TicTacToe
{
    using System;

    /// <summary>
    /// Represents a square on a <see cref="TicTacToe.Grid"/>.
    /// </summary>
    public class Square
    {
        /// <summary>
        /// Gets or sets the <see cref="Square"/>'s <see cref="TicTacToe.Position"/> on the <see cref="TicTacToe.Grid"/>.
        /// </summary>
        public Position Position { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="TicTacToe.Grid"/> the <see cref="Square"/> is on.
        /// </summary>
        private Grid Grid { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="TicTacToe.Player"/> that played the <see cref="Square"/>.
        /// </summary>
        private Player? Player { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Square"/> class.
        /// </summary>
        /// <param name="grid">The <see cref="TicTacToe.Grid"/> the <see cref="Square"/> is on.</param>
        /// <param name="position">The <see cref="Square"/>'s <see cref="TicTacToe.Position"/> on the <see cref="TicTacToe.Grid"/>.</param>
        /// <param name="player">The <see cref="TicTacToe.Player"/> that played the <see cref="Square"/>.</param>
        public Square(Grid grid, Position position, Player? player = null)
        {
            foreach (Square square in grid.Squares)
            {
                if (square.Position.X == this.Position.X || square.Position.Y == this.Position.Y)
                {
                    throw new TicTacToeException("Square already exists.");
                }
            }

            this.Grid = grid;
            this.Position = position;
            this.Player = player;
        }

        /// <summary>
        /// Adds a <see cref="TicTacToe.Player"/> to <see cref="Player"/>.
        /// </summary>
        /// <param name="player">The <see cref="TicTacToe.Player"/> to add.</param>
        public void AddPlayer(Player player)
        {
            if (this.Player != null)
            {
                throw new TicTacToeException("Player already exists!");
            }

            this.ChangePlayer(player);
        }

        /// <summary>
        /// Changes <see cref="Player"/> to <c>null</c>.
        /// </summary>
        public void RemovePlayer()
        {
            this.Player = null;
        }

        /// <summary>
        /// Changes the value of <see cref="Player"/> to another <see cref="TicTacToe.Player"/>.
        /// </summary>
        /// <param name="player">The <see cref="TicTacToe.Player"/> to change to.</param>
        public void ChangePlayer(Player player)
        {
            this.Player = player;
        }
    }
}
