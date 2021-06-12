namespace Algorithms
{
    class JumpGame
    {
        public bool CanJump(int[] nums)
        {
            int maxJump = nums[0];
            int maxIdx = 0;

            if (nums[0] == 0 && nums.Length > 1)
                return false;

            for (int i = 1; i < nums.Length - 1; i++)
            {
                if (nums[i] == 0 && i - maxIdx >= maxJump)
                    return false;

                if (nums[i] + i >= maxJump + maxIdx)
                {
                    maxJump = nums[i];
                    maxIdx = i;
                }
            }

            return true;
        }
    }
}
