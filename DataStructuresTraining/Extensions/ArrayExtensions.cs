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
	}
}
