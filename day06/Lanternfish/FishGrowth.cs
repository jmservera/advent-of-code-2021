using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Lanternfish
{
    public class FishGrowth
    {
        public static BigInteger Growth(IEnumerable<int> fish, int days, int threshold=500000){
            List<int> fishList = new List<int>(fish);            
            for(int d=0;d<days;d++){

                if(fishList.LongCount()>threshold){
                    var first= fishList.Take(threshold/2);
                    var second= fishList.Skip(threshold/2);
                    Console.WriteLine($"{d} {fishList.LongCount()} {first.LongCount()} {second.LongCount()}");
                    return Growth(first, days-d) + Growth(second, days-d);
                }

                int newFishes=0;
                int count=fishList.Count;
                for(int i=0;i<count;i++)
                {
                    if(fishList[i]==0){
                        fishList[i]=6;
                        newFishes++;
                    }
                    else{
                        fishList[i]--;
                    }
                }

                fishList.AddRange(Enumerable.Repeat(8,newFishes));
            }
            return fishList.LongCount();
        }
    }
}
