using System;
using System.IO;

namespace Day09.SmokeBasin
{
    public class DataLoader
    {
        public static int[,] LoadData(string fileName)
        {
            var lines = File.ReadAllLines(fileName);
            var data = new int[lines.Length, lines[0].Length];
            for (int i = 0; i < lines.Length; i++)
            {
                for (int j = 0; j < lines[i].Length; j++)
                {
                    data[i, j] = int.Parse(lines[i][j].ToString());
                }
            }
            return data;
        }
    }
}