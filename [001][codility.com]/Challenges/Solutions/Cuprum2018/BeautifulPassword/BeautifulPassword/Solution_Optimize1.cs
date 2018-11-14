namespace BeautifulPassword
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Solution_Optimize1
    {
        public int solution(string S)
        {
            //Console.WriteLine(S);

            var N = S.Length;

            var evensDinctionary = new Dictionary<char, List<int>>();
            foreach (var s in S)
            {
                if (!evensDinctionary.ContainsKey(s))
                {
                    evensDinctionary[s] = Enumerable.Repeat(0, S.Length + 1).ToList();
                }
            }

            var c = S[0];
            evensDinctionary[c][1] = 1;

            for (var i = 1; i < N; i++)
            {
                c = S[i];
                foreach (var evensD in evensDinctionary)
                {
                    evensD.Value[i + 1] = evensD.Value[i];
                }

                evensDinctionary[c][i + 1] = evensDinctionary[c][i + 1] + 1;
            }

            //foreach (var evensD in evensDinctionary)
            //{
            //    Console.WriteLine(evensD.Key);
            //    Console.WriteLine(string.Join(", ", evensD.Value));
            //}

            return 0;
            var firstPosition = new Dictionary<string, int>();
            var maxLength = 0;
            for (var i = 0; i <= N; i++)
            {
                var key = "";
                foreach (var evensD in evensDinctionary)
                {
                    key += evensD.Value[i] % 2 == 0 ? 1 : 0;
                }

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
