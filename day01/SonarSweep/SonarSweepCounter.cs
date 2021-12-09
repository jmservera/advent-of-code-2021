using System;

namespace SonarSweep
{
    public class SonarSweepCounter
    {
        public int CountSingle(int[] array)
        {
            int count = 0;
            int previous=array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i]>previous )
                {
                    count++;
                }
                previous=array[i];
            }
            return count;
        }

        public int CountWindow(int[] array, int window){
            int count = 0;
            int previous = 0;
            for(int i=0;i<window;i++)
            {
                previous += array[i];
            }
            for(int i=window;i<array.Length;i++)
            {
                var next = previous - array[i - window] + array[i];
                if (next > previous)
                {
                    count++;
                }
                previous = next;
            }
            
            return count;
        }
    }
}
