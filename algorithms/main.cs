using System;
using System.Collections.Generic;
using System.Linq;

namespace algorithms
{
    class Algorithms
    {
        private static readonly int size = 16;
        private static readonly int max = 1024;
        private static int[] A;

        static IEnumerable<int> RandList(Random random) { while (true) { yield return random.Next(max); } }

        static void Main(string[] args)
        {
            var random = new Random();
            A = RandList(random).Take(size).ToArray();

            // Insertion sort
            ExecuteAlgorithm<Action<int[]>>(Sort.InsertionSortProc, A, true);
            ExecuteAlgorithm<Action<int[]>>(Sort.InsertionSortRecr, A, true);
        }

        static void ExecuteAlgorithm<Alg>(Alg alg, int[] A, bool show_output=false)
        {
            // Create A' as a copy of A
            var Aprime = new int[size];
            Array.Copy(A, Aprime, A.Length);

            // Execute algorithm on A'
            if (typeof(Alg) == typeof(Action<int[]>))
            {
                ((Delegate)(object)alg).DynamicInvoke(Aprime);
            }
            else if (typeof(Alg) == typeof(Func<int[]>))
            {
                Aprime = (int[])((Delegate)(object)alg).DynamicInvoke(Aprime);
            }

            // Display Results
            if (show_output)  // TODO: replace this with multiple levels of output verbosity: full, diag, perf, none
            {
                Console.Write("Before: [" + string.Join(", ", A) + "]\n");
                Console.Write("After:  [" + string.Join(", ", Aprime) + "]\n");
                Console.ReadLine();
            }
        }
    }
}
