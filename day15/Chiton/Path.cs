using System;
using System.Collections.Generic;

namespace Day15.Chiton
{
    public class Path
    {
        int[][] data;
        public Path(int[][] data)
        {
            this.data = data;
        }

        public void ExpandMap()
        {
            var newData = new int[data.Length * 5][];

            for (int i = 0; i < 5; i++)
            {
                for (int x = 0; x < data.Length; x++)
                {
                    newData[x + i * data.Length] = new int[data[0].Length * 5];
                    for (int j = 0; j < 5; j++)
                    {
                        for (int y = 0; y < data[0].Length; y++)
                        {
                            var value = (data[x][y] + i + j) - (((data[x][y] + i + j - 1) / 9) * 9);
                            newData[x + i * data.Length][y + j * data[0].Length] = value;
                        }
                    }
                }
            }
            this.data = newData;
        }
        public long LowestRisk()
        {
            Console.WriteLine($"{data.Length}x{data[0].Length}");
            return lowerRisk(0, 0);
        }

        Dictionary<Tuple<int, int>, long> memo = new Dictionary<Tuple<int, int>, long>();

        long lowerRisk(int x, int y)
        {
            var current = data[x][y];
            if (x == 0 && y == 0)
            {
                current = 0;
            }
            if (x == data.Length - 1 && y == data[0].Length - 1)
                return current;

            var key = new Tuple<int, int>(x, y);
            if (memo.ContainsKey(key))
                return memo[key];

            long riskX = long.MaxValue, riskY = long.MaxValue;
            if (x < data.Length - 1)
            {
                riskX = current + lowerRisk(x + 1, y);
            }

            if (y < data[0].Length - 1)
            {
                riskY = current + lowerRisk(x, y + 1);
            }

            var risk = Math.Min(riskX, riskY);
            memo.Add(key, risk);
            return risk;
        }
    }
}
