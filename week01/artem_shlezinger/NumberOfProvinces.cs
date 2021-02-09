namespace Algorithms
{
    class NumberOfProvinces
    {
        int[] idxArr = new int[201];
        int[] sizesArr = new int[201];

        public NumberOfProvinces()
        {
            for (int i = 0; i < 201; i++)
                idxArr[i] = i;
        }

        private int FindRoot(int u)
        {
            if (idxArr[u] != u)
            {
                idxArr[u] = idxArr[idxArr[u]];
                idxArr[u] = FindRoot(idxArr[u]);
            }

            return idxArr[u];
        }

        private void Union(int u, int v)
        {
            int rootU = FindRoot(u);
            int rootV = FindRoot(v);

            if(sizesArr[rootU] > sizesArr[rootV])
            {
                idxArr[rootV] = rootU;
                sizesArr[rootU] += sizesArr[rootV];
            }
            else
            {
                idxArr[rootU] = rootV;
                sizesArr[rootV] += sizesArr[rootU];
            }
        }



        public int FindCircleNum(int[][] isConnected)
        {
            int arrLen = isConnected.Length;

            for (int i = 0; i < arrLen; i++)
                for (int j = i + 1; j < arrLen; j++)
                    if (isConnected[i][j] == 1)
                        Union(i, j);


            int res = 0;

            for(int i = 0; i < arrLen; i++)
                if (idxArr[i] == i)
                    res++;

            return res;
        }
    }
}
