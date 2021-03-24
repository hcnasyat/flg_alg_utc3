namespace Algorithms.BST
{
    class SmallestElement
    {
        int i = 0, res, K;

        public int KthSmallest(TreeNode root, int k)
        {
            K = k;
            TraversalTree(root);
            return res;
        }

        public void TraversalTree(TreeNode node)
        {
            if (node == null)
                return;

            TraversalTree(node.left);

            if (K == i)
                return;

            res = node.val;
            i++;

            TraversalTree(node.right);
        }
    }
}
