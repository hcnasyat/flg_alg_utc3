using System;

namespace Algorithms.BST
{
    class BalancedBinaryTree
    {
        bool res = true;

        public bool IsBalanced(TreeNode root)
        {
            Traverse(root);

            return res;
        }

        private int Traverse(TreeNode root)
        {
            if (root == null)
                return 0;

            int l = Traverse(root.left);

            int r = Traverse(root.right);

            if (Math.Abs(l - r) > 1)
                res = false;

            return 1 + Math.Max(l,r);
        }
    }
}
