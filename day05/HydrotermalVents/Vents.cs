using System;
using System.Collections.Generic;
using System.Linq;

    public class Vents
    {
        public static int Solve(string[] vents){
            List<int[]> lines=new List<int[]>();
            int maxX=0, maxY=0;
            for(int i = 0; i < vents.Length; i++){
                var coords=vents[i].Split(" -> ");
                var start=coords[0].Split(",").Select(int.Parse).ToArray();
                var end=coords[1].Split(",").Select(int.Parse).ToArray();

                maxX=Math.Max(maxX, end[0]);
                maxY=Math.Max(maxY, end[1]);
                lines.Add(new int[]{start[0],start[1],end[0],end[1]});
            }

            int[][] grid=new int[maxY+2]
                .Select(x=>new int[maxX+2])
                .ToArray();
            
            foreach(var line in lines){
                if(line[0]==line[2] || line[1]==line[3]){

                    IEnumerable<int> xrange, yrange;
                    if(line[0]<line[2]){
                        xrange=Enumerable.Range(line[0], line[2]-line[0]+1);}
                    else{
                        xrange=Enumerable.Range(line[2], line[0]-line[2]+1);}
                    if(line[1]<line[3]){
                        yrange=Enumerable.Range(line[1], line[3]-line[1]+1);}
                    else{
                        yrange=Enumerable.Range(line[3], line[1]-line[3]+1);}

                    foreach(var x in xrange){
                        foreach(var y in yrange){
                            grid[y][x]++;
                        }
                    }
                }
            }

            int count=0;
            for(int x=0; x<grid[0].Length; x++){
                for(int y=0; y<grid.Length; y++){
                    if(grid[y][x]>=2){
                        count++;
                    }
                }
            }
            return count;

        }
    }