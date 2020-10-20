using System;
using System.Collections.Generic;
using System.Linq;

namespace Find_all_triplets_with_given_sum
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums = new int[] { -2, 0, 0, 2, 2 }; // // -2, 0, 1, 1, 2 // -2, 0, 0, 2, 2
            ThreeSum(nums);
        }

        static IList<IList<int>> ThreeSum(int[] nums)
        {
            Array.Sort(nums);
            int length = nums.Length;
            IList<IList<int>> result = new List<IList<int>>();
            for (int i = 0; i < length - 2; i++)
            {
                if (nums[i] > 0) break; // any number here gthn 0 means no numbers are lessar than this no can be present later as array is already sorted
                if (i == 0 || nums[i] != nums[i - 1])
                {
                    int left = i + 1;
                    int right = length - 1;
                    while (left < right)
                    {
                        int sum = nums[i] + nums[left] + nums[right];
                        if (sum == 0)
                        {
                            result.Add(new List<int>() { nums[i], nums[left], nums[right] });
                            left++;
                            right--;
                            while (nums[left] == nums[left - 1]) left++;
                            while (nums[right] == nums[right + 1]) right--;
                        }
                        else if (sum < 0) left++;
                        else right--;
                    }
                }
            }
            return result;
        }
    }
}
