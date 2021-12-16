using System;
using System.Collections.Generic;

namespace Day10.SyntaxScoring
{
    public class Navigation
    {

        static readonly string openings = "([{<";
        static readonly string closings = ")]}>";
        static readonly int[] scores = { 3, 57, 1197, 25137 };

        static readonly int[] completionScores = { 1, 2, 3, 4 };

        string[] lines;
        public Navigation(string[] lines)
        {
            this.lines = lines;
        }

        public int Score()
        {
            int score = 0;
            foreach (var line in lines)
            {
                Stack<char> stack = new Stack<char>();
                foreach (var c in line)
                {
                    if (openings.Contains(c))
                    {
                        stack.Push(c);
                    }
                    else
                    {
                        char o = stack.Pop();
                        if (closings.IndexOf(c) != openings.IndexOf(o))
                        {
                            score += scores[closings.IndexOf(c)];
                            break;
                        }
                    }
                }
            }
            return score;
        }

        public long CompletionScore()
        {
            List<long> lineScores = new List<long>();

            foreach (var line in lines)
            {
                Stack<char> stack = new Stack<char>();
                foreach (var c in line)
                {
                    if (openings.Contains(c))
                    {
                        stack.Push(c);
                    }
                    else
                    {
                        char o = stack.Pop();
                        if (closings.IndexOf(c) != openings.IndexOf(o))
                        {
                            //bad syntax, ignore line
                            stack.Clear();
                            break;
                        }
                    }
                }

                if (stack.Count > 0)
                {
                    long score = 0;

                    while (stack.Count > 0)
                    {
                        score = score * 5 + completionScores[openings.IndexOf(stack.Pop())];
                    }
                    lineScores.Add(score);
                }

            }
            lineScores.Sort();
            return lineScores[lineScores.Count / 2];
        }

    }
}
