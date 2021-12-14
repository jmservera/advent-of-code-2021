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
                sum=Math.Min(sum,data.Sum(a => a<m?m-a:a-m));
            }
            return sum;
        }
    }
}
