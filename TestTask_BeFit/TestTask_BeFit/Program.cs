using System;
using System.Collections.Generic;
using System.Linq;

namespace TestTask_BeFit
{
	class Program
	{
		static void Main(String[] args)
		{
			// 1 task
			AsyncTaskProcessor taskProcessor = new AsyncTaskProcessor();

			taskProcessor.AddTask(() => DoTask(1));
			taskProcessor.AddTask(() => DoTask(2));
			taskProcessor.AddTask(() => DoTask(3));

			taskProcessor.WaitForCompletion();

			Console.WriteLine("All tasks completed.");
			
			// 2 task
			IEnumerable<Double> inputRow = Enumerable.Range(1, 10).Select(i => (Double)i);
			IEnumerable<Double> rowSums = PartialSumsCalculator.GetRowSums(inputRow);

			Console.WriteLine("Input Row:");
			Console.WriteLine(String.Join(", ", inputRow));

			Console.WriteLine("Row Sums:");
			Console.WriteLine(String.Join(", ", rowSums));
			
			// 3 task
			const Int32 N = 4;
			Dictionary<Int32, List<Int32>> officials = new Dictionary<Int32, List<Int32>>
			{
				{ 1, new List<Int32> { 2 } },
				{ 2, new List<Int32> { 3, 4 } },
				{ 3, new List<Int32>() },
				{ 4, new List<Int32>() }
			};

			CertificateManager certificateManager = new CertificateManager();
			List<Int32> result = certificateManager.GetCertificatesOrder(N, officials);
        
			Console.WriteLine("Certificate order:");
			foreach (Int32 official in result)
			{
				Console.Write(official + " ");
			}
			
			// 4 task
			ArraySumChecker sumChecker = new ArraySumChecker();
			Int32[] array = new Int32[] { 3, 1, 8, 5, 4 };
			const Int32 targetSum = 10;

			Boolean canBeRepresented = sumChecker.CanSumBeRepresented(array, targetSum);

			Console.WriteLine($"\nThe number {targetSum} can be represented by the sum from the array: {canBeRepresented}");
		}

		private static void DoTask(Int32 taskId)
		{
			Console.WriteLine($"Task {taskId} started.");
			System.Threading.Thread.Sleep(1000);
			Console.WriteLine($"Task {taskId} completed.");
		}
	}
}