namespace TicTacToe
{
    using System;

    /// <summary>
    /// Defines a player participating in a <see cref="Game"/> of Tic-Tac-Toe.
    /// </summary>
    public struct Player
    {
        /// <summary>
        /// Gets the unique identification number of the <see cref="Player"/>.
        /// </summary>
        public int ID { get; }

        /// <summary>
        /// Gets or sets the  <see cref="Player"/>'s name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Player"/> struct.
        /// </summary>
        /// <param name="id">The unqiue identification number of the  <see cref="Player"/>.</param>
        /// <param name="name">The  <see cref="Player"/>'s name.</param>
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

        /// <summary>
        /// Overrides <see cref="object.Equals(object?)"/>.
        /// </summary>
        /// <param name="obj">The <see cref="object"/> to compare.</param>
        /// <returns>Whether the <see cref="object"/>s are equal.</returns>
        public override bool Equals(object obj)
        {
            return obj is Player player &&
                   this.ID == player.ID &&
                   this.Name == player.Name;
        }

        /// <summary>
        /// Overrides <see cref="object.GetHashCode"/>.
        /// </summary>
        /// <returns>The <see cref="object"/>'s hash code.</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(this.ID, this.Name);
        }

        /// <summary>
        /// Compares two <see cref="Player"/>s.
        /// </summary>
        /// <param name="p1">The first <see cref="Player"/> to compare.</param>
        /// <param name="p2">The second <see cref="Player"/> to compare.</param>
        /// <returns><c>true</c> if <paramref name="p1"/> is equal to <paramref name="p2"/>.</returns>
        public static bool operator ==(Player p1, Player p2)
        {
            return p1.Equals(p2);
        }

        /// <summary>
        /// Compares two <see cref="Player"/>s.
        /// </summary>
        /// <param name="p1">The first <see cref="Player"/> to compare.</param>
        /// <param name="p2">The second <see cref="Player"/> to compare.</param>
        /// <returns><c>true</c> if <paramref name="p1"/> is not equal to <paramref name="p2"/>.</returns>
        public static bool operator !=(Player p1, Player p2)
        {
            return !p1.Equals(p2);
        }
    }
}
