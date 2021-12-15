using System;
using System.Collections.Generic;
using System.Linq;

namespace Day08.SevenSegments
{
    public class Display
    {
        Data[] data;
        public Display(Data[] data)
        {
            this.data = data;
        }

        public int Count1478Digits()
        {
            int count = 0;
            foreach (var d in data)
            {
                foreach (var digit in d.Digits)
                {
                    if (digit.Length == 2 || digit.Length == 3 || digit.Length == 4 || digit.Length == 7)
                        count++;
                }
            }

            return count;
        }

        // seven segment definition
        static readonly int[][] display = new int[][]{ new int[]{0,1,2,3,4,5},
                                            new int[] {1,2},
                                            new int[]{0,1,3,4,6},
                                            new int[]{0,1,2,3,6},
                                            new int[]{1,2,5,6},
                                            new int[]{0,2,3,5,6},
                                            new int[]{0,2,3,4,5,6},
                                            new int[]{0,1,2},
                                            new int[]{0,1,2,3,4,5,6},
                                            new int[]{0,1,2,3,5,6}};

        public int SumFullDigits()
        {
            int total = 0;

            for (int signalIndex = 0; signalIndex < data.Length; signalIndex++)
            {
                var signals = data[signalIndex].Signals;
                char[] segments = new char[7];

                // detect number 1
                var one = signals.FirstOrDefault(x => x.Length == 2);
                // segments[1] = one[0];
                // segments[2] = one[1];

                // with number one detect the horizontal segment of 7
                var seven = signals.FirstOrDefault(x => x.Length == 3).ToCharArray().Where(x => !one.Contains(x));
                segments[0] = seven.First();

                // detect 4 and get the two remaining segments                
                var four = signals.FirstOrDefault(x => x.Length == 4).ToCharArray().Where(x => !one.Contains(x) && !seven.Contains(x));

                //four has two unknown segments, one vertical and one horizontal, the horizontal one must be present in 2,3,and 5

                var twothreefive = signals.Where(x => x.Length == 5);
                var vfour = four.Where(x => twothreefive.All(y => y.Contains(x)));

                segments[6] = vfour.First();

                var hfour = four.Where(x => x != segments[6]);
                segments[5] = hfour.First();

                // now get the 6 because it is the one that has 6 segments but only one collides with number one, so we know which segment is up and 
                // which is down

                var insix = signals.Where(x => x.Length == 6).Distinct();
                var six = insix.FirstOrDefault(x => (x.Contains(one[0]) && !x.Contains(one[1]) || (!x.Contains(one[0]) && x.Contains(one[1]))));
                segments[2]=six.ToCharArray().Intersect(one.ToCharArray()).First();
                segments[1]=one[0]==segments[2]?one[1]:one[0];

                // now seek for the three that has the third segment, we can locate it because it has 1 and 2
                var three = twothreefive.Where(x => x.Contains(segments[1]) && x.Contains(segments[2])).First().ToCharArray();
                segments[3] = three.Where(x => !segments.Contains(x)).First();

                segments[4] = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g' }.First(x => !segments.Contains(x));


                // build strings
                Dictionary<string, int> displayNumbers = new Dictionary<string, int>(
                    display.Select((x, index) => KeyValuePair.Create(new string(x.Select(y => segments[y]).OrderBy(l=>l).ToArray()), index)));


                //now find the numbers

                var digits = data[signalIndex].Digits;
                int number = 0;
                foreach (var digit in digits)
                {
                    var sortedDigit = new string(digit.ToCharArray().OrderBy(x => x).ToArray());
                    number = number * 10 + displayNumbers[sortedDigit];
                }
                total += number;
            }


            return total;
        }
    }
}
