namespace SpaceCrews
{
    using System;

    internal class Program
    {
        private static void Main(string[] args)
        {
            var solution = new Solution();
            //var result = solution.solution(new[] { 6, 4, 7 }, new[] { 1, 3, 4 });

            //var result = solution.solution(new[] { 1000 }, new[] { 1 });
            //var result = solution.solution(new[] { 3 }, new[] { 1 });
            //var result = solution.solution(new[] { 6, 4, 7 }, new[] { 1, 3, 4 });
            var result = solution.solution(new[] { 1000000 }, new[] { 1 });
            Console.WriteLine(result);

            // solution.InverseOfMod(38, 102);
        }
    }
}