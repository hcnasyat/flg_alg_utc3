namespace Algorithms
{
    class Wiggle
    {
        public void WiggleSort(int[] nums)
        {
            // T: n + m (counting sort)
            // S: n + m

            int max = nums[0];
            int len = nums.Length;

            int[] numSorted = new int[len];


            for (int i = 1; i < len; i++)
                if (max < nums[i])
                    max = nums[i];

            int[] numIdx = new int[max + 1];

            for (int i = 0; i < len; i++)
                numIdx[nums[i]]++;


            int j = 0, k = 0;
            while(j < numIdx.Length)
            {
                if(numIdx[j] == 0)
                    j++;
                else
                {
                    numSorted[k] = j;
                    numIdx[j]--;
                    k++;
                }
            }

            for(int i = 0; i < len-1; i += 2)
            {
                nums[i] = numSorted[(len - 1) / 2 - i / 2];
                nums[i+1] = numSorted[len - 1 - i / 2];
            }

            if (len % 2 == 1)
                nums[len - 1] = numSorted[0];
        }
    }
}
