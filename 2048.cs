
using System;
using System.Linq;
using System.Collections.Generic;


namespace Game
{  
    // Program
    class Mainclass
    {
        private static void RunTest()
        {
            Console.WriteLine("[Test]");
            try
            {
                TestGrid.TestCreateGrid();
                TestGrid.TestSpawn();
                TestGrid.TestMoveUp();
                TestGrid.TestMoveDown();
                TestGrid.TestMoveLeft();
                TestGrid.TestMoveRight();
                TestGrid.TestMoveResult();
                TestGrid.TestMoveResultFalse();
                TestGrid.TestIsFinished();
                TestGrid.TestIsNotFinished();
                TestGrid.TestMergeUp();
                TestGrid.TestMergeDown();
                TestGrid.TestMergeLeft();
                TestGrid.TestMergeRight();
                TestGrid.TestWTF();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        // play automatically
        private static void PlayAutomatically()
        {
            Console.Clear();
            Console.WriteLine("[Play Game]");
            var results = new List<Tuple<Grid, int>>();
            for (int i = 0; i < 200; i++)
            {
                var game = new Grid();
                while (!game.IsGameOver())
                {
                    if (game.Move(Direction.Up) || game.Move(Direction.Left) || game.Move(Direction.Right) || game.Move(Direction.Down))
                    {
                        game.Spawn();
                    }
                }
                results.Add(new Tuple<Grid, int>(game, game.Score));
            }
            results.Sort((a, b) => b.Item2.CompareTo(a.Item2));
            Console.WriteLine("Game Finished!");
            Console.WriteLine(results.First().Item1);
            Console.WriteLine("Score : " + results.First().Item1.Score);
        }
        
        // real game 
        private static void PlayGame()
        {
            Console.Clear();
            Console.WriteLine("[Play Game]");
            Console.ReadKey();      
            var game = new Grid();
            Console.WriteLine(game);

            while (!game.IsGameOver())
            {
                ConsoleKeyInfo input = Console.ReadKey(true);
                Console.Clear();
                Console.WriteLine("[Move to " + input.Key.ToString() + "]");
                switch (input.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (game.Move(Direction.Up))
                        {
                            game.Spawn();
                            break;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (game.Move(Direction.Down))
                        {
                            game.Spawn();
                            break;
                        }
                        break;
                    case ConsoleKey.LeftArrow:
                        if (game.Move(Direction.Left))
                        {
                            game.Spawn();
                            break;
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        if (game.Move(Direction.Right))
                        {
                            game.Spawn();
                            break;
                        }
                        break;
                }

                Console.WriteLine(game);
                Console.WriteLine("Score : " + game.Score);
            }
            Console.ReadKey();
        }

        // main
        public static void Main(string[] args)
        {
            RunTest();
            // PlayGame();
            PlayAutomatically();
            Console.WriteLine("It worked");
            Console.ReadKey();
        }
    }
}