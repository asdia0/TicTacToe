namespace TicTacToe
{
    using System;

    /// <summary>
    /// Defines an exception thrown in this project.
    /// </summary>
    public class TicTacToeException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TicTacToeException"/> class.
        /// </summary>
        public TicTacToeException()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="TicTacToeException"/> class.
        /// </summary>
        /// <param name="message">A message about the exception.</param>
        public TicTacToeException(string message)
            : base(message)
        { }
    }
}
