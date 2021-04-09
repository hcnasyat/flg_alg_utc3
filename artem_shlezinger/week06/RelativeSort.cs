using System.Collections.Generic;
using System.Linq;

namespace Algorithms.HashTables
{
    class RelativeSort
    {

        public int[] RelativeSortArray(int[] arr1, int[] arr2)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();

            foreach (int a in arr1)
            {
                if (dict.ContainsKey(a))
                    dict[a]++;
                else
                    dict.Add(a, 1);
            }

            int[] res = new int[arr1.Length];

            int i = 0;

            foreach (int d in arr2)
            {
                int j = i;
                while (i < dict[d] + j)
                {
                    res[i] = d;
                    i++;
                }

                dict.Remove(d);
            }


            while(dict.Count > 0)
            {
                int e = dict.Keys.Min();
                int j = i;
                while (i < dict[e] + j)
                {
                    res[i] = e;
                    i++;
                }

                dict.Remove(e);
            }

            return res;
        }
    }
}
