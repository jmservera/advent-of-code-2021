using System;
using System.Collections.Generic;
using System.Linq;

namespace Day15.Chiton
{
    public class Path
    {
        int[][] data;
        public Path(int[][] data)
        {
            this.data = data;
        }

        public void ExpandMap()
        {
            var newData = new int[data.Length * 5][];

            for (int i = 0; i < 5; i++)
            {
                for (int x = 0; x < data.Length; x++)
                {
                    newData[x + i * data.Length] = new int[data[0].Length * 5];
                    for (int j = 0; j < 5; j++)
                    {
                        for (int y = 0; y < data[0].Length; y++)
                        {
                            var value = (data[x][y] + i + j) - (((data[x][y] + i + j - 1) / 9) * 9);
                            newData[x + i * data.Length][y + j * data[0].Length] = value;
                        }
                    }
                }
            }
            this.data = newData;
        }
        public long LowestRisk()
        {
            Console.WriteLine($"{data.Length}x{data[0].Length}");
            return lowerRisk();
        }

        long lowerRisk()
        {
            var origin= new Tuple<int, int>(0, 0);
            var priorityQueue = new Dictionary<Tuple<int, int>,long>();            

            for(int x=0;x<data.Length;x++){
                for(int y=0;y<data[0].Length;y++){
                    var item= new Tuple<int, int>(x, y);
                    priorityQueue.Add(item, int.MaxValue);
                }
            }
            priorityQueue[origin]=0;

            while(priorityQueue.Count>0){
                if(priorityQueue.Count%1000==0){
                    Console.Write($"{priorityQueue.Count}.");
                }
                var current = priorityQueue.Aggregate((l, r) => l.Value < r.Value ? l : r); //priorityQueue.MinBy(r=>r.Value);
                priorityQueue.Remove(current.Key);
                var x = current.Key.Item1;
                var y = current.Key.Item2;
                var value = current.Value;
                if(x==data.Length-1 && y==data[0].Length-1){
                    return value;
                }
                if(x>0){
                    var left = new Tuple<int, int>(x-1, y);
                    if(priorityQueue.ContainsKey(left)){
                        var newValue = value + data[left.Item1][left.Item2];
                        if(newValue<priorityQueue[left]){
                            priorityQueue[left]=newValue;
                        }
                    }
                }
                if(y>0){
                    var up = new Tuple<int, int>(x, y-1);
                    if(priorityQueue.ContainsKey(up)){
                        var newValue = value + data[up.Item1][up.Item2];
                        if(newValue<priorityQueue[up]){
                            priorityQueue[up]=newValue;
                        }
                    }
                }
                if(x<data.Length-1){
                    var right = new Tuple<int, int>(x+1, y);
                    if(priorityQueue.ContainsKey(right)){
                        var newValue = value + data[right.Item1][right.Item2];
                        if(newValue<priorityQueue[right]){
                            priorityQueue[right]=newValue;
                        }
                    }
                }
                if(y<data[0].Length-1){
                    var down = new Tuple<int, int>(x, y+1);
                    if(priorityQueue.ContainsKey(down)){
                        var newValue = value + data[down.Item1][down.Item2];
                        if(newValue<priorityQueue[down]){
                            priorityQueue[down]=newValue;
                        }
                    }
                }
            }

            //not found
            return -1;
        }
    }

    public static class Extensions{
        public static TSource MinBy<TSource>(
    this IEnumerable<TSource> source,
    Func<TSource, IComparable> projectionToComparable
) {
    using (var e = source.GetEnumerator()) {
        if (!e.MoveNext()) {
            throw new InvalidOperationException("Sequence is empty.");
        }
        TSource min = e.Current;
        IComparable minProjection = projectionToComparable(e.Current);
        while (e.MoveNext()) {
            IComparable currentProjection = projectionToComparable(e.Current);
            if (currentProjection.CompareTo(minProjection) < 0) {
                min = e.Current;
                minProjection = currentProjection;
            }
        }
        return min;                
    }
}
    }
}
