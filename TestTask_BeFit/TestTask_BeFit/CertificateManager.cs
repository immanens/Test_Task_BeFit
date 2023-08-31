using System;
using System.Collections.Generic;

namespace TestTask_BeFit
{
	public class CertificateManager
	{
		public List<Int32> GetCertificatesOrder(Int32 N, Dictionary<Int32, List<Int32>> officials)
		{
			Dictionary<Int32, Int32> inDegrees = new Dictionary<Int32, Int32>();
			foreach (KeyValuePair<Int32, List<Int32>> kvp in officials)
			{
				inDegrees[kvp.Key] = 0;
			}

			foreach (KeyValuePair<Int32, List<Int32>> kvp in officials)
			{
				foreach (Int32 dependency in kvp.Value)
				{
					inDegrees[dependency]++;
				}
			}

			Queue<Int32> queue = new Queue<Int32>();
			foreach (KeyValuePair<Int32, Int32> kvp in inDegrees)
			{
				if (kvp.Value == 0)
				{
					queue.Enqueue(kvp.Key);
				}
			}

			List<Int32> result = new List<Int32>();
			while (queue.Count > 0)
			{
				Int32 official = queue.Dequeue();
				result.Add(official);
            
				foreach (Int32 dependentOfficial in officials[official])
				{
					inDegrees[dependentOfficial]--;
					if (inDegrees[dependentOfficial] == 0)
					{
						queue.Enqueue(dependentOfficial);
					}
				}
			}

			return result;
		}
	}
}