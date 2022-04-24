using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresTraining.Extensions
{
    public static class ArrayExtensions
    {
		public static int MaxSubArray(this int[] nums)
		{
			int currentSum = nums[0];
			int maximumSum = nums[0];

			for (int i = 1; i < nums.Length; i++)
			{
				currentSum = Math.Max(currentSum + nums[i], nums[i]);
				maximumSum = Math.Max(maximumSum, currentSum);
			}

			return maximumSum;
		}
		public static void Print(this int[] array)
		{
			for(int i = 0; i < array.Length; i++)
            {
				Console.Write($"{array[i]} ");
            }
			Console.Write("\n");
		}
        public static int[] PlusOne(this int[] digits)
        {
            for (int i = digits.Length - 1; i >= 0; i--)
            {
                if (i == 0 && digits[i] == 9)
                {
                    digits[i] = 0;
                    return digits.Prepend(1).ToArray();
                }

                if (digits[i] != 9)
                {
                    digits[i] = digits[i] + 1;
                    return digits;
                }
                else
                    digits[i] = 0;
            }
            return digits;
        }
    }
}
