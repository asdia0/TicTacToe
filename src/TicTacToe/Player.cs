namespace TicTacToe
{
    /// <summary>
    /// Defines a player.
    /// </summary>
    public struct Player
    {
        /// <summary>
        /// Gets the unique identification number of the <see cref="Player"/>.
        /// </summary>
        public int ID { get; }

        /// <summary>
        /// Gets or sets the player's name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Player"/> struct.
        /// </summary>
        /// <param name="id">The unqiue identification number of the player.</param>
        /// <param name="name">The player's name.</param>
        public Player(int id, string name)
        {
            this.ID = id;
            this.Name = name;
        }

        /// <summary>
        /// Converts the <see cref="Player"/> into a <see cref="string"/>.
        /// </summary>
        /// <returns>The <see cref="Player"/> as a <see cref="string"/>.</returns>
        public override string ToString()
        {
            return $"{this.ID} ({this.Name})";
        }
    }
}
