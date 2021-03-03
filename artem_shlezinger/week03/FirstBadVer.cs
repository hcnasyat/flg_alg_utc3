namespace Algorithms
{
    class FirstBadVer : VersionControl
    {
        public int FirstBadVersion(int n)
        {
            // log N solution

            if (IsBadVersion(1))
                return 1;

            int l = 1;
            int k = n / 2;
            int r = n;

            while(k != r)
            {
                if(IsBadVersion(k))
                {
                    r = k;
                    k = k - (k - l) / 2;
                }
                else
                {
                    l = k;
                    k = k + (r - k + 1) / 2;
                }

            }

            return k;
        }
    }

    internal class VersionControl
    {
        protected bool IsBadVersion(int version)
        {
            return (version > 0);
        }
    }
}
