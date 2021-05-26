namespace TicTacToe
{
    using System.Collections.Generic;
    using System.Linq;

    class Solve
    {
        public static (int, int) FindBestMove(Game game)
        {
            Game dummy = new Game(game);

            List<(int, int)> legalMoves = dummy.LegalMoves();

            // Win immediately
            foreach ((int, int) move in legalMoves)
            {
                dummy.Turn = game.Turn;
                dummy.Play(move);

                if (dummy.Winner != null)
                {
                    dummy.Undo(move);
                    return move;
                }

                dummy.Undo(move);
            }

            // Block opponent from immediately winning
            dummy.Turn ^= true;

            foreach ((int, int) move in legalMoves)
            {
                dummy.Play(move);

                if (dummy.Winner != null)
                {
                    dummy.Undo(move);
                    dummy.Turn ^= true;
                    return move;
                }

                dummy.Undo(move);
            }
            dummy.Turn ^= true;

            // Create fork (> 1 way to win)
            int winCounter = 0;
            foreach ((int, int) move in legalMoves)
            {
                dummy.Turn = game.Turn;
                dummy.Play(move);

                dummy.Turn ^= true;

                foreach ((int, int) move2 in dummy.LegalMoves())
                {
                    dummy.Play(move2);

                    if (dummy.Winner != null)
                    {
                        if (winCounter++ > 1)
                        {
                            dummy.Undo(move2);
                            dummy.Turn ^= true;
                            dummy.Undo(move);
                            return move;
                        }
                    }

                    dummy.Undo(move2);
                }
                dummy.Turn ^= true;

                dummy.Undo(move);
            }

            // Block opponent from creating a fork
            winCounter = 0;
            dummy.Turn ^= true;
            foreach ((int, int) move in legalMoves)
            {
                dummy.Turn = game.Turn;
                dummy.Play(move);

                dummy.Turn ^= true;

                foreach ((int, int) move2 in dummy.LegalMoves())
                {
                    dummy.Play(move2);

                    if (dummy.Winner != null)
                    {
                        if (winCounter++ > 1)
                        {
                            dummy.Undo(move2);
                            dummy.Turn ^= true;
                            dummy.Undo(move);
                            dummy.Turn ^= true;
                            return move;
                        }
                    }

                    dummy.Undo(move2);
                }
                dummy.Turn ^= true;

                dummy.Undo(move);
            }
            dummy.Turn ^= true;

            // Create threat of a win/fork
            foreach ((int, int) move in legalMoves)
            {
                dummy.Turn = game.Turn;
                dummy.Play(move);

                dummy.Turn ^= true;

                foreach ((int, int) move2 in dummy.LegalMoves())
                {
                    dummy.Play(move2);

                    if (dummy.Winner != null)
                    {
                        dummy.Undo(move2);
                        dummy.Turn ^= true;
                        dummy.Undo(move);
                        return move;
                    }

                    dummy.Undo(move2);
                }
                dummy.Turn ^= true;

                dummy.Undo(move);
            }

            // Block opponent from creating a threat of a win/fork
            dummy.Turn ^= true;
            foreach ((int, int) move in legalMoves)
            {
                dummy.Turn = game.Turn;
                dummy.Play(move);

                dummy.Turn ^= true;

                foreach ((int, int) move2 in dummy.LegalMoves())
                {
                    dummy.Play(move2);

                    if (dummy.Winner != null)
                    {
                        dummy.Undo(move2);
                        dummy.Turn ^= true;
                        dummy.Undo(move);
                        dummy.Turn ^= true;
                        return move;
                    }

                    dummy.Undo(move2);
                }
                dummy.Turn ^= true;

                dummy.Undo(move);
            }
            dummy.Turn ^= true;

            // Best advantage
            return MostAdvantage(game);
        }

        public static (int, int) MostAdvantage(Game game)
        {
            Dictionary<(int, int), int> scores = new Dictionary<(int, int), int>();

            Game dummy = new Game(game);

            if (game.Turn)
            {
                // maximise

                foreach ((int, int) move in dummy.LegalMoves())
                {
                    dummy.Play(move);

                    scores.Add(move, dummy.Evalutation());

                    dummy.Undo(move);
                }

                return scores.Aggregate((l, r) => l.Value > r.Value ? l : r).Key;
            }
            else
            {
                // minimise

                foreach ((int, int) move in dummy.LegalMoves())
                {
                    dummy.Play(move);

                    scores.Add(move, dummy.Evalutation());

                    dummy.Undo(move);
                }

                return scores.Aggregate((l, r) => l.Value < r.Value ? l : r).Key;
            }
        }
    }
}
