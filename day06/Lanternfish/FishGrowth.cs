using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Lanternfish
{
    public class FishGrowth
    {
        Dictionary<int, long> cache = new Dictionary<int, long>();
        public long Growth(IEnumerable<int> fishes, int days)
        {
            long sum = 0;

            foreach (var fish in fishes)
            {
                sum += countFishes(fish, days);
            }
            return sum;
        }

        long countFishes(int fish, int days)
        {
            int key=fish+days*10;
            if(!cache.ContainsKey(key))
            {
                if(days==0){
                    return 1;
                }
                if(fish==0)
                {
                    var count= countFishes(6, days-1)+countFishes(8, days-1);
                    cache[key] = count;
                } else if(fish>days){
                    cache[key] = 1;
                }
                else {
                    var count= countFishes(fish-1, days-1);
                    cache[key] = count;
                }
            }

            return cache[key];
        }
    }
}
