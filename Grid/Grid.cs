using System;
using System.Linq;
using System.Collections.Generic;

namespace Game
{
    /// <summary>
	/// Grid (grid that shows a maze)
	/// </summary>
    public class Grid
    {
        // 2D array
        public int[,] Data { get; private set; }
        public int Score { get; private set; }

        // Default Constructor
        public Grid()
        {
            Data = new int[,]{
                {0, 0, 0, 0},
                {0, 0, 0, 0},
                {0, 0, 0, 0},
                {0, 0, 0, 0}
            };
            Spawn();
            Spawn();
        }

        // Constructor for testing
        public Grid(int[,] data)
        {
            Data = data;
        }

        // spawn
        public void Spawn()
        {
            while (true)
            {
                Random rnd = new Random();
                int newY = rnd.Next(0, 4);
                int newX = rnd.Next(0, 4);
                if (Data[newY, newX] != 0)
                {
                    continue;
                }
                Data[newY, newX] = 2;
                break;
            }
        }

        /// <summary>
		/// make it move
		/// </summary>
        /// <param name="direction"></param>
        public bool Move(Direction direction)
        {
            // store privious maze
            var before = (int[,])Data.Clone();
            for (int x = 0; x < Data.GetLength(0); x++)
            {
                var list = GetValue(direction, x);
                MergeNumbers(direction, list);
                SetRow(direction, x, list);
            }
            // check if it can still move
            return !AreEqual(Data, before);
        }

        /// <summary>
        /// check if it can move
        /// </summary>
        /// <param name="direction"></param>
        public bool CanMove(Direction direction)
        {
            for (int x = 0; x < Data.GetLength(0); x++)
            {
                var list = GetValue(direction, x);
                var before = new List<int>(list);
                MergeNumbers(direction, list);

                if (!before.SequenceEqual(list))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Get the value
        /// </summary>
        /// <param name="direction"></param>
        /// <param name="x"></param>
        private List<int> GetValue(Direction direction, int x)
        {
            List<int> list = new List<int>();
            bool vertical = direction == Direction.Up || direction == Direction.Down;

            for (int i = 0; i < Data.GetLength(1); i++)
            {
                var column = vertical ? i : x;
                var row = vertical ? x : i;

                if (Data[column, row] == 0)
                {
                    continue;
                }
                list.Add(Data[column, row]);
            }
            return list;
        }

        /// <summary>
        /// Set the value
        /// </summary>
        /// <param name="y"></param>
        /// <param name="x"></param>
        /// <param name="list"></param>
        /// <param name="i"></param>
        public void SetRowValue(int y, int x, List<int> list, int i)
        {
            if (i < list.Count)
            {
                Data[y, x] = list[i];
                return;
            }
            Data[y, x] = 0;
        }

        /// <summary>
        /// Set the value by direction
        /// </summary>
        /// <param name="direction"></param>
        /// <param name="x"></param>
        /// <param name="list"></param>
        public void SetRow(Direction direction, int x, List<int> list)
        {
            bool CanUp = direction == Direction.Up;
            bool CanDown = direction == Direction.Down;
            bool CanLeft = direction == Direction.Left;
            bool CanRight = direction == Direction.Right;
            if (CanDown || CanRight)
            {
                list.Reverse();
            }
            for (int i = 0; i < Data.GetLength(1); i++)
            {
                int y = Data.GetLength(1) - 1 - i;
                if (CanUp)
                {
                    SetRowValue(i, x, list, i);
                    continue;
                }

                if (CanDown)
                {
                    SetRowValue(y, x, list, i);
                    continue;
                }

                if (CanRight)
                {
                    SetRowValue(x, y, list, i);
                    continue;
                }

                if (CanLeft)
                {
                    SetRowValue(x, i, list, i);
                    continue;
                }
            }
        }

        /// <summary>
        /// merge values
        /// </summary>
        /// <param name="direction"></param>
        /// <param name="list"></param>
        private void MergeNumbers(Direction direction, List<int> list)
        {
            bool Up = direction == Direction.Up;
            bool Left = direction == Direction.Left;
            bool Down = direction == Direction.Down;
            bool Right = direction == Direction.Right;
            for (int i = 0; i < list.Count - 1; i++)
            {
                int y = list.Count - 1 - i;
                if ((Up || Left) && (list[i] == list[i + 1]))
                {
                    list[i] = list[i] * 2;
                    CountScore(list[i] * 2);
                    list[i + 1] = 0;
                }
                if ((Right || Down) && (list[y - 1] == list[y]))
                {
                    list[y] = list[y] * 2;
                    CountScore(list[y] * 2);
                    list[y - 1] = 0;
                }
            }
            list.RemoveAll(x => x == 0);
        }

        /// <summary>
		/// count score
		/// </summary>
		/// <param name="i"></param>
        public int CountScore(int i)
        {
            Score = Score + i;
            return Score;
        }

        /// <summary>
		/// chech if two 2d arra are same 
		/// </summary>
		/// <param name="beforeMove"></param>
        /// <param name="AfterMove"></param>
        public bool IsEqual(Grid beforeMove, Grid AfterMove)
        {
            if (beforeMove == AfterMove)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        ///check empty
        /// </summary>
        public int CountEmpty()
        {
            int result = 0;
            for (int y = 0; y < Data.GetLength(0); y++)
            {
                for (int x = 0; x < Data.GetLength(1); x++)
                {
                    if (Data[y, x] == 0)
                    {
                        result += 1;
                    }
                }
            }
            return result;
        }

        /// <summary>
        //prepare for /stringfy
        /// </summary>
        /// <param name="data"></param>
        private string DataToString(int[,] data)
        {
            string result = "";
            for (int y = 0; y < data.GetLength(0); y++)
            {
                for (int x = 0; x < data.GetLength(1); x++)
                {
                    string val = data[y, x].ToString();
                    result += val.PadLeft(5, ' ');
                }
                result += "\n";
            }
            return result;
        }

        /// <summary>
        ///check if the game is over
        /// </summary>
        public bool IsGameOver()
        {
            // is empty cell
            if (CountEmpty() != 0)
            {
                return false;
            }
            return !CanMove(Direction.Up) && !CanMove(Direction.Down) && !CanMove(Direction.Left) && !CanMove(Direction.Right);
        }

        /// <summary>
        /// stringfy
        /// </summary>
        public override string ToString()
        {
            return DataToString(Data);
        }

        /// <summary>
        /// check two 2d array is same or not
        /// </summary>
        /// <param name="before"></param>
        /// <param name="after"></param>
        private static bool AreEqual(int[,] before, int[,] after)
        {
            for (int y = 0; y < before.GetLength(0); y++)
            {
                for (int x = 0; x < after.GetLength(1); x++)
                {
                    if (before[y, x] != after[y, x])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
        