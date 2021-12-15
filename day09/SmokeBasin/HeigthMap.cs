using System;
using System.Collections.Generic;
using System.Linq;

namespace Day09.SmokeBasin
{
    public class HeigthMap
    {
        int[,] map;
        public HeigthMap(int[,] data)
        {
            this.map=data;
        }
        public int CalcRisk(){
            var lowPoints=findLowPoints();
            int result=0;
            foreach(var point in lowPoints){
                
                result+=1+map[point.Item1,point.Item2];
            }
            return result;
        }

        public int CalcBasins(){
            var lowPoints=findLowPoints();
            List<int> basins=new List<int>();
            foreach(var point in lowPoints){
                basins.Add(measureBasin(point.Item1,point.Item2));
            }

            basins.Sort();
            basins.Reverse();
            return basins.Take(3).Aggregate((x,y)=>x*y);
        }

        private List<Tuple<int,int>> findLowPoints(){
            var lowPoints=new List<Tuple<int,int>>();
            for(int i=0;i<map.GetLength(0);i++){
                for(int j=0;j<map.GetLength(1);j++){
                    if(isLowPoint(i,j)){
                        lowPoints.Add(new Tuple<int,int>(i,j));
                    }
                }
            }
            return lowPoints;
        }

        bool isLowPoint(int i, int j){
            for(int x=i-1;x<=i+1;x++){
                for(int y=j-1;y<=j+1;y++){
                    if(x==i && y==j){
                        continue;
                    }
                    if(x>=0 && x<map.GetLength(0) && y>=0 && y<map.GetLength(1)){
                        if(map[x,y]<=map[i,j]){
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        int measureBasin(int i, int j){
            List<Tuple<int,int>> basinPoints=new List<Tuple<int,int>>();
            
            fillBasinPoints(i,j,basinPoints);
            return basinPoints.Count;
        }

        void fillBasinPoints(int i, int j, List<Tuple<int,int>> basinPoints){
            if(i<0 || i>=map.GetLength(0) || j<0 || j>=map.GetLength(1)){
                return;
            }
            if(map[i,j]==9){
                return;
            }
            else{
                if(basinPoints.Contains(new Tuple<int,int>(i,j))){
                    return;
                }
                basinPoints.Add(new Tuple<int,int>(i,j));
                fillBasinPoints(i-1,j,basinPoints);
                fillBasinPoints(i+1,j,basinPoints);
                fillBasinPoints(i,j-1,basinPoints);
                fillBasinPoints(i,j+1,basinPoints);
            }
        }
    }
}
