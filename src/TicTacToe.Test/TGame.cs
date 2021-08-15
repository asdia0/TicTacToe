namespace TicTacToe.Test
{
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Tests <see cref="Game"/>.
    /// </summary>
    [TestClass]
    public class TGame
    {
        /// <summary>
        /// Tests if <see cref="Game.Players"/> have been correctly assigned.
        /// </summary>
        [TestMethod]
        public void Players()
        {
            int length = 3;
            int breadth = 3;
            Grid grid = new(length, breadth);
            int players = 2;
            int toWin = 3;
            Game game = new(grid, players, toWin);

            Assert.AreEqual(players, game.Players);
        }

        /// <summary>
        /// Tests if <see cref="Game.Grid"/> have been correctly assigned.
        /// </summary>
        [TestMethod]
        public void Grid()
        {
            int length = 3;
            int breadth = 3;
            Grid grid = new(length, breadth);
            int players = 2;
            int toWin = 3;
            Game game = new(grid, players, toWin);

            Assert.AreEqual(grid, game.Grid);
        }

        /// <summary>
        /// Tests if <see cref="Game.ToWin"/> have been correctly assigned.
        /// </summary>
        [TestMethod]
        public void ToWin()
        {
            int length = 3;
            int breadth = 3;
            Grid grid = new(length, breadth);
            int players = 2;
            int toWin = 3;
            Game game = new(grid, players, toWin);

            Assert.AreEqual(toWin, game.ToWin);
        }

        /// <summary>
        /// Tests if <see cref="Game.Turn"/> is correct.
        /// </summary>
        [TestMethod]
        public void Turn()
        {
            int length = 3;
            int breadth = 3;
            Grid grid = new(length, breadth);
            int players = 2;
            int toWin = 3;
            Game game = new(grid, players, toWin);

            for (int i = 0; i <= players; i++)
            {
                if (i == players)
                {
                    Assert.AreEqual(0, game.Turn);
                }
                else
                {
                    Assert.AreEqual(i, game.Turn);
                    game.Play(game.LegalMoves()[0]);
                }
            }
        }

        /// <summary>
        /// Tests if <see cref="Game.Play(Position)"/> affects <see cref="Game.MoveList"/> correctly.
        /// </summary>
        [TestMethod]
        public void MoveList()
        {
            int length = 3;
            int breadth = 3;
            Grid grid = new(length, breadth);
            int players = 2;
            int toWin = 3;
            Game game = new(grid, players, toWin);

            for (int i = 0; i < length * breadth; i++)
            {
                Assert.AreEqual(i, game.MoveList.Count);
                game.Play(game.LegalMoves()[0]);
            }
        }

        /// <summary>
        /// Tests if <see cref="Game.Streaks"/> is correct.
        /// </summary>
        [TestMethod]
        public void Streaks()
        {
            int length = 3;
            int breadth = 3;
            Grid grid = new(length, breadth);
            int players = 2;
            int toWin = 3;
            Game game = new(grid, players, toWin);

            int expected = ((length - toWin + 1) * breadth) + ((breadth - toWin + 1) * length) + (2 * (breadth - toWin + 1) * (length - toWin + 1));

            Assert.AreEqual(expected, game.Streaks.Count);
        }

        /// <summary>
        /// Tests if <see cref="Game.IsOver"/> is correct.
        /// </summary>
        [TestMethod]
        public void IsOver()
        {
            int length = 3;
            int breadth = 3;
            Grid grid = new(length, breadth);
            int players = 2;
            int toWin = 3;
            Game game1 = new(grid, players, toWin);

            game1.Play(new(1, 1));
            game1.Play(new(2, 1));
            game1.Play(new(1, 2));
            game1.Play(new(2, 2));
            game1.Play(new(1, 3));

            Assert.AreEqual(true, game1.IsOver);

            Game game2 = new(grid, players, toWin);

            game2.Play(new(1, 1));
            game2.Play(new(2, 1));
            game2.Play(new(1, 2));
            game2.Play(new(2, 2));
            game2.Play(new(3, 1));
            game2.Play(new(3, 2));
            game2.Play(new(3, 3));
            game2.Play(new(1, 3));
            game2.Play(new(2, 3));

            Assert.AreEqual(true, game2.IsOver);
        }

        /// <summary>
        /// Tests if <see cref="Game.IsDraw"/> is correct.
        /// </summary>
        [TestMethod]
        public void IsDraw()
        {
            int length = 3;
            int breadth = 3;
            Grid grid = new(length, breadth);
            int players = 2;
            int toWin = 3;
            Game game = new(grid, players, toWin);

            game.Play(new(1, 1));
            game.Play(new(2, 1));
            game.Play(new(1, 2));
            game.Play(new(2, 2));
            game.Play(new(3, 1));
            game.Play(new(3, 2));
            game.Play(new(3, 3));
            game.Play(new(1, 3));
            game.Play(new(2, 3));

            Assert.AreEqual(true, game.IsDraw);
        }

        /// <summary>
        /// Tests if <see cref="Game.Winner"/> is correctly assigned initially.
        /// </summary>
        [TestMethod]
        public void WinnerNull()
        {
            int length = 3;
            int breadth = 3;
            Grid grid = new(length, breadth);
            int players = 2;
            int toWin = 3;
            Game game = new(grid, players, toWin);

            Assert.AreEqual(null, game.Winner);
        }

        /// <summary>
        /// Tests if <see cref="Game.Winner"/> is correct.
        /// </summary>
        [TestMethod]
        public void WinnerNonnull()
        {
            int length = 3;
            int breadth = 3;
            Grid grid = new(length, breadth);
            int players = 2;
            int toWin = 3;
            Game game = new(grid, players, toWin);

            game.Play(new(1, 1));
            game.Play(new(2, 1));
            game.Play(new(1, 2));
            game.Play(new(2, 2));
            game.Play(new(1, 3));

            Assert.AreEqual(0, game.Winner);
        }

        /// <summary>
        /// Tests if <see cref="Game.CheckForWinner(System.Collections.Generic.List{Square})"/> is correct.
        /// </summary>
        [TestMethod]
        public void CheckWinnerTrue()
        {
            int length = 3;
            int breadth = 3;
            Grid grid = new(length, breadth);
            int players = 2;
            int toWin = 3;
            Game game = new(grid, players, toWin);

            game.Play(new(1, 1));
            game.Play(new(2, 1));
            game.Play(new(1, 2));
            game.Play(new(2, 2));
            game.Play(new(1, 3));

            List<Square> expected = new();
            expected.Add(grid.Squares.Where(i => i.Position == new Position(1, 1)).FirstOrDefault());
            expected.Add(grid.Squares.Where(i => i.Position == new Position(1, 2)).FirstOrDefault());
            expected.Add(grid.Squares.Where(i => i.Position == new Position(1, 3)).FirstOrDefault());

            Assert.AreEqual((true, 0), game.CheckForWinner(expected));
        }

        /// <summary>
        /// Tests if <see cref="Game.CheckForWinner(System.Collections.Generic.List{Square})"/> is correct.
        /// </summary>
        [TestMethod]
        public void CheckWinnerFalse()
        {
            int length = 3;
            int breadth = 3;
            Grid grid = new(length, breadth);
            int players = 2;
            int toWin = 3;
            Game game = new(grid, players, toWin);

            List<Square> expected = new();
            expected.Add(grid.Squares.Where(i => i.Position == new Position(1, 1)).FirstOrDefault());
            expected.Add(grid.Squares.Where(i => i.Position == new Position(1, 2)).FirstOrDefault());
            expected.Add(grid.Squares.Where(i => i.Position == new Position(1, 3)).FirstOrDefault());

            Assert.AreEqual((false, null), game.CheckForWinner(expected));
        }

        /// <summary>
        /// Tests if <see cref="Game.Play(Position)"/> is correct.
        /// </summary>
        [TestMethod]
        public void Play()
        {
            int length = 3;
            int breadth = 3;
            Grid grid = new(length, breadth);
            int players = 2;
            int toWin = 3;
            Game game = new(grid, players, toWin);
            Position position = new(1, 1);

            Square square = game.Grid.Squares.Where(i => i.Position == position).FirstOrDefault();

            Assert.AreEqual(null, square.Player);

            game.Play(position);

            Assert.AreEqual(0, square.Player);
        }

        /// <summary>
        /// Tests if <see cref="Game.Undo()"/> is correct.
        /// </summary>
        [TestMethod]
        public void Undo()
        {
            int length = 3;
            int breadth = 3;
            Grid grid = new(length, breadth);
            int players = 2;
            int toWin = 3;
            Game game = new(grid, players, toWin);
            Position position = new(1, 1);

            Square square = game.Grid.Squares.Where(i => i.Position == position).FirstOrDefault();

            Assert.AreEqual(null, square.Player);

            game.Play(position);

            Assert.AreEqual(0, square.Player);

            game.Undo();

            Assert.AreEqual(null, square.Player);
        }

        /// <summary>
        /// Tests if <see cref="Game.LegalMoves"/> is correct.
        /// </summary>
        [TestMethod]
        public void LegalMoves()
        {
            int length = 3;
            int breadth = 3;
            Grid grid = new(length, breadth);
            int players = 2;
            int toWin = 3;
            Game game = new(grid, players, toWin);

            for (int i = 0; i < length * breadth; i++)
            {
                Assert.AreEqual((length * breadth) - i, game.LegalMoves().Count);
                game.Play(game.LegalMoves().First());
            }
        }

        /// <summary>
        /// Tests if <see cref="Game.IsWinningMove(Position)"/> is correct.
        /// </summary>
        [TestMethod]
        public void IsWinningMoveTrue()
        {
            int length = 3;
            int breadth = 3;
            Grid grid = new(length, breadth);
            int players = 2;
            int toWin = 3;
            Game game = new(grid, players, toWin);

            game.Play(new(1, 1));
            game.Play(new(2, 1));
            game.Play(new(1, 2));
            game.Play(new(2, 2));

            Assert.AreEqual(true, game.IsWinningMove(new(1, 3)));
        }

        /// <summary>
        /// Tests if <see cref="Game.IsWinningMove(Position)"/> is correct.
        /// </summary>
        [TestMethod]
        public void IsWinningMoveFalse()
        {
            int length = 3;
            int breadth = 3;
            Grid grid = new(length, breadth);
            int players = 2;
            int toWin = 3;
            Game game = new(grid, players, toWin);

            game.Play(new(1, 1));
            game.Play(new(2, 1));
            game.Play(new(1, 2));
            game.Play(new(2, 2));

            Assert.AreEqual(false, game.IsWinningMove(new(3, 1)));
        }

        /// <summary>
        /// Tests if <see cref="Game.Evaluation"/> is correct.
        /// </summary>
        [TestMethod]
        public void EvaluationWin()
        {
            int length = 3;
            int breadth = 3;
            Grid grid = new(length, breadth);
            int players = 2;
            int toWin = 3;
            Game game = new(grid, players, toWin);

            game.Play(new(1, 1));
            game.Play(new(2, 1));
            game.Play(new(1, 2));
            game.Play(new(2, 2));
            game.Play(new(1, 3));

            Assert.AreEqual(int.MaxValue, game.Evaluation(0));
        }

        /// <summary>
        /// Tests if <see cref="Game.Evaluation"/> is correct.
        /// </summary>
        [TestMethod]
        public void EvaluationLoss()
        {
            int length = 3;
            int breadth = 3;
            Grid grid = new(length, breadth);
            int players = 2;
            int toWin = 3;
            Game game = new(grid, players, toWin);

            game.Play(new(3, 1));
            game.Play(new(1, 1));
            game.Play(new(2, 1));
            game.Play(new(1, 2));
            game.Play(new(2, 2));
            game.Play(new(1, 3));

            Assert.AreEqual(int.MinValue, game.Evaluation(0));
        }

        /// <summary>
        /// Tests if <see cref="Game.Evaluation"/> is correct.
        /// </summary>
        [TestMethod]
        public void Evaluation()
        {
            int length = 3;
            int breadth = 3;
            Grid grid = new(length, breadth);
            int players = 2;
            int toWin = 3;
            Game game = new(grid, players, toWin);

            game.Play(new(2, 1));

            Assert.AreEqual(-4, game.Evaluation(1));
        }
    }
}
