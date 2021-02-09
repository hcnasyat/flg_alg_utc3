using System;
using System.Collections.Generic;

namespace Algorithms
{
    class AccountsMerging
    {
        int[] idxArr = new int[10001];
        int[] sizesArr = new int[10001];

        public AccountsMerging()
        {
            for (int i = 0; i <= 10000; ++i)
                idxArr[i] = i;
        }

        public int FindRoot(int x)
        {
            if (idxArr[x] != x)
            {
                idxArr[x] = idxArr[idxArr[x]];
                idxArr[x] = FindRoot(idxArr[x]);
            }
            return idxArr[x];
        }

        public void Union(int u, int v)
        {
            int rootU = FindRoot(u);
            int rootV = FindRoot(v);

            if (sizesArr[rootU] > sizesArr[rootV])
            {
                idxArr[rootV] = rootU;
                sizesArr[rootU] += sizesArr[rootV];
            }
            else
            {
                idxArr[rootU] = rootV;
                sizesArr[rootV] += sizesArr[rootU];
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
