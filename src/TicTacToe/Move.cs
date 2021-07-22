namespace TicTacToe
{
    /// <summary>
    /// Defines a move.
    /// </summary>
    public struct Move
    {
        /// <summary>
        /// Gets the player that made the <see cref="Move"/>.
        /// </summary>
        public Player Player { get; }

        /// <summary>
        /// Gets the position of the <see cref="Move"/> made.
        /// </summary>
        public Position Position { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Move"/> struct.
        /// </summary>
        /// <param name="player">The player that made the <see cref="Move"/>.</param>
        /// <param name="position">The position of the <see cref="Move"/> made.</param>
        public Move(Player player, Position position)
        {
            this.Player = player;
            this.Position = position;
        }
    }
}
