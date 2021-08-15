namespace TicTacToe.Test
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TicTacToe;

    /// <summary>
    /// Tests <see cref="TicTacToeException"/>.
    /// </summary>
    [TestClass]
    public class TTicTacToeException
    {
        /// <summary>
        /// Tests if <see cref="TicTacToeException"/> throws an <see cref="Exception"/>.
        /// </summary>
        [TestMethod]
        public void ThrowTicTacToeException()
        {
            bool succeeded = false;

            try
            {
                throw new TicTacToeException();
            }
            catch (TicTacToeException)
            {
                succeeded = true;
            }

            Assert.AreEqual(true, succeeded);
        }

        /// <summary>
        /// Tests if <see cref="TicTacToeException"/> has the correct message.
        /// </summary>
        [TestMethod]
        public void ThrowTicTacToeExceptionWithMessage()
        {
            string expected = "This is a message.";

            try
            {
                throw new TicTacToeException(expected);
            }
            catch (TicTacToeException ex)
            {
                Assert.AreEqual(expected, ex.Message);
            }
        }
    }
}
