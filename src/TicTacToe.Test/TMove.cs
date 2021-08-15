namespace TicTacToe.Test
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Tests <see cref="Move"/>.
    /// </summary>
    [TestClass]
    public class TMove
    {
        /// <summary>
        /// Tests if <see cref="Move.Player"/> is assigned correctly.
        /// </summary>
        [TestMethod]
        public void Player()
        {
            int length = 3;
            int breadth = 3;
            Grid grid = new(length, breadth);
            int players = 2;
            int toWin = 3;
            Game game = new(grid, players, toWin);

            Position toPlay = new(1, 1);

            game.Play(toPlay);

            Assert.AreEqual(0, game.MoveList[0].Player);
        }

        /// <summary>
        /// Tests if <see cref="Move.Position"/> is assigned correctly.
        /// </summary>
        [TestMethod]
        public void Position()
        {
            int length = 3;
            int breadth = 3;
            Grid grid = new(length, breadth);
            int players = 2;
            int toWin = 3;
            Game game = new(grid, players, toWin);

            Position toPlay = new(1, 1);

            game.Play(toPlay);

            Assert.AreEqual(toPlay, game.MoveList[0].Position);
        }
    }
}
