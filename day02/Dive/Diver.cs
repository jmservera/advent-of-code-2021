namespace Dive
{
    using System;
    public class Diver
    {
        public static int CalcPosition((string,int)[] data)
        {
            int h=0,d=0;
            foreach(var l in data){
                switch(l.Item1){
                    case "forward":
                        h+=l.Item2;
                        break;
                    case "down":
                        d+=l.Item2;
                        break;
                    case "up":
                        d-=l.Item2;
                        break;
                }
            }
            return h*d;
        }

    }

}