using System.Collections.Generic;
using System.Linq;

namespace Algorithms
{
    class LongestConsecutiveSequence
    {
        HashSet<int> numsSet = new HashSet<int>();

        public int LongestConsecutive(int[] nums)
        {
            if (nums.Length == 0)
                return 0;

            int maxCounter = 1;

            for (int i = 0; i < nums.Length; i++)
                if (!numsSet.Contains(nums[i]))
                    numsSet.Add(nums[i]);

            while (numsSet.Count > 0)
            {
                int counter = MoveRight(numsSet.First());
                counter += MoveLeft(numsSet.First());
                counter--;

                numsSet.Remove(numsSet.First());

                if (counter > maxCounter)
                    maxCounter = counter;
            }

            return maxCounter;
        }


        private int MoveRight(int el)
        {
            int subCounter = 1;

            if (numsSet.Contains(el + 1))
            {
                subCounter += MoveRight(el + 1);
                numsSet.Remove(el + 1);
            }

            return subCounter;
        }

        private int MoveLeft(int el)
        {
            int subCounter = 1;

            if (numsSet.Contains(el - 1))
            {
                subCounter += MoveLeft(el - 1);
                numsSet.Remove(el - 1);
            }

            return subCounter;
        }


    }
}
