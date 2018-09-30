using System;
using System.Collections.Generic;
using System.Linq;

namespace _515._Find_Largest_Value_in_Each_Tree_Row
{
    class Program
    {
        static void Main(string[] args)
        {
            TreeNode root = new TreeNode(1)
            {
                left = new TreeNode(3)
                {
                    left = new TreeNode(5),
                    right = new TreeNode(3)
                },
                right = new TreeNode(2)
                {
                    left = null,
                    right = new TreeNode(9)
                }
            };

            Solution solution = new Solution();
            var ans = solution.LargestValues(root);
            Console.WriteLine($"ans:{string.Join(',', ans)}");
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
        Dictionary<int, List<int>> dict = new Dictionary<int, List<int>>();

        public IList<int> LargestValues(TreeNode root)
        {
            List<int> list = new List<int>();

            if (root == null)
            {
                return list;
            }

            list.Add(root.val);
            FindNum(0, root.left, root.right);
            list.AddRange(dict.Keys.Select(x => dict[x].Max()));

            return list;
        }

        public void FindNum(int idx, TreeNode left, TreeNode right)
        {
            if (left == null && right == null)
            {
                return;
            }

            if (!dict.ContainsKey(idx))
            {
                dict[idx] = new List<int>();
            }

            if (left != null)
            {
                dict[idx].Add(left.val);
                FindNum(idx + 1, left.left, left.right);
            }

            if (right != null)
            {
                dict[idx].Add(right.val);
                FindNum(idx + 1, right.left, right.right);
            }
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
