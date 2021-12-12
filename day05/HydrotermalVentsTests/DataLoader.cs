using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
public class DataLoader{
    public static string[] LoadData(string path){
        var lines= File.ReadLines(path);
        return lines.ToArray();
    }
}