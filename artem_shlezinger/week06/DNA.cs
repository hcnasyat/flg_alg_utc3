using System.Collections.Generic;
using System.Linq;

namespace Algorithms
{
    class DNA
    {
        public IList<string> FindRepeatedDnaSequences(string s)
        {
            HashSet<string> set = new HashSet<string>();
            HashSet<string> resSet = new HashSet<string>();


            for(int i = 0; i <= s.Length - 10; i++)
            {
                string substr = s.Substring(i, 10);

                if (!set.Contains(substr))
                    set.Add(substr);
                else if(!resSet.Contains(substr))
                    resSet.Add(substr);
            }

            return resSet.ToList(); ;
        }
    }
}
