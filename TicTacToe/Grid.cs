namespace TicTacToe
{
    public class Grid
    {
        public bool?[,] Squares;
        
        public Grid()
        {
            this.Squares = new bool?[3, 3];
        }

        public Grid(bool?[,] squares)
        {
            this.Squares = squares;
        }

        public Grid(int x, int y)
        {
            this.Squares = new bool?[y, x];
        }

        public Grid(Grid grid)
        {
            this.Squares = grid.Squares;
        }

        public override string ToString()
        {
            string s = string.Empty;

            for (int x = 0; x < this.Squares.GetLength(0); x++)
            {
                for (int y = 0; y < this.Squares.GetLength(1); y++)
                {
                    switch (this.Squares[x, y])
                    {
                        case null:
                            s += "[ ]";
                            break;
                        case true:
                            s += "[X]";
                            break;
                        case false:
                            s += "[O]";
                            break;
                    }
                }

                s += "\n";
            }

            return s;
        }
    }
}
