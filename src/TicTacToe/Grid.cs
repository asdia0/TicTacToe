namespace TicTacToe
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Represents a grid a <see cref="Game"/> of Tic-Tac-Toe is played on.
    /// </summary>
    public class Grid
    {
        /// <summary>
        /// Value determining whether <see cref="Length"/> has been set.
        /// </summary>
        private bool LengthSet = false;

        private int _Length;

        /// <summary>
        /// Value determining whether <see cref="Breadth"/> has been set.
        /// </summary>
        private bool BreadthSet = false;

        private int _Breadth;

        /// <summary>
        /// Gets or sets the length (x-axis) of the <see cref="Grid"/>.
        /// </summary>
        public int Length
        {
            get
            {
                return this._Length;
            }

            set
            {
                if (!this.LengthSet)
                {
                    this._Length = value;
                }

                this.LengthSet = true;
            }
        }

        /// <summary>
        /// Gets or sets the breadth (y-axis) of the <see cref="Grid"/>.
        /// </summary>
        public int Breadth
        {
            get
            {
                return this._Breadth;
            }

            set
            {
                if (!this.BreadthSet)
                {
                    this._Breadth = value;
                }

                this.BreadthSet = true;
            }
        }

        /// <summary>
        /// Gets or sets a list of <see cref="Square"/>s on the <see cref="Grid"/>.
        /// </summary>
        public List<Square> Squares { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Grid"/> class.
        /// </summary>
        /// <param name="length">The length (x-axis) of the <see cref="Grid"/>.</param>
        /// <param name="breadth">The breadth (y-axis) of the <see cref="Grid"/>.</param>
        public Grid(int length, int breadth)
        {
            this.Length = length;
            this.Breadth = breadth;
            this.Squares = new();

            for (int i = 0; i < length * breadth; i++)
            {
                this.Squares.Add(new Square(this));
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Grid"/> class from another grid.
        /// </summary>
        /// <param name="grid">The <see cref="Grid"/> to clone.</param>
        public Grid(Grid grid)
        {
            this.Length = grid.Length;
            this.Breadth = grid.Breadth;
            this.Squares = grid.Squares.ToList();
        }

        /// <summary>
        /// Converts the <see cref="Grid"/> into a <see cref="string"/>.
        /// </summary>
        /// <returns>The <see cref="Grid"/> as a <see cref="string"/>.</returns>
        public override string ToString()
        {
            string result = string.Empty;

            for (int y = 0; y < this.Breadth; y++)
            {
                for (int x = 0; x < this.Length; x++)
                {
                    result += $"[{this.Squares[(this.Length * y) + x]}]";
                }

                result += "\n";
            }

            return result;
        }
    }
}
