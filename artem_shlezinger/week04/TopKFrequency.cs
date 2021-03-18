using Algorithms.PriorityQueue;
using System.Collections.Generic;

namespace Algorithms
{
    class TopKFrequency
    {
        
        public IList<string> TopKFrequent(string[] words, int k)
        {
            Dictionary<string,int> freqDict = new Dictionary<string, int>();

            foreach (string word in words)
            {
                if (freqDict.ContainsKey(word))
                    freqDict[word]++;
                else
                    freqDict.Add(word, 1);
            }

            BinaryHeapExtended heap = new BinaryHeapExtended(freqDict.Count);

            foreach(var dictItem in freqDict)
                heap.Insert(new Item(dictItem.Value, dictItem.Key));


            List<string> res = new List<string>();

            while (k > 0)
            {
                res.Add(heap.DelMax().Value);
                k--;
            }

            return res;
        }
    }
}
