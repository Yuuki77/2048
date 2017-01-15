using System;

namespace Game
{
    ///<summary>
    /// TEST CODE
    ///</summary>
    public static class TestGrid
    {
        public static void TestCreateGrid()
        {
            Grid grid = new Grid();
            Console.WriteLine(grid);

            if (grid.Data.GetLength(0) != 4)
            {
                throw new Exception("Wrong size of the grid");
            }
            if (grid.Data.GetLength(1) != 4)
            {
                throw new Exception("Wrong size of the grid");
            }
            if (grid.CountEmpty() != 14)
            {
                throw new Exception("Spawn doesn't work");
            }

            Console.WriteLine(" * TestCreateGrid: OK");
        }

        public static void TestSpawn()
        {
            Grid grid = new Grid();

            grid.Spawn();

            Console.WriteLine(grid);

            if (grid.CountEmpty() != 13)
            {
                throw new Exception("Spawn doesn't work");
            }

            Console.WriteLine(" * TestSpawn: OK");
        }
        public static void TestMoveUp()
        {
            var data = new int[,] {
                {2, 2, 0, 2},
                {2, 2, 0, 8},
                {2, 0, 4, 0},
                {0, 4, 2, 0}
            };

            var expected = new int[,] {
                {4, 4, 4, 2},
                {2, 4, 2, 8},
                {0, 0, 0, 0},
                {0, 0, 0, 0}
            };

            Grid grid = new Grid(data);
            Console.WriteLine(grid);
            grid.Move(Direction.Up);
            Console.WriteLine(grid);

            if (!IsEqual(grid.Data, expected))
            {
                throw new Exception("Move Up doesn't work");
            }

            Console.WriteLine(" * TestMoveUp: OK");
        }

        public static void TestMoveDown()
        {
            var data = new int[,] {
                {2, 2, 0, 2},
                {2, 2, 0, 8},
                {2, 0, 4, 0},
                {0, 4, 2, 0}
            };

            var expected = new int[,] {
                {0, 0, 0, 0},
                {0, 0, 0, 0},
                {2, 4, 4, 2},
                {4, 4, 2, 8}
            };

            Grid grid = new Grid(data);
            Console.WriteLine(grid);
            grid.Move(Direction.Down);
            Console.WriteLine(grid);

            if (!IsEqual(grid.Data, expected))
            {
                throw new Exception("Move Down doesn't work");
            }

            Console.WriteLine(" * TestMoveDown: OK");
        }
        public static void TestMoveLeft()
        {
            var data = new int[,] {
                {0, 2, 0, 2},
                {2, 2, 0, 8},
                {2, 0, 4, 0},
                {0, 4, 2, 0}
            };

            var expected = new int[,] {
                {4, 0, 0, 0},
                {4, 8, 0, 0},
                {2, 4, 0, 0},
                {4, 2, 0, 0}
            };

            Grid grid = new Grid(data);
            Console.WriteLine(grid);
            grid.Move(Direction.Left);
            Console.WriteLine(grid);

            if (!IsEqual(grid.Data, expected))
            {
                throw new Exception("Move Left doesn't work");
            }

            Console.WriteLine(" * TestMoveLeft: OK");
        }

        public static void TestMoveRight()
        {
            var data = new int[,] {
                {0, 2, 0, 2},
                {2, 2, 0, 8},
                {2, 0, 4, 0},
                {0, 4, 2, 0}
            };

            var expected = new int[,] {
                {0, 0, 0, 4},
                {0, 0, 4, 8},
                {0, 0, 2, 4},
                {0, 0, 4, 2}
            };

            Grid grid = new Grid(data);
            Console.WriteLine(grid);
            grid.Move(Direction.Right);
            Console.WriteLine(grid);

            if (!IsEqual(grid.Data, expected))
            {
                throw new Exception("Move Down doesn't work");
            }

            Console.WriteLine(" * TestMoveRight: OK");
        }

        public static void TestMoveResult()
        {
            var data = new int[,] {
                {2, 2, 0, 2},
                {2, 2, 0, 8},
                {2, 0, 4, 0},
                {0, 4, 2, 0}
            };

            Grid grid = new Grid(data);
            var result = grid.Move(Direction.Up);
            Console.WriteLine(grid);

            if (!result)
            {
                throw new Exception("TestMoveResult doesn't work");
            }

            Console.WriteLine(" * TestMoveResult: OK");
        }

