using System;
using System.Collections.Generic;

namespace BinaryDiagnostic
{
    public class Diagnostic
    {
        private static int[] countBits(int[][] data){
            int[] count = new int[data[0].Length];            
                for(int j = 0; j < data[0].Length; j++){
                    count[j] = countColumn(data, j);
            }
            return count;
        }

        private static int countColumn(int[][] data, int column){
            int count=0;
            for(int i = 0; i < data.Length; i++){
                count+=data[i][column];
            }
            return count;
        }

        public static int Run(int[][] data){

            int gamma=0,epsilon=0;

            int[] count = countBits(data);

            for(int i=0;i<count.Length;i++){
                if(count[i]>data.Length/2)
                {
                    gamma|= 1<<(count.Length-i-1);
                }
                else{
                    epsilon|= 1<<(count.Length-i-1);
                }
            }

            return gamma*epsilon;
        }

        private static int getRating(int[][] data, int[] count, Func<double,double,bool> comparer){
            int rating = 0;        
            for(int j=0;j<data[0].Length;j++){
                if( comparer(countColumn(data,j),data.Length/2.0))
                {
                    data=selectColumn(data,j,1);
                }
                else{
                    data=selectColumn(data,j,0);
                }
                if(data.Length==1)
                {
                    for(int d=0;d<data[0].Length;d++){
                        if(data[0][d]==1)
                            rating|= 1<<(data[0].Length-d-1);
                    }
                    return rating;
                }
            }
            return rating;
        }


        public static int Rating(int[][] data){
            return getRating(data,countBits(data),(a,b)=>a>=b)*getRating(data,countBits(data),(a,b)=>a<b);
        }

        private static int[][] selectColumn(int[][] data, int j, int v)
        {
            List<int[]> list = new List<int[]>();
            for(int i=0;i<data.Length;i++){
                if(data[i][j]==v){
                    list.Add(data[i]);
                }
            }
            return list.ToArray();
        }
    }
}
