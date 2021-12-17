using System;
using System.Collections.Generic;

namespace Day13.TransparentOrigami
{
    public class DataLoader
    {
        public static ThermalImaging LoadData(string fileName)
        {
            var lines = System.IO.File.ReadAllLines(fileName);
            var points = new List<int[]>();
            var foldGuidance = new List<string[]>();
            int foldIndex=0;
            for (int i = 0; i < lines.Length; i++)
            {
                var line = lines[i];
                if(string.IsNullOrEmpty(line.Trim()))
                {                    
                    foldIndex=i+1;
                    Console.WriteLine("FoldIndex: " + foldIndex);
                    break;
                }
                var split = line.Split(',');
                points.Add(new int[]{int.Parse(split[0]), int.Parse(split[1])});
            }            
            for (int i = foldIndex; i < lines.Length; i++)
            {
                var line = lines[i];
                var split = line.Split(' ');
                var folds=split[split.Length-1].Split('=');
                foldGuidance.Add(new string[] {folds[0],folds[1]});
            }
            // foreach(var point in points)
            // {
            //     Console.WriteLine($"{point[0]},{point[1]}");
            // }
            return new ThermalImaging(points.ToArray(), foldGuidance.ToArray());
        }
    }
}