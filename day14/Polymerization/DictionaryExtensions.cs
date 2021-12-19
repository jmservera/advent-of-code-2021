using System.Collections.Generic;

namespace Day14.Polymerization
{
    public static class DictionaryExtensions
    {
        public static Dictionary<char, long> Merge(this Dictionary<char, long> target, Dictionary<char, long> source)
        {
            foreach (var k in source.Keys)
            {
                if (target.ContainsKey(k))
                {
                    target[k] += source[k];
                }
                else
                    target[k] = source[k];
            }
            return target;
        }
    }
}