        public static void TestMoveResultFalse()
        {
            var data = new int[,] {
                {2, 2, 2, 2},
                {4, 4, 0, 8},
                {0, 0, 0, 0},
                {0, 0, 0, 0}
            };

            Grid grid = new Grid(data);
            var result = grid.Move(Direction.Up);
            Console.WriteLine(grid);

            if (result)
            {
                throw new Exception("TestMoveResultFalse doesn't work");
            }

            Console.WriteLine(" * TestMoveResultFalse: OK");
        }
        public static void TestMergeUp()
        {
            var data = new int[,] {
                {8, 2, 4, 2},
                {4, 2, 4, 2},
                {2, 2, 8, 4},
                {2, 2, 4, 4}
            };

            var expected = new int[,] {
                {8, 4, 8, 4},
                {4, 4, 8, 8},
                {4, 0, 4, 0},
                {0, 0, 0, 0}
            };

            Grid grid = new Grid(data);
            Console.WriteLine(grid);
            grid.Move(Direction.Up);
            Console.WriteLine(grid);

            if (!IsEqual(grid.Data, expected))
            {
                throw new Exception("TestMergeUp doesn't work");
            }

            Console.WriteLine(" * TestMergeUp: OK");
        }
        public static void TestMergeDown()
        {
            var data = new int[,] {
                {8, 2, 4, 2},
                {4, 2, 4, 2},
                {2, 2, 8, 4},
                {2, 2, 4, 4}
            };

            var expected = new int[,] {
                {0, 0, 0, 0},
                {8, 0, 8, 0},
                {4, 4, 8, 4},
                {4, 4, 4, 8}
            };

            Grid grid = new Grid(data);
            Console.WriteLine(grid);
            grid.Move(Direction.Down);
            Console.WriteLine(grid);

            if (!IsEqual(grid.Data, expected))
            {
                throw new Exception("TestMergeDown doesn't work");
            }

            Console.WriteLine(" * TestMergeDown: OK");
        }
        public static void TestMergeLeft()
        {
            var data = new int[,] {
                {8, 2, 4, 2},
                {4, 2, 4, 2},
                {2, 2, 8, 4},
                {4, 2, 2, 0}
            };

            var expected = new int[,] {
                {8, 2, 4, 2},
                {4, 2, 4, 2},
                {4, 8, 4, 0},
                {4, 4, 0, 0}
            };

            Grid grid = new Grid(data);
            Console.WriteLine(grid);
            grid.Move(Direction.Left);
            Console.WriteLine(grid);

            if (!IsEqual(grid.Data, expected))
            {
                throw new Exception("TestMergeLeft doesn't work");
            }

            Console.WriteLine(" * TestMergeLeft: OK");
        }
        public static void TestMergeRight()
        {
            var data = new int[,] {
                {8, 2, 4, 2},
                {4, 2, 4, 2},
                {2, 2, 8, 4},
                {2, 2, 4, 4}
            };

            var expected = new int[,] {
                {8, 2, 4, 2},
                {4, 2, 4, 2},
                {0, 4, 8, 4},
                {0, 0, 4, 8}
            };

            Grid grid = new Grid(data);
            Console.WriteLine(grid);
            grid.Move(Direction.Right);
            Console.WriteLine(grid);

            if (!IsEqual(grid.Data, expected))
            {
                throw new Exception("TestMergeRight doesn't work");
            }

            Console.WriteLine(" * TestMergeRight: OK");
        }
        public static void TestIsFinished()
        {
            var data = new int[,] {
                {2, 6, 8, 6},
                {4, 8, 4, 8},
                {8, 16, 12, 13},
                {20, 22, 11, 22}
            };

            Grid grid = new Grid(data);
            // Console.WriteLine(grid);
            if (!grid.IsGameOver())
            {
                throw new Exception("TestIsFinished doesn't work");
            }

            Console.WriteLine(grid);
            Console.WriteLine(" * TestIsFinished: OK");
        }

        public static void TestIsNotFinished()
        {
            var data = new int[,] {
                {2, 2, 2, 2},
                {2, 0, 0, 2},
                {2, 0, 0, 2},
                {2, 2, 2, 2}
            };

            var expected = new int[,] {
                {2, 2, 2, 2},
                {2, 0, 0, 2},
                {2, 0, 0, 2},
                {2, 2, 2, 2}
            };

            Grid grid = new Grid(data);
            Console.WriteLine(grid);
            if (grid.IsGameOver())
            {
                throw new Exception("TestIsNotFinished doesn't work");
            }

            if (!IsEqual(grid.Data, expected))
            {
                Console.WriteLine(grid);
                throw new Exception("TestIsNotFinished doesn't work : Grid changed");
            }

            Console.WriteLine(" * TestIsNotFinished: OK");
        }

        public static void TestWTF()
        {
            var data = new int[,] {
                {128, 64, 32, 16},
                {8, 32, 16, 4},
                {4, 8, 4, 2},
                {2, 4, 2, 2}
            };

            var expected = new int[,] {
                {128, 64, 32, 16},
                {8, 32, 16, 4},
                {4, 8, 4, 4},
                {2, 4, 2, 0}
            };

            Grid grid = new Grid(data);
            grid.Move(Direction.Up);
            Console.WriteLine(grid);

            if (!IsEqual(grid.Data, expected))
            {
                Console.WriteLine(grid);
                throw new Exception("TestWTF doesn't work : Grid changed");
            }
            Console.WriteLine(" * TestWTF: OK");
        }

        private static bool IsEqual(int[,] a, int[,] b)
        {
            for (int y = 0; y < a.GetLength(0); y++)
            {
                for (int x = 0; x < a.GetLength(1); x++)
                {
                    if (a[y, x] != b[y, x])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}