using System;
using System.Collections.Generic;
using System.Linq;

namespace algorithms
{
    class Algorithms
    {
        // TODO: replace this with multiple levels of output verbosity: full, diag, perf, none
        private static readonly bool ShowOutput = true;
        private static readonly int size = 16;
        private static readonly int max = 1024;
        private static int[] A;

        static IEnumerable<int> RandList(Random random) { while (true) { yield return random.Next(max); } }

        static void Main(string[] args)
        {
            var random = new Random();
            A = RandList(random).Take(size).ToArray();

            // Insertion sort
            ExecuteAlgorithm<Action<int[]>>(Sort.InsertionSortProc, A, "Insertion Sort Proceedural");
            ExecuteAlgorithm<Action<int[]>>(Sort.InsertionSortRecr, A, "Insertion Sort Recursive");
            // Selection sort
            ExecuteAlgorithm<Action<int[]>>(Sort.SelectionSortProc, A, "Selection Sort Proceedural");
        }

        static void ExecuteAlgorithm<Alg>(Alg alg, int[] A, string title="")
        {
            // Create A' as a copy of A
            var Aprime = new int[size];
            Array.Copy(A, Aprime, A.Length);

            // Execute algorithm on A'
            if (typeof(Alg) == typeof(Action<int[]>))
            {
                ((Delegate)(object)alg).DynamicInvoke(Aprime);
            }
            else if (typeof(Alg) == typeof(Func<int[], int[]>))
            {
                Aprime = (int[])((Delegate)(object)alg).DynamicInvoke(Aprime);
            }

            // Display Results
            if (ShowOutput)
            {
                Console.WriteLine(title);
                Console.Write($"Before: [{string.Join(", ", A     )}]\n");
                Console.Write($"After:  [{string.Join(", ", Aprime)}]\n");
                Console.ReadLine();
            }
        }
    }
}
