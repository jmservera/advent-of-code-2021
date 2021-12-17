using System;
using System.Linq;

namespace Day13.TransparentOrigami
{
    public class ThermalImaging
    {
        bool[,] map;
        string[][] foldGuidance;
        public ThermalImaging(int[][] points, string[][] foldGuidance){
            var maxX= points.Select(x=>x[0]).Max();
            var maxY= points.Select(x=>x[1]).Max();

            if(maxY%2!=0){
                maxY++;
            }

            map = new bool[maxY+1,maxX+1];
            for (int i = 0; i < points.Length; i++)
            {
                var point = points[i];
                map[point[1],point[0]]=true;
            }
            this.foldGuidance=foldGuidance;
        }

        public int Fold(int iterations=0){
            var oldMap=map;
            if(iterations==0){
                iterations=foldGuidance.Length;
            }
            for(int i=0;i<iterations;i++){                
                var fold=foldGuidance[i];
                bool[,] newMap;

                Console.WriteLine($"Fold {i} {fold[0]}={fold[1]}\t {oldMap.GetLength(1)},{oldMap.GetLength(0)}");

                if(fold[0]=="x"){                    
                    var xFold=int.Parse(fold[1]);
                    newMap=new bool[oldMap.GetLength(0),xFold];

                    for(int y=0;y<oldMap.GetLength(0);y++){
                        var top=oldMap.GetLength(1)-1;
                        for(int x=0;x<xFold;x++){
                            newMap[y,x]=oldMap[y,x]|oldMap[y,top-x];
                        }
                    }
                }
                else{
                    var yFold=int.Parse(fold[1]);
                    newMap=new bool[yFold,oldMap.GetLength(1)];

                    for(int x=0;x<oldMap.GetLength(1);x++){
                        var top=oldMap.GetLength(0)-1;
                        for(int y=0;y<yFold;y++){
                            newMap[y,x]=oldMap[y,x]|oldMap[top-y,x];
                        }
                    }
                }
                oldMap=newMap;
            }
            

            showMap(oldMap);

            int count=0;
            for(int y=0;y<oldMap.GetLength(0);y++){
                for(int x=0;x<oldMap.GetLength(1);x++){
                    
                    if(oldMap[y,x]){
                        count++;
                    }
                }
            }

            return count;
        }
        static void showMap(bool[,] map){
            Console.WriteLine("Map:");
            for(int y=0;y<map.GetLength(0);y++){
                for(int x=0;x<map.GetLength(1);x++){
                    Console.Write(map[y,x]?"▓":" ");
                }
                Console.WriteLine();
            }
        }
    }
}
