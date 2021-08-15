namespace TicTacToe.Test
{
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Tests <see cref="Position"/>.
    /// </summary>
    [TestClass]
    public class TPosition
    {
        /// <summary>
        /// Tests if <see cref="Position.X"/> is correctly assigned.
        /// </summary>
        [TestMethod]
        public void X()
        {
            int length = 3;
            int breadth = 3;
            Grid grid = new(length, breadth);

            List<int> expected = new()
            {
                1,
                2,
                3,
                1,
                2,
                3,
                1,
                2,
                3,
            };

            CollectionAssert.AreEqual(expected, grid.Squares.Select(i => i.Position.X).ToList());
        }

        /// <summary>
        /// Tests if <see cref="Position.Y"/> is correctly assigned.
        /// </summary>
        [TestMethod]
        public void Y()
        {
            int length = 3;
            int breadth = 3;
            Grid grid = new(length, breadth);

            List<int> expected = new()
            {
                1,
                1,
                1,
                2,
                2,
                2,
                3,
                3,
                3,
            };

            CollectionAssert.AreEqual(expected, grid.Squares.Select(i => i.Position.Y).ToList());
        }

        /// <summary>
        /// Tests if <see cref="Position.Equals(object)"/> is correct.
        /// </summary>
        [TestMethod]
        public void Equal()
        {
            Position original = new(1, 1);
            Position clone = new(original.X, original.Y);
            Position fake = new(original.X, original.Y + 1);

            Assert.AreEqual(true, original.Equals(clone));
            Assert.AreEqual(false, original.Equals(fake));
        }
    }
}
