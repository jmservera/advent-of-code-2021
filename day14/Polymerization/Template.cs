using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Day14.Polymerization
{
    public class Template    
    {
        string initPolymer;
        Dictionary<string,char> rules;
        public Template(string polymer, Dictionary<string,char> rules){
            this.initPolymer = polymer;
            this.rules = rules;
        }

        public long Reaction(int times){
            string polymer=this.initPolymer;
            StringBuilder sb = new StringBuilder();
            for(int i=1;i<polymer.Length;i++){
                sb.Append( react(new string(new char[]{polymer[i-1],polymer[i]}),times));
            }

            var finalPolymer=sb.ToString();
            var groups=finalPolymer.GroupBy(c=>c).OrderByDescending(g=>g.LongCount());
            var max = groups.First().LongCount();
            var min = groups.Last().LongCount();
            return max-min;
        }

        Dictionary<Tuple<string,int>,string> memo=new Dictionary<Tuple<string,int>,string>();

        string react(string polymer, int times){
            if(times==0){
                return polymer;
            }
            var key=new Tuple<string,int>(polymer,times);

            if(memo.ContainsKey(key)){
                return memo[key];
            }

            if(rules.ContainsKey(polymer)){
                var newChar=rules[polymer];
                var left=react(new string(new char[]{polymer[0],newChar}),times-1);
                var right=react(new string(new char[]{newChar,polymer[1]}),times-1);
                return memo[key]=string.Concat(left.Substring(0,left.Length-1),right);
            }
            else{
                return memo[key]=polymer;
            }
        }           
    }
}
