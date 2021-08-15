namespace TicTacToe.Test
{
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Tests <see cref="Square"/>.
    /// </summary>
    [TestClass]
    public class TSquare
    {
        /// <summary>
        /// Tests if <see cref="Square.ID"/> is correctly assigned.
        /// </summary>
        [TestMethod]
        public void ID()
        {
            int length = 3;
            int breadth = 3;
            Grid grid = new(length, breadth);

            for (int i = 0; i < length * breadth; i++)
            {
                Square square = grid.Squares[i];
                Assert.AreEqual(i, square.ID);
            }
        }

        /// <summary>
        /// Tests if <see cref="Square.ID"/> does not change when attempting to manually assign it.
        /// </summary>
        [TestMethod]
        public void SetID()
        {
            int length = 3;
            int breadth = 3;
            Grid grid = new(length, breadth);

            for (int i = 0; i < length * breadth; i++)
            {
                Square square = grid.Squares[i];

                try
                {
                    square.ID++;
                }
#pragma warning disable
                catch (TicTacToeException ex)
#pragma warning restore
                { }

                Assert.AreEqual(i, square.ID);
            }
        }

        /// <summary>
        /// Tests if <see cref="Square.Position"/> is correctly assigned.
        /// </summary>
        [TestMethod]
        public void Position()
        {
            int length = 3;
            int breadth = 3;
            Grid grid = new(length, breadth);

            List<Position> expected = new()
            {
                new(1, 1),
                new(2, 1),
                new(3, 1),
                new(1, 2),
                new(2, 2),
                new(3, 2),
                new(1, 3),
                new(2, 3),
                new(3, 3),
            };

            CollectionAssert.AreEqual(expected, grid.Squares.Select(i => i.Position).ToList());
        }

        /// <summary>
        /// Tests if <see cref="Square.Grid"/> is correctly assigned.
        /// </summary>
        [TestMethod]
        public void Grid()
        {
            int length = 3;
            int breadth = 3;
            Grid grid = new(length, breadth);

            foreach (Square square in grid.Squares)
            {
                Assert.AreEqual(grid, square.Grid);
            }
        }

        /// <summary>
        /// Tests if <see cref="Square.Grid"/> does not change when attempting to manually assign it.
        /// </summary>
        [TestMethod]
        public void SetGrid()
        {
            int length = 3;
            int breadth = 3;
            Grid realGrid = new(length, breadth);
            Grid fakeGrid = new(length, breadth);

            foreach (Square square in realGrid.Squares)
            {
                try
                {
                    square.Grid = fakeGrid;
                }
#pragma warning disable
                catch (TicTacToeException ex)
#pragma warning restore
                { }

                Assert.AreEqual(realGrid, square.Grid);
            }
        }

        /// <summary>
        /// Tests if <see cref="Square.Grid"/> is correctly assigned as <c>null</c> initially.
        /// </summary
        [TestMethod]
        public void PlayerNull()
        {
            int length = 3;
            int breadth = 3;
            Grid grid = new(length, breadth);

            foreach (Square squares in grid.Squares)
            {
                Assert.AreEqual(null, squares.Player);
            }
        }

        /// <summary>
        /// Tests if <see cref="Square.Grid"/> is correctly assigned when <see cref="Game.Play(TicTacToe.Position)"/> is called.
        /// </summary
        [TestMethod]
        public void PlayerNonnull()
        {
            int length = 3;
            int breadth = 3;
            Grid grid = new(length, breadth);
            int players = 2;
            int toWin = 3;
            Game game = new(grid, players, toWin);

            Position toPlay = new(1, 1);

            game.Play(toPlay);

            List<Square> playedSquares = grid.Squares.Where(i => i.Player != null).ToList();

            Assert.AreEqual(1, playedSquares.Count());
            Assert.AreEqual(toPlay, playedSquares.First().Position);
        }

        /// <summary>
        /// Tests if <see cref="Square.ToString"/> returns a correct string.
        /// </summary>
        [TestMethod]
        public void TToString()
        {
            int length = 3;
            int breadth = 3;
            Grid grid = new(length, breadth);
            int players = 2;
            int toWin = 3;
            Game game = new(grid, players, toWin);

            Position toPlay = new(1, 1);

            game.Play(toPlay);

            foreach (Square square in grid.Squares)
            {
                if (square.Player != null)
                {
                    Assert.AreEqual(square.Player.ToString(), square.ToString());
                }
                else
                {
                    Assert.AreEqual(string.Empty, square.ToString());
                }
            }
        }
    }
}
