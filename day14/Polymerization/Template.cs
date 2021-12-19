using System;
using System.Collections.Generic;
using System.Linq;

namespace Day14.Polymerization
{
    public class Template
    {

        string initPolymer;
        Dictionary<string, char> rules;
        public Template(string polymer, Dictionary<string, char> rules)
        {
            this.initPolymer = polymer;
            this.rules = rules;
        }

        public long Reaction(int times)
        {
            string polymer = this.initPolymer;
            var counts = new Dictionary<char, long>();

            for (int i = 0; i < polymer.Length; i++)
            {
                if (counts.ContainsKey(polymer[i]))
                {
                    counts[polymer[i]]++;
                }
                else
                    counts[polymer[i]] = 1;
            }
            for (int i = 0; i < polymer.Length - 1; i++)
            {
                // using a recursive function, but one for each character.
                // As we do memoization repeated characters will get the same results
                // in almost no time.
                counts.Merge(react(polymer.Substring(i, 2), times));
            }

            return counts.Max(x => x.Value) - counts.Min(x => x.Value);
        }

        Dictionary<Tuple<string, int>, Dictionary<char, long>> memo = new Dictionary<Tuple<string, int>, Dictionary<char, long>>();

        Dictionary<char, long> react(string polymer, int times)
        {
            // generating the full polymer string is too expensive, we only need to 
            // calculate the quantity of each character and store it in a dictionary
            // this technique alows us to store the dictionary to do memoization and avoid repeating operations
            var key = new Tuple<string, int>(polymer, times);
            if (memo.ContainsKey(key))
            {
                return memo[key];
            }
            Dictionary<char, long> counts = new Dictionary<char, long>();
            if (rules.ContainsKey(polymer))
            {
                var newChar = rules[polymer];
                if (counts.ContainsKey(newChar))
                {
                    counts[newChar]++;
                }
                else
                {
                    counts[newChar] = 1;
                }
                if (times > 1)
                {
                    var left = react(new string(new char[] { polymer[0], newChar }), times - 1);
                    var right = react(new string(new char[] { newChar, polymer[1] }), times - 1);
                    counts.Merge(left).Merge(right);
                }
            }
            memo[key] = counts;
            return counts;
        }
    }


}
