using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms
{
    class Sums
    {
        public IList<IList<int>> FourSum(int[] nums, int target)
        {
            Dictionary<string, IList<int>> resHash = new Dictionary<string, IList<int>>();

            Array.Sort(nums);

            int l, r;

            int[] a = new int[nums.Length];

            for(int i = 0; i < a.Length; i++)
                a[i] = target - nums[i];


            for (int k = 0; k < a.Length; k++)
            {
                for (int i = 0; i < nums.Length; i++)
                {
                    if (i > 0 && nums[i - 1] == nums[i] || k == i)
                        continue;

                    l = i;
                    r = nums.Length - 1;
                    while (l < r)
                    {
                        if (i == l || l > 0 && nums[l - 1] == nums[l] && l - 1 != i || k == l)
                        {
                            l++;
                            continue;
                        }

                        if (i == r || r < nums.Length - 1 && nums[r + 1] == nums[r] && r + 1 != i || k == r)
                        {
                            r--;
                            continue;
                        }

                        if (nums[l] + nums[r] + nums[i] > a[k])
                            r--;
                        else if (nums[l] + nums[r] + nums[i] < a[k])
                            l++;
                        else
                        {
                            int[] arr = new int[4];
                            arr[0] = nums[k];
                            arr[1] = nums[i];
                            arr[2] = nums[l];
                            arr[3] = nums[r];

                            Array.Sort(arr);

                            string str = string.Join(",", arr);

                            if (!resHash.ContainsKey(str))
                                resHash.Add(str, arr.ToList());

                            l++;
                            r--;
                        }
                    }
                }
            }

            return resHash.Values.ToList();
        }

    }
}
