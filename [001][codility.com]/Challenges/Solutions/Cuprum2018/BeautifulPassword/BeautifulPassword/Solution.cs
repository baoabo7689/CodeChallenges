namespace BeautifulPassword
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Solution
    {
        public int solution(string S)
        {
            var N = S.Length;

            var evensDinctionary = new Dictionary<char, List<bool>>();
            foreach (var s in S)
            {
                if (evensDinctionary.ContainsKey(s))
                {
                    continue;
                }

                var values = new List<bool> { true };
                for (var i = 0; i < N; i++)
                {
                    var c = S[i];
                    var lastValue = values[i];
                    values.Add(c == s ^ lastValue);
                }

                evensDinctionary[s] = values;
            }

            var keys = Enumerable.Repeat((long)0, N + 1).ToList();
            long pow = 1;
            foreach (var evensD in evensDinctionary)
            {
                var key = evensD.Key;
                var values = evensD.Value;

                for (var i = 0; i <= N; i++)
                {
                    keys[i] += values[i] ? pow : 0;
                }

                pow *= 2;
            }

            var maxLength = 0;
            var firstPosition = new Dictionary<long, int>();
            for (var i = 0; i <= N; i++)
            {
                var key = keys[i];

                if (firstPosition.ContainsKey(key))
                {
                    maxLength = Math.Max(maxLength, i - firstPosition[key]);
                }
                else
                {
                    firstPosition.Add(key, i);
                }
            }

            return maxLength;
        }
    }
}
