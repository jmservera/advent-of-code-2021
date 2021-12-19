using System;
using System.Linq;

namespace Day13.TransparentOrigami
{
    public class ThermalImaging
    {
        bool[,] map;

        bool[,] result;
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
            result=map;
            if(iterations==0){
                iterations=foldGuidance.Length;
            }
            for(int i=0;i<iterations;i++){                
                var fold=foldGuidance[i];
                bool[,] newMap;

                if(fold[0]=="x"){                    
                    var xFold=int.Parse(fold[1]);
                    newMap=new bool[result.GetLength(0),xFold];

                    for(int y=0;y<result.GetLength(0);y++){
                        var top=result.GetLength(1)-1;
                        for(int x=0;x<xFold;x++){
                            newMap[y,x]=result[y,x]|result[y,top-x];
                        }
                    }
                }
                else{
                    var yFold=int.Parse(fold[1]);
                    newMap=new bool[yFold,result.GetLength(1)];

                    for(int x=0;x<result.GetLength(1);x++){
                        var top=result.GetLength(0)-1;
                        for(int y=0;y<yFold;y++){
                            newMap[y,x]=result[y,x]|result[top-y,x];
                        }
                    }
                }
                result=newMap;
            }
            

            int count=0;
            for(int y=0;y<result.GetLength(0);y++){
                for(int x=0;x<result.GetLength(1);x++){
                    
                    if(result[y,x]){
                        count++;
                    }
                }
            }

            return count;
        }
        public void Print(){
            Console.WriteLine("Map:");
            for(int y=0;y<result.GetLength(0);y++){
                for(int x=0;x<result.GetLength(1);x++){
                    Console.Write(result[y,x]?"▓":" ");
                }
                Console.WriteLine();
            }
        }
    }
}
