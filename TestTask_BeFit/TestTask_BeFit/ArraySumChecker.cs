using System;

namespace TestTask_BeFit
{
	public class ArraySumChecker
	{
		public Boolean CanSumBeRepresented(Int32[] array, Int32 targetSum)
		{
			switch (targetSum)
			{
				// Base cases
				case 0:
					return true;
				case < 0:
					return false;
			}

			// Dynamic programming array to store the intermediate results
			Boolean[] dp = new Boolean[targetSum + 1];
			dp[0] = true;

			// Traverse through the array and update the dynamic programming array
			foreach (Int32 num in array)
			{
				for (Int32 i = targetSum; i >= num; i--)
				{
					if (dp[i - num])
						dp[i] = true;
				}
			}

			return dp[targetSum];
		}
	}
}