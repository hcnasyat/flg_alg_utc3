using System.Collections.Generic;

namespace Algorithms
{
    class Palindrome
    {
        public int LongestPalindrome(string s)
        {
            HashSet<char> hashSet = new HashSet<char>();

            int res = 0;

            foreach(char c in s)
            {
                if (hashSet.Contains(c))
                {
                    res += 2;
                    hashSet.Remove(c);
                }
                else
                    hashSet.Add(c);
            }

            if (res < s.Length)
                res++;

            return res;
        }
    }
}
