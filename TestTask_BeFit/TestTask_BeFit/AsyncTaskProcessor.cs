using System;
using System.Collections.Generic;
using System.Threading;

namespace TestTask_BeFit
{
	public class AsyncTaskProcessor
	{
		private readonly Queue<Action> _taskQueue = new Queue<Action>();
		private readonly Object _lockObject = new Object();
		private Boolean _isProcessing = false;

		public void AddTask(Action task)
		{
			lock (_lockObject)
			{
				_taskQueue.Enqueue(task);

				if (!_isProcessing)
				{
					_isProcessing = true;
					ProcessTasks();
				}
			}
		}

		private void ProcessTasks()
		{
			while (true)
			{
				Action task;

				lock (_lockObject)
				{
					if (_taskQueue.Count == 0)
					{
						_isProcessing = false;
						break;
					}

					task = _taskQueue.Dequeue();
				}

				try
				{
					task();
				}
				catch (Exception ex)
				{
					Console.WriteLine($"An error occurred while processing a task: {ex.Message}");
				}
			}
		}

		public void WaitForCompletion()
		{
			while (true)
			{
				lock (_lockObject)
				{
					if (!_isProcessing && _taskQueue.Count == 0)
					{
						break;
					}
				}

				Thread.Sleep(100);
			}
		}
	}
}