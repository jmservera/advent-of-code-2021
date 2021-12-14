using System;
using System.Linq;

namespace Day07.GiantWhale
{
    public class Crab
    {
        int[] data;
        public Crab(int[] data){
            this.data=data;
        }

        public int Solve(){
            var groups = data.GroupBy(v => v);
            int maxCount = groups.Max(g => g.Count());
            var mode = groups. Where(g => g.Count() > maxCount-10).Select(g => g.Key);

            int sum = int.MaxValue;
            foreach(var m in mode){
                sum=Math.Min(sum,data.Sum(a => Math.Abs(m-a)));
            }
            return sum;
        }

        public int IncreasingPriceSolve()
        {
            var groups = data.GroupBy(v => v);
            int maxCount = groups.Max(g => g.Count());
            var mode = groups.Where(g => g.Count() > maxCount-10).Select(g => g.Key);
            mode=mode.Select(m=>m-1).Union(mode.Select(m => m+1)).Union(mode);

            int sum = int.MaxValue;
            foreach(var m in mode){
                sum=Math.Min(sum,data.Sum(a => calcPrice(Math.Abs(m-a))));
            }
            return sum;
        }

        int calcPrice(int distance){
            // S(n)=1+2+...+n=n(n+1)/2
            return distance*(distance+1)/2;
        }
    }
}
