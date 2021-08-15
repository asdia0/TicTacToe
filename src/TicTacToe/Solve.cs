namespace TicTacToe
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using static System.Math;

    /// <summary>
    /// This class contains methods to find the best <see cref="Move"/>.
    /// </summary>
    public static class Solve
    {
        /// <summary>
        /// Finds the best move from a given position.
        /// </summary>
        /// <param name="g">The position to find the best <see cref="Move"/> in.</param>
        /// <param name="depth">The amount of full moves to search.</param>
        /// <returns>(Position to play, the position's score).</returns>
        public static (Position?, int) FindBestMove(Game g, int depth)
        {
            if (g.IsDraw || g.Winner != null || g.Players != 2)
            {
                throw new Exception("Invalid game");
            }

            return AlphaBetaPruning(g, 2 * depth, int.MinValue, int.MaxValue);
        }

        /// <summary>
        /// An implementation of the alpha-beta pruning algorithm.
        /// </summary>
        /// <param name="game">The game to solve.</param>
        /// <param name="depth">The amount of full moves to search through.</param>
        /// <param name="alpha">The value of alpha (maximising player).</param>
        /// <param name="beta">The value of beta (minimising player).</param>
        /// <returns>The position of the best <see cref="Move"/> and its evaluation.</returns>
        private static (Position?, int) AlphaBetaPruning(Game game, int depth, int alpha, int beta)
        {
            bool maxPlayer = game.Turn == 0;

            List<Position> children = game.Grid.Squares.Where(i => i.Player == null).Select(i => i.Position).ToList();

            if (game.IsDraw)
            {
                return (null, 0);
            }

            foreach (Position child in children)
            {
                if (game.IsWinningMove(child))
                {
                    return (child, maxPlayer ? int.MaxValue : int.MinValue);
                }
            }

            if (depth == 0)
            {
                return (null, game.Evaluation());
            }

            if (maxPlayer)
            {
                int value = int.MinValue;
                Dictionary<Position, int> scores = new();

                foreach (Position child in children)
                {
                    Game opp = new(game);
                    opp.Play(child);
                    int score = AlphaBetaPruning(opp, depth - 1, alpha, beta).Item2;
                    scores.Add(child, score);
                    if (score > value)
                    {
                        value = score;
                    }

                    alpha = Max(alpha, value);
                    if (alpha >= beta)
                    {
                        break;
                    }
                }

                return (scores.Aggregate((l, r) => l.Value > r.Value ? l : r).Key, value);
            }
            else
            {
                int value = int.MaxValue;
                Dictionary<Position, int> scores = new();

                foreach (Position child in children)
                {
                    Game opp = new(game);
                    opp.Play(child);
                    int score = AlphaBetaPruning(opp, depth - 1, alpha, beta).Item2;
                    scores.Add(child, score);
                    if (score < value)
                    {
                        value = score;
                    }

                    beta = Max(beta, value);
                    if (alpha >= beta)
                    {
                        break;
                    }
                }

                return (scores.Aggregate((l, r) => l.Value > r.Value ? l : r).Key, value);
            }
        }
    }
}
