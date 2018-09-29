using System;
using System.Linq;

namespace _494._Target_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int ans = FindTargetSumWays(new int[] { 1, 1, 1, 1, 1 }, 3);
            int ans2 = FindTargetSumWays2(new int[] { 1 }, 1);
            Console.WriteLine($"ans: {ans}");
            Console.WriteLine($"ans: {ans2}");
            Console.ReadKey();
        }

        #region 解答一

        static int FindTargetSumWays(int[] nums, int S)
        {
            int sum = nums.Sum();
            return Calculate(nums, 0, S, sum);
        }

        static int Calculate(int[] nums, int idx, int targetSum, int sum)
        {
            if (idx == nums.Length)
            {
                return (targetSum == 0) ? 1 : 0;
            }
            // 數字加總 如果小於 目標加總 就不用跑後面的列舉
            else if (sum < targetSum)
            {
                return 0;
            }

            int nextIdx = idx + 1;
            return Calculate(nums, nextIdx, targetSum + nums[idx], sum) +
                   Calculate(nums, nextIdx, targetSum - nums[idx], sum);
        }

        #endregion

        #region 解答二

        static int FindTargetSumWays2(int[] nums, int S)
        {
            int sum = nums.Sum();

            // 利用快取的方式減少重複運算
            int[][] cache = new int[nums.Length][];
            for (int i = 0; i < cache.Length; i++)
            {
                cache[i] = new int[(2 * sum) + 1];
                Array.Fill(cache[i], -1);
            }

            return Calculate2(nums, 0, S, sum, cache);
        }

        static int Calculate2(int[] nums, int idx, int targetSum, int sum, int[][] cache)
        {
            if (idx == nums.Length)
            {
                return (targetSum == 0) ? 1 : 0;
            }
            // 數字加總 如果小於 目標加總 就不用跑後面的列舉
            else if (sum < targetSum)
            {
                return 0;
            }

            int nextIdx = idx + 1;

            if (cache[idx][sum + targetSum] < 0)
            {
                cache[idx][sum + targetSum] =
                    Calculate2(nums, nextIdx, targetSum + nums[idx], sum, cache) +
                    Calculate2(nums, nextIdx, targetSum - nums[idx], sum, cache);
            }

            return cache[idx][sum + targetSum];
        }

        #endregion
    }
}
