using System;

namespace Algorithms
{
    class KthLargestElement
    {
        public int FindKthLargest(int[] nums, int k)
        {
            Array.Sort(nums);

            return nums[nums.Length - k];
        }
    }
}
