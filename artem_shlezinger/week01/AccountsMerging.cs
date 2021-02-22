using System;
using System.Collections.Generic;

namespace Algorithms
{
    class AccountsMerging
    {
        int[] idxArr, sizesArr;

        public AccountsMerging(int n)
        {
            idxArr = new int[n];
            sizesArr = new int[n];

            for (int i = 0; i < n; ++i)
                idxArr[i] = i;
        }

        public int FindRoot(int x)
        {
            while(idxArr[x] != x)
            {
                idxArr[x] = idxArr[idxArr[x]];
                x = idxArr[x];
            }

            return x;
        }

        public void Union(int u, int v)
        {
            int uRoot = FindRoot(u);
            int vRoot = FindRoot(v);

            if (sizesArr[uRoot] > sizesArr[vRoot])
            {
                idxArr[vRoot] = uRoot;
                sizesArr[uRoot] += sizesArr[vRoot];
            }
            else
            {
                idxArr[uRoot] = vRoot;
                sizesArr[vRoot] += sizesArr[uRoot];
            }
        }

        public IList<IList<string>> AccountsMerge(IList<IList<string>> accounts)
        {
            Dictionary<int, string> emailNamesDict = new Dictionary<int, string>();
            Dictionary<string, int> emailIDsDict = new Dictionary<string, int>();

            int id = -1;
            foreach (List<string> account in accounts)
            {
                string name = "";
                foreach (string email in account)
                {
                    if (name == "")
                    {
                        name = email;
                        continue;
                    }

                    if (!emailIDsDict.ContainsKey(email))
                    {
                        id++;
                        emailIDsDict.Add(email, id);
                        emailNamesDict.Add(id, name);
                    }

                    Union(emailIDsDict[account[1]], emailIDsDict[email]);
                }
            }

            Dictionary<int, List<string>> finalDict = new Dictionary<int, List<string>>();

            foreach (var item in emailIDsDict)
            {
                int parentNode = FindRoot(item.Value);

                if (!finalDict.ContainsKey(parentNode))
                {
                    var l = new List<string>();
                    l.Add(item.Key);
                    finalDict.Add(parentNode, l);
                }
                else
                {
                    var v = finalDict[parentNode];
                    v.Add(item.Key);
                }
            }

            IList<IList<string>> finalList = new List<IList<string>>();

            foreach (var item in finalDict)
            {
                string name = emailNamesDict[item.Key];
                item.Value.Sort((string left, string right) => { return String.CompareOrdinal(left, right); });
                item.Value.Insert(0, name);
                finalList.Add(item.Value);
            }

            return finalList;
        }
    }
}
