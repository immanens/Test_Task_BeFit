using System;
using System.Collections.Generic;
using System.Linq;

namespace TestTask_BeFit
{
	public abstract class PartialSumsCalculator
	{
		public static IEnumerable<Double> GetRowSums(IEnumerable<Double> row)
		{
			Double sum = 0;
			return row.Select(num => sum += num);
		}
	}
}