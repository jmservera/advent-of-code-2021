using System;
using System.Collections.Generic;
using System.Linq;

namespace Day14.Polymerization
{
    public static class DataLoader{
        public static Template LoadData(string fileName){
            var text= System.IO.File.ReadAllLines(fileName);
            string polymer=text[0];
            var rules=new Dictionary<string,char>();
            for(int i=2;i<text.Count();i++){
                var rule=text[i].Split(" -> ");
                rules.Add(rule[0],rule[1][0]);
            }
            return new Template(polymer,rules);
        }
    }
}