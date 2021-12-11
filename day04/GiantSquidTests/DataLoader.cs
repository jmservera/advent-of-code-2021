using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
public class DataLoader{
    public static Bingo LoadData(string path){
        var lines= File.ReadLines(path);
        var enumerator=lines.GetEnumerator();

        enumerator.MoveNext();

        Bingo result=new Bingo();

        List<int> numbers=new List<int>();
        enumerator.Current.Split(',').Select(int.Parse).ToList().ForEach(n=>numbers.Add(n));
        result.Numbers=numbers.ToArray();

        int[,] rows=null;
        int row=0;

        while(enumerator.MoveNext()){
            var line=enumerator.Current.Trim();
            if(line.Length==0)
            {
                if(rows!=null)
                {
                    result.Cards.Add(rows);                    
                }
                rows=null;
                row=0;
                continue;
            }
            else{
                if(rows==null){
                    rows=new int[5,5];
                }
                var current=line.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for(int i=0;i<current.Length;i++){
                    rows[row,i]=current[i];
                }
                row++;
            }
        }

        if(rows!=null){
            result.Cards.Add(rows);             
        }


        return result;
    }
}