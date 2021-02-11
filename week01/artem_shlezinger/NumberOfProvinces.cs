namespace Algorithms
{
    class NumberOfProvinces
    {
        int[] idxArr, sizesArr;
        
        public NumberOfProvinces(int n)
        {
            idxArr = new int[n];
            sizesArr = new int[n];

            for (int i = 0; i < n; i++)
                idxArr[i] = i;
        }

        private int FindRoot(int u)
        {
            while(idxArr[u] != u)
            {
                idxArr[u] = idxArr[idxArr[u]];
                u = idxArr[u];
            }

            return u;
        }

        private void Union(int u, int v)
        {
            int uRoot = FindRoot(u);
            int vRoot = FindRoot(v);

            if(sizesArr[uRoot] > sizesArr[vRoot])
            {
                idxArr[vRoot] = uRoot;
                sizesArr[uRoot] += sizesArr[vRoot];
            }
            else
            {
                idxArr[uRoot] = vRoot;
                sizesArr[vRoot] += sizesArr[uRoot];
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
