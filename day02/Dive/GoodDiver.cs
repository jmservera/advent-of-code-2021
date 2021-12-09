namespace Dive
{

    using System;

    public class GoodDiver
    {
        int aim;
        public int CalcPosition((string,int)[] data)
        {
            int h=0,d=0;
            foreach(var l in data){
                switch(l.Item1){
                    case "forward":
                        h+=l.Item2;
                        d+=(l.Item2*aim);
                        break;
                    case "down":
                        aim+=l.Item2;
                        break;
                    case "up":
                        aim-=l.Item2;
                        break;
                }
            }
            return h*d;
        }
    }
}