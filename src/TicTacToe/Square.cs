namespace TicTacToe
{
    using System.Linq;
    using static System.Math;

    /// <summary>
    /// Represents a square on a <see cref="TicTacToe.Grid"/>.
    /// </summary>
    public class Square
    {
        /// <summary>
             /// Gets or sets the <see cref="Square"/>'s unique identification number.
             /// </summary>
        public int ID
        {
            get
            {
                return this._ID;
            }

            set
            {
                if (!this.IDSet)
                {
                    if (value >= this.Grid.Length * this.Grid.Breadth)
                    {
                        throw new TicTacToeException("Square ID too big.");
                    }
                    else if (value < 0)
                    {
                        throw new TicTacToeException("Square ID too small.");
                    }

                    this._ID = value;
                }

                this.IDSet = true;
            }
        }

        /// <summary>
        /// Gets the <see cref="Square"/>'s <see cref="TicTacToe.Position"/> on the <see cref="TicTacToe.Grid"/>.
        /// </summary>
        public Position Position
        {
            get
            {
                int x = (this.ID % this.Grid.Length) + 1;
                int y = (int)Floor((double)(this.ID / this.Grid.Length)) + 1;

                return new Position(x, y);
            }
        }

        /// <summary>
        /// Value determining whether <see cref="ID"/> has been set.
        /// </summary>
        private bool IDSet = false;

        private int _ID;

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
        public Square(Grid grid, Player? player = null)
        {
            foreach (Square square in grid.Squares)
            {
                if (square.Position.X == this.Position.X || square.Position.Y == this.Position.Y)
                {
                    throw new TicTacToeException("Square already exists.");
                }
            }

            this.Grid = grid;
            this.ID = grid.Squares.OrderBy(i => i.ID).Last().ID++;
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

        /// <summary>
        /// Converts the <see cref="Square"/> into a <see cref="string"/>.
        /// </summary>
        /// <returns>The <see cref="Square"/> as a <see cref="string"/>.</returns>
        public override string ToString()
        {
            return this.Player.ToString() ?? string.Empty;
        }
    }
}
