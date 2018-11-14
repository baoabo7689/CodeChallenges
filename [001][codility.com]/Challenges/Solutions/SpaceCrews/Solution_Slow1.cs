namespace SpaceCrews
{
    using System.Collections.Generic;
    using System.Linq;

    public class Solution_Slow1
    {
        public int InverseOfMod(int num, int mod)
        {
            var rList = new List<int>();
            var qList = new List<int>();

            rList.Add(mod);
            rList.Add(num);

            qList.Add(mod);
            qList.Add(num);

            var a = mod;
            var b = num;
            while (b != 0)
            {
                var q = a / b;
                var r = a % b;

                a = b;
                b = r;

                rList.Add(r);
                qList.Add(q);
            }

            var sList = new List<int> { 1, 0 };
            var tList = new List<int> { 0, 1 };
            var maxIndex = rList.Count - 3;
            for (var i = 0; i < maxIndex; i++)
            {
                sList.Add(sList[i] - sList[i + 1] * qList[i + 2]);
                tList.Add(tList[i] - tList[i + 1] * qList[i + 2]);
            }

            // s*mod + t*num = gcd 
            // t*num = gcd % s
            var result = (tList[tList.Count - 1] + mod) % mod;
            return result;
        }

        public int solution(int[] T, int[] D)
        {
            var N = T.Length;
            var maxT = T.Max();
            var mod = 1410000017;

            var multipliers = new List<long>();
            var inversions = new List<long>();

            multipliers.Add(1);
            inversions.Add(1);

            long multiply = 1;
            long inversion = 1;
            for (var i = 1; i <= maxT; i++)
            {
                multiply = (multiply * i) % mod;
                inversion = (inversion * InverseOfMod(i, mod)) % mod;

                multipliers.Add(multiply);
                inversions.Add(inversion);
            }

            long result = 1;

            for (var i = 0; i < N; i++)
            {
                var t = T[i];
                var d = D[i];

                var firstPart = (multipliers[t] * inversions[d]) % mod;
                var ways = (firstPart * inversions[t - d]) % mod;
                result = (result * ways) % mod;
            }

            return (int)result;
        }
    }
}