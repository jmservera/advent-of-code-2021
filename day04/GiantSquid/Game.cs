using System;
using System.Collections.Generic;
public class Game {
    public static int Play(Bingo bingo){
        for(int i=0;i<bingo.Numbers.Length;i++){

            markNumbers(bingo, bingo.Numbers[i]);
            if(i>5){
                var winner=getWinners(bingo);
                if(winner.Length>0){
                     return calcScore(bingo.Cards[winner[0]])*bingo.Numbers[i];
                }
            }
        }
        return 0;
    }

    public static int Last(Bingo bingo){
        List<int> winners=new List<int>();

        int[] counters=new int[bingo.Cards.Count];

        int lastScore=0;

        for(int i=0;i<bingo.Numbers.Length;i++){
            markNumbers(bingo, bingo.Numbers[i]);
            if(i>5){
                var winner=getWinners(bingo);
                if(winner.Length>0){
                    int newScore=calcScore(bingo.Cards[winner[0]])*bingo.Numbers[i];
                    if(newScore>0){
                        lastScore=newScore;
                    }

                    if(bingo.Cards.Count==1)
                        return lastScore;
 
                    for(int index=winner.Length-1;index>=0;index--){                                            
                        bingo.Cards.RemoveAt(winner[index]);
                    }
                }
            }
        }
        return lastScore;
    }

    static void markNumbers(Bingo bingo, int number){
        for(int i=0;i<bingo.Cards.Count;i++){
            for(int j=0;j<bingo.Cards[i].GetLength(0);j++){
                for(int k=0;k<bingo.Cards[i].GetLength(1);k++){
                    if(bingo.Cards[i][j,k]==number){
                        bingo.Cards[i][j,k]=-1;
                    }
                }
            }
        }
    }    

    static int[] getWinners(Bingo bingo){
        List<int> winners=new List<int>();
        for(int i=0;i<bingo.Cards.Count;i++){
             for(int j=0;j<bingo.Cards[i].GetLength(0);j++){
                int countRow=0;
                for(int k=0;k<bingo.Cards[i].GetLength(1);k++){
                    if(bingo.Cards[i][j,k]==-1){
                        countRow++;
                    }
                }
                if(countRow==bingo.Cards[i].GetLength(1)){
                    winners.Add(i);              
                }
            }
            

            for(int j=0;j<bingo.Cards[i].GetLength(1);j++){
                int countCol=0;
                for(int k=0;k<bingo.Cards[i].GetLength(0);k++){
                    if(bingo.Cards[i][k,j]==-1){
                        countCol++;
                    }
                }
                if(countCol==bingo.Cards[i].GetLength(1)){
                    if(!winners.Contains(i)){
                        winners.Add(i);
                    }
                }
            }
        }
        winners.Sort();
        return winners.ToArray();
    }

    static int calcScore(int[,] card){
        int score=0;
        for(int i=0;i<card.GetLength(0);i++){
            for(int j=0;j<card.GetLength(1);j++){
                if(card[i,j]!=-1){
                    score+=card[i,j];
                }
            }
        }
        return score;
    }
}