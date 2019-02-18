using System;
using System.Collections.Generic;
using System.Linq;

namespace _637._Average_of_Levels_in_Binary_Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            TreeNode root = new TreeNode(2147483647)
            {
                left = new TreeNode(2147483647),
                right = new TreeNode(2147483647)
            };

            Solution solution = new Solution();
            var ans = solution.AverageOfLevels(root);
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
        public IList<double> AverageOfLevels(TreeNode root)
        {
            IList<KeyValuePair<int, long>> nodeValues = new List<KeyValuePair<int, long>>();
            calcNodeValue(0, root, nodeValues);

            IList<double> results = new List<double>();

            int maxLevel = nodeValues.Max(x => x.Key);
            for (int i = 0; i <= maxLevel; i++)
            {
                var targetLevelItems = nodeValues.Where(x => x.Key == i);
                int count = targetLevelItems.Count();
                long sum = targetLevelItems.Sum(x => x.Value);

                results.Add(sum / (double)count);
            }

            return results;
        }

        private void calcNodeValue(int level, TreeNode node, IList<KeyValuePair<int, long>> nodeValues)
        {
            nodeValues.Add(new KeyValuePair<int, long>(level, node.val));

            if (node.left != null)
            {
                calcNodeValue(level + 1, node.left, nodeValues);
            }

            if (node.right != null)
            {
                calcNodeValue(level + 1, node.right, nodeValues);
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
