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
        /// Value determining whether <see cref="ID"/> has been set.
        /// </summary>
        private bool IDSet = false;

        private int _ID;

        /// <summary>
        /// Value determining whether <see cref="Grid"/> has been set.
        /// </summary>
        private bool GridSet = false;

        private Grid _Grid;

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
        /// Gets or sets the <see cref="TicTacToe.Grid"/> the <see cref="Square"/> is on.
        /// </summary>
        public Grid Grid
        {
            get
            {
                return this._Grid;
            }

            set
            {
                if (!this.GridSet)
                {
                    this._Grid = value;
                }

                this.GridSet = true;
            }
        }

        /// <summary>
        /// Gets or sets the player that played the <see cref="Square"/>.
        /// </summary>
        public int? Player { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Square"/> class.
        /// </summary>
        /// <param name="grid">The <see cref="TicTacToe.Grid"/> the <see cref="Square"/> is on.</param>
        /// <param name="player">The player that played the <see cref="Square"/>.</param>
        public Square(Grid grid, int? player = null)
        {
            this.Grid = grid;
            this.ID = this.Grid.Squares.Count;
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
