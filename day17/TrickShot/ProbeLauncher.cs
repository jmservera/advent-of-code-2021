namespace Day17.TrickShot;
using System.Collections.Generic;
public class ProbeLauncher
{
    int x1,x2,y1,y2;

    /// <summary>
    /// The values define the position of the trench
    /// </summary>
    public ProbeLauncher(int x1, int x2, int y1, int y2)
    {
        if(x1>x2){
            this.x1 = x2;
            this.x2 = x1;
        }
        else{
            this.x1=x1;
            this.x2=x2;
        }
        if(y1>y2){
            this.y1 = y1;
            this.y2 = y2;
        }
        else{
            this.y1=y2;
            this.y2=y1;
        }
    }

    bool trenchShot;
    int maxY;
    public bool TrenchShot => trenchShot;
    public int MaxY=> maxY;

    public int[][] Launch(int xSpeed, int ySpeed){
        trenchShot=false;
        maxY=0;

        var steps=new List<int[]>();
        int x=0,y=0;
        do{
            x+=xSpeed;
            y+=ySpeed;
            maxY=Math.Max(maxY,y);

            steps.Add(new int[]{x,y});
            if(xSpeed>0){
                xSpeed--;
            }
            else if(xSpeed<0){
                 xSpeed++; }
            ySpeed--;

            if((x1<=x && x<=x2) && (y1>=y && y>=y2)){
                trenchShot=true;
                break;
            }
            if(y<y2){
                //trench missed
                trenchShot=false;
                break;
            }
        }while( true );

        return steps.ToArray();
    }
    
    public ((int,int),int) FindBestShot(){
        //brute force
        var bestShot=(0,0);
        int bestShotScore=0;
        int countShots=0;

        for(int x=1;x<=x2;x++){
            for(int y=-x2;y<=x2;y++){
                var steps=Launch(x,y);
                if(trenchShot){
                    countShots++;
                    if(maxY>bestShotScore){
                        bestShot=(x,y);
                        bestShotScore=maxY;
                    }
                }
            }
        }
        Console.WriteLine($"Best shot: {bestShotScore} {bestShot} count:{countShots}");
        return (bestShot,countShots);
    }
}
