using System;

namespace _479._Largest_Palindrome_Product
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            var ans = solution.LargestPalindrome(8);
            Console.WriteLine($"ans:{ans}");
            Console.ReadKey();
        }
    }

    public class Solution
    {
        public int LargestPalindrome(int n)
        {
            return Solution2(n);
        }

        public int Solution1(int n)
        {
            if (n <= 0)
            {
                return 0;
            }

            string temp = string.Empty;
            for (int i = 0; i < n; i++)
            {
                temp += "9";
            }

            int maxNum = int.Parse(temp);

            for (long i = (long)maxNum * (long)maxNum; i > 0; i--)
            {
                string numString = i.ToString();
                if (numString.Length >= 2 && numString.Length % 2 != 0)
                {
                    continue;
                }

                int half = numString.Length / 2;
                string part1 = Reverse(numString.Substring(0, half));
                string part2 = numString.Substring(half, half);
                if (part1 != part2)
                {
                    continue;
                }

                for (int j = maxNum; j > 0; j--)
                {
                    if (i % j == 0 && i / j <= maxNum)
                    {
                        return (int)(i % 1337);
                    }
                }
            }

            return 0;
        }

        public int Solution2(int n)
        {
            if (n == 1)
            {
                return 9;
            }

            int maxBound = (int)Math.Pow(10, n) - 1;
            int minBound = (int)Math.Pow(10, n - 1);
            long maxNum = (long)maxBound * (long)maxBound;

            string str = maxNum.ToString();
            long maxFront = long.Parse(str.Substring(0, str.Length / 2));

            for (long i = maxFront; i > 0; i--)
            {
                long palindrome = long.Parse(i.ToString() + Reverse(i.ToString()));

                for (long j = maxBound; j > minBound; j--)
                {
                    // 避免超出 N 位數
                    if (palindrome / j > maxBound)
                    {
                        break;
                    }

                    if (palindrome % j == 0)
                    {
                        return (int)(palindrome % 1337);
                    }
                }
            }

            return 0;
        }

        public string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
