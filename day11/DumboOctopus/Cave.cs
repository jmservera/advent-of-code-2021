using System;

namespace Day11.DumboOctopus
{
    public class Cave
    {
        int [,] map;
        public Cave(int[,] map)
        {
            this.map = map;
        }

        public int CountFlashes(int loops){
            int count = 0;
            for(int l=0;l<loops;l++){
                recharge();
                count+=flashMap();

            }
            return count;
        }

        public int FirstSyncFlash(){
            int count = 0;
            do{
                recharge();
                flashMap();
                count++;
            }while(!isSync());
            return count;
        }

        bool isSync(){
            for(int i=0;i<map.GetLength(0);i++){
                for(int j=0;j<map.GetLength(1);j++){
                    if(map[i,j]!=0){
                        return false;
                    }
                }
            }
            return true;
        }

        void recharge(){
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    map[i,j]++;
                }
            }
        }
        int flashMap(){
            int count = 0, newCount;
            do{
                newCount=0;
                for (int i = 0; i < map.GetLength(0); i++)
                {
                    for (int j = 0; j < map.GetLength(1); j++)
                    {
                        if(map[i,j]>9){
                            map[i,j]=0;
                            newCount++;
                            increaseAdjacentEnergy(i,j);
                        }
                    }
                }
                count+=newCount;
            }while(newCount!=0);
            return count;
        }

        void increaseEnergy(int i, int j){
            if(map[i,j]!=0){
                map[i,j]++;
            }
        }
        void increaseAdjacentEnergy(int i, int j){
            if(i>0){
                increaseEnergy(i-1,j);
                if(j>0){
                    increaseEnergy(i-1,j-1);
                }
            }

            if(i<map.GetLength(0)-1){
                increaseEnergy(i+1,j);
                if(j<map.GetLength(1)-1){
                    increaseEnergy(i+1,j+1);
                }
            }
                
            if(j>0){
                increaseEnergy(i,j-1);
                if(i<map.GetLength(0)-1){
                    increaseEnergy(i+1,j-1);
                }
            }
                
            if(j<map.GetLength(1)-1){
                increaseEnergy(i,j+1);
                if(i>0){
                    increaseEnergy(i-1,j+1);
                }
            }
        }
    }
}
