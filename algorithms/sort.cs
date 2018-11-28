namespace algorithms
{
    class Sort
    {
        public static void InsertionSortProc(int[] A)
        {
            int i = 1, j = 1, x = 0;
            while (i < A.Length)
            {
                x = A[i];
                j = i - 1;
                while (j >= 0 && A[j] > x)
                {
                    A[j + 1] = A[j];
                    j--;
                }
                A[j + 1] = x;
                i++;
            }
        }

        public static void InsertionSortRecr(int[] A)
        {
            void insertion(int[] B, int n)
            {
                if (n > 0)
                {
                    insertion(B, n - 1);
                    int x = B[n];
                    int j = n - 1;
                    while (j >= 0 && B[j] > x)
                    {
                        B[j + 1] = B[j];
                        j--;
                    }
                    B[j + 1] = x;
                }
            }
            insertion(A, A.Length - 1);
        }
    }
}
