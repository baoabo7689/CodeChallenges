namespace BeautifulPassword
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Solution_BruteForce
    {
        public int solution(string S)
        {
            Console.WriteLine(S);

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

            foreach (var evensD in evensDinctionary)
            {
                Console.WriteLine(evensD.Key);
                Console.WriteLine(string.Join(", ", evensD.Value));
            }

            var maxLength = 0;
            for (var length = 2; length <= N; length += 2)
            {
                var maxIndex = N - length;
                for (var i = 0; i <= maxIndex; i++)
                {
                    if (!evensDinctionary.Any(kp => (kp.Value[i + length] - kp.Value[i]) % 2 != 0))
                    {
                        maxLength = length;
                        break;
                    }
                }
            }

            return maxLength;
        }
    }
}
