using System.Collections.Generic;
using System.Linq;
using Algorithms.BST;

namespace Algorithms
{
    class TreeLevelTraversal
    {

        Dictionary<int, IList<int>> dict = new Dictionary<int, IList<int>>();

        public IList<IList<int>> LevelOrder(TreeNode root)
        {
            Method(root, 0);

            var res = dict.OrderBy(k => k.Key).ToDictionary(o => o.Key, o => o.Value).Values.ToList();

            return res;
        }


        void Method(TreeNode node, int level)
        {
            if (node == null)
                return;

            Method(node.left, level + 1);


            if (dict.ContainsKey(level))
                dict[level].Add(node.val);
            else
            {
                var i = new List<int>();
                i.Add(node.val);

                dict.Add(level, i);
            }


            Method(node.right, level + 1);
        }
    }
}
