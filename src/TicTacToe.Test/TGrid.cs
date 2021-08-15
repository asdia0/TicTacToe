namespace TicTacToe.Test
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Tests <see cref="Grid"/>.
    /// </summary>
    [TestClass]
    public class TGrid
    {
        /// <summary>
        /// Tests if <see cref="Grid.Length"/> is correctly assigned.
        /// </summary>
        [TestMethod]
        public void Length()
        {
            int length = 3;
            int breadth = 3;
            Grid grid = new(length, breadth);

            Assert.AreEqual(length, grid.Length);
        }

        /// <summary>
        /// Tests if <see cref="Grid.Length"/> does not change when attempting to manually assign it.
        /// </summary>
        [TestMethod]
        public void SetLength()
        {
            int length = 3;
            int breadth = 3;
            Grid grid = new(length, breadth);

            try
            {
                grid.Length++;
            }
            catch (TicTacToeException)
            { }

            Assert.AreEqual(length, grid.Length);
        }

        /// <summary>
        /// Tests if <see cref="Grid.Breadth"/> is correctly assigned.
        /// </summary>
        [TestMethod]
        public void Breadth()
        {
            int length = 3;
            int breadth = 3;
            Grid grid = new(length, breadth);

            Assert.AreEqual(breadth, grid.Breadth);
        }

        /// <summary>
        /// Tests if <see cref="Grid.Breadth"/> does not change when attempting to manually assign it.
        /// </summary>
        [TestMethod]
        public void SetBreadth()
        {
            int length = 3;
            int breadth = 3;
            Grid grid = new(length, breadth);

            try
            {
                grid.Breadth++;
            }
            catch (TicTacToeException)
            { }

            Assert.AreEqual(breadth, grid.Breadth);
        }

        /// <summary>
        /// Tests if <see cref="Grid.Squares"/> has the correct amount of <see cref="Square"/>s.
        /// </summary>
        [TestMethod]
        public void Squares()
        {
            int length = 3;
            int breadth = 3;
            Grid grid = new(length, breadth);

            Assert.AreEqual(length * breadth, grid.Squares.Count);
        }

        /// <summary>
        /// Tests if <see cref="Grid.ToString"/> returns a representation of an empty grid.
        /// </summary>
        [TestMethod]
        public void ToStringNull()
        {
            int length = 3;
            int breadth = 3;
            Grid grid = new(length, breadth);

            string expected = "[][][]\n[][][]\n[][][]\n";

            Assert.AreEqual(expected, grid.ToString());
        }

        /// <summary>
        /// Tests if <see cref="Grid.ToString"/> returns the correct representation of the grid when (1,1) is played.
        /// </summary>
        [TestMethod]
        public void ToString11()
        {
            int length = 3;
            int breadth = 3;
            Grid grid = new(length, breadth);
            int players = 2;
            int toWin = 3;
            Game game = new(grid, players, toWin);

            game.Play(new(1, 1));

            string expected = "[0][][]\n[][][]\n[][][]\n";

            Assert.AreEqual(expected, grid.ToString());
        }
    }
}
