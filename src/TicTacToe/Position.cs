namespace TicTacToe
{
    using System;

    /// <summary>
    /// Defines a coordinate.
    /// </summary>
    public struct Position
    {
        /// <summary>
        /// Gets the X-coordinate.
        /// </summary>
        public int X { get; }

        /// <summary>
        /// Gets the Y-coordinate.
        /// </summary>
        public int Y { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Position"/> struct.
        /// </summary>
        /// <param name="x">The x-coodinate.</param>
        /// <param name="y">The y-coordinate.</param>
        public Position(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        /// <summary>
        /// Converts the <see cref="Position"/> into a <see cref="string"/>.
        /// </summary>
        /// <returns>The <see cref="Position"/> as a <see cref="string"/>.</returns>
        public override string ToString()
        {
            return $"({this.X}, {this.Y})";
        }

        /// <summary>
        /// Overrides <see cref="object.Equals(object?)"/>.
        /// </summary>
        /// <param name="obj">The <see cref="object"/> to compare.</param>
        /// <returns>Whether the <see cref="object"/>s are equal.</returns>
        public override bool Equals(object obj)
        {
            return obj is Position position &&
                   this.X == position.X &&
                   this.Y == position.Y;
        }

        /// <summary>
        /// Overrides <see cref="object.GetHashCode"/>.
        /// </summary>
        /// <returns>The <see cref="object"/>'s hash code.</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(this.X, this.Y);
        }

        /// <summary>
        /// Compares two <see cref="Position"/>s.
        /// </summary>
        /// <param name="p1">The first <see cref="Position"/> to compare.</param>
        /// <param name="p2">The second <see cref="Position"/> to compare.</param>
        /// <returns><c>true</c> if <paramref name="p1"/> is equal to <paramref name="p2"/>.</returns>
        public static bool operator ==(Position p1, Position p2)
        {
            return p1.Equals(p2);
        }

        /// <summary>
        /// Compares two <see cref="Position"/>s.
        /// </summary>
        /// <param name="p1">The first <see cref="Position"/> to compare.</param>
        /// <param name="p2">The second <see cref="Position"/> to compare.</param>
        /// <returns><c>true</c> if <paramref name="p1"/> is not equal to <paramref name="p2"/>.</returns>
        public static bool operator !=(Position p1, Position p2)
        {
            return !p1.Equals(p2);
        }
    }
}