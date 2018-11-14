namespace Test001
{
    public static class Solution
    {
        public static int solution(int[] B, int M)
        {
            var N = B.Length;
            var A = new System.Collections.Generic.List<int>(N);

            for (var i = 1; i < N; i++)
            {
                var b = B[i];
                if (b == 0)
                {
                    A.Add(-1);
                    continue;
                }
            }


            var modl = System.Math.Pow(10, 9) + 7;
            var count = 0;

            return count;
        }
    }
}
