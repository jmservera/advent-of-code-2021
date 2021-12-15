using System;
using System.Collections.Generic;

namespace Day08.SevenSegments
{
    public class DataLoader{
        public static Data[] LoadData(string path)
        {
            List<Data> data = new List<Data>();

            foreach(var line in System.IO.File.ReadLines(path)){
                var parts = line.Split('|', StringSplitOptions.RemoveEmptyEntries);
                var signals = parts[0].Split(' ', StringSplitOptions.RemoveEmptyEntries);
                var digits = parts[1].Split(' ', StringSplitOptions.RemoveEmptyEntries);
                data.Add(new Data{Signals = new List<string>(signals), Digits = new List<string>(digits)});   
            }
            return data.ToArray();
        }
    }
}