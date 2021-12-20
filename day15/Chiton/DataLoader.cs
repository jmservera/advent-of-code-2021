using System;
using System.Linq;

namespace Day15.Chiton
{
    public static class DataLoader{
        public static Path LoadData(string fileName,bool expand=false){
            var lines = System.IO.File.ReadAllLines(fileName);
            var data= lines.Select(line=> line.Select(c=> int.Parse(c.ToString())).ToArray()).ToArray();
            return new Path(data,expand);
        }
    }
}