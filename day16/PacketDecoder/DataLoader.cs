namespace Day16.PacketDecoder;

using System;
using System.Text;

public class DataLoader
{
    public static string LoadDataFromFile(string fileName)
    {
        return LoadData(File.ReadAllText(fileName));
    }

    public static string LoadData(string hexString){
        var sb=new StringBuilder();
        foreach(var nibble in hexString){
            var n=int.Parse(nibble.ToString(),System.Globalization.NumberStyles.HexNumber);
            sb.Append(Convert.ToString(n,2).PadLeft(4,'0'));
        }
        return sb.ToString();
    }
}