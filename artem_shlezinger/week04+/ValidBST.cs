namespace Algorithms
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    class ValidBST
    {
        bool flag = true;

        public bool IsValidBST(TreeNode root)
        {
            Method(root);

            return flag;
        }

        public void Method(TreeNode node, int? min = null, int? max = null)
        {
            if (min != null && node.val <= min || max != null && node.val >= max)
                flag = false;

            if (node.left != null)
                Method(node.left, min, node.val);

            if (node.right != null)
                Method(node.right, node.val, max);

        }
    }
}
