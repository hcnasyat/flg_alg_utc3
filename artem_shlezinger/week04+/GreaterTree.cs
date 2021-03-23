using Algorithms.BST;

namespace Algorithms
{
    class GreaterTree
    {
        int sum = 0;

        public TreeNode BstToGst(TreeNode root)
        {
            CalcTree(root);

            return root;
        }

        public void CalcTree(TreeNode node)
        {
            if (node == null)
                return;

            CalcTree(node.right);

            sum += node.val;
            node.val = sum;
            //Console.WriteLine(sum);

            CalcTree(node.left);
        }
    }
}
