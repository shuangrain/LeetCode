using System;

namespace _949._Largest_Time_for_Given_Digits
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            var ans = solution.LargestTimeFromDigits(new int[] { 1, 2, 3, 4 });
            Console.WriteLine($"ans:{ans}");
            Console.ReadKey();
        }
    }

    public class Solution
    {
        public string LargestTimeFromDigits(int[] A)
        {
            Array.Sort(A);
            for (int i = 23; i >= 0; i--)
            {
                for (int j = 59; j >= 0; j--)
                {
                    string hour = i.ToString("00");
                    string min = j.ToString("00");
                    int[] tmp = new int[]
                    {
                        int.Parse(hour[0].ToString()),
                        int.Parse(hour[1].ToString()),
                        int.Parse(min[0].ToString()),
                        int.Parse(min[1].ToString())
                    };

                    Array.Sort(tmp);
                    if (A[0] == tmp[0] &&
                        A[1] == tmp[1] &&
                        A[2] == tmp[2] &&
                        A[3] == tmp[3])
                    {
                        return hour + ":" + min;
                    }
                }
            }

            return "";
        }
    }
}
