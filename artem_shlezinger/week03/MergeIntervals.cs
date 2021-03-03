using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms
{
    class MergeIntervals
    {

        public int[][] Merge(int[][] intervals)
        {
            intervals = Sort(intervals);

            List<int[]> list = new List<int[]>();

            int[] q = intervals[0];

            for (int i = 1; i < intervals.Length; i++)
            {
                if (q[1] >= intervals[i][0])
                    q[1] = Math.Max(q[1], intervals[i][1]);
                else
                {
                    list.Add(q);
                    q = intervals[i];
                }
            }

            list.Add(q);

            return list.ToArray();
        }


        public int[][] Sort(int[][] intervals)
        {
            return intervals.OrderBy(x => x[0]).ToArray();
        }
    }
}
