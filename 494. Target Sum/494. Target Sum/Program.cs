using System;
using System.Linq;

namespace _494._Target_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int ans = FindTargetSumWays(new int[] { 1, 1, 1, 1, 1 }, 3);
            Console.WriteLine($"ans: {ans}");
            Console.ReadKey();
        }

        static int FindTargetSumWays(int[] nums, int S)
        {
            int sum = nums.Sum();
            return Calculate2(nums, 0, S, sum);
        }

        static int Calculate2(int[] nums, int idx, int targetSum, int sum)
        {
            if (idx == nums.Length)
            {
                return (targetSum == 0) ? 1 : 0;
            }
            // 數字加總 如果小於 目標加總 就不用跑後面的列舉
            else if (sum <= targetSum)
            {
                return 0;
            }

            int nextIdx = idx + 1;
            return Calculate2(nums, nextIdx, targetSum + nums[idx], sum) +
                   Calculate2(nums, nextIdx, targetSum - nums[idx], sum);
        }
    }
}
