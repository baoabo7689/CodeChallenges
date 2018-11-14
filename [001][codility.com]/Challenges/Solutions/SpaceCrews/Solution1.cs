namespace SpaceCrews
{
    using System.Collections.Generic;
    using System.Linq;

    public class Solution1
    {
        // Wrong
        public int solution(int[] T, int[] D)
        {
            var N = T.Length;
            var maxT = T.Max();
            var mod = 1410000017;

            var multipliers = new List<int>();
            multipliers.Add(1);

            var multiply = 1;
            for (var i = 1; i <= maxT; i++)
            {
                multiply = (multiply * i) % mod;
                multipliers.Add(multiply);
            }

            int result = 1;

            for (var i = 0; i < N; i++)
            {
                var t = T[i];
                var d = D[i];

                var ways = multipliers[t] / (multipliers[d] * multipliers[t - d]);
                result = (result * ways) % mod;
            }

            return result;
        }
    }
}