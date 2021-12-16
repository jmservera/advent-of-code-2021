using System;

namespace Day11.DumboOctopus
{
    public static class DataLoader{

        public static int[,] LoadData(string fileName){
            var lines = System.IO.File.ReadAllLines(fileName);
            int[,] map = new int[lines.Length, lines[0].Length];
            for (int i = 0; i < lines.Length; i++)
            {
                for (int j = 0; j < lines[i].Length; j++)
                {
                    map[i,j] = int.Parse(lines[i][j].ToString());
                }
            }
            return map;
        }

    }
}