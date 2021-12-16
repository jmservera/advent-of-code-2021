using System;
using System.IO;

namespace Day12.PassagePathing
{
    public static class DataLoader{
        public static string[][] LoadData(string fileName){
            var lines = File.ReadAllLines(fileName);
            var data = new string[lines.Length][];
            for(int i = 0; i < lines.Length; i++){
                data[i] = lines[i].Split('-');
            }
            return data;
        }
    }
}