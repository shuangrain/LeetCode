using System;

namespace _112._Path_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            TreeNode root = new TreeNode(5)
            {
                left = new TreeNode(4)
                {
                    left = new TreeNode(11)
                    {
                        left = new TreeNode(7),
                        right = new TreeNode(2)
                    }
                },
                right = new TreeNode(8)
                {
                    left = new TreeNode(13),
                    right = new TreeNode(4)
                    {
                        left = null,
                        right = new TreeNode(1)
                    }
                }
            };

            Solution solution = new Solution();

            Console.Write($"{solution.HasPathSum(root, 22)}");
            Console.ReadKey();
        }
    }

    /**
     * Definition for a binary tree node.
     * public class TreeNode {
     *     public int val;
     *     public TreeNode left;
     *     public TreeNode right;
     *     public TreeNode(int x) { val = x; }
     * }
     */
    public class Solution
    {
        public bool HasPathSum(TreeNode root, int sum)
        {
            if (root == null)
            {
                return false;
            }

            return sumNum(root.val, sum, root.left, root.right);
        }

        private bool sumNum(int num, int sum, TreeNode left, TreeNode right)
        {
            if (left == null && right == null)
            {
                return (num == sum);
            }

            if (left != null && right == null)
            {
                return sumNum(num + left.val, sum, left.left, left.right);
            }

            if (left == null && right != null)
            {
                return sumNum(num + right.val, sum, right.left, right.right);
            }

            return sumNum(num + left.val, sum, left.left, left.right) ||
                   sumNum(num + right.val, sum, right.left, right.right);
        }
    }

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }
}
