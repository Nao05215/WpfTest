using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace WpfTest
{
	public class Worker : BindableBase
	{
		private Task _Task;

		private string _Message;
		public string Message
		{
			get { return _Message; }
			set { SetProperty(ref _Message, value); }
		}

		public void Begin1()
		{
			if(_Task != null && !_Task.IsCompleted)
			{
				Trace.WriteLine("Already began");
				return;
			}

			_Task = Task.Run(() =>
			{
				int i = 0;
				while (true)
				{
					try
					{
						Trace.Write($"TID : {Thread.CurrentThread.ManagedThreadId}\n");
						Message = $"Number: {i++}";
					}
					catch(Exception e)
					{
						Trace.WriteLine(e.Message);
					}
					Thread.Sleep(100);
				}
			});
		}

		public void Begin2()
		{
			if (_Task != null && !_Task.IsCompleted)
			{
				Trace.WriteLine("Already began");
				return;
			}

			_Task = Task.Run(async () =>
			{
				int i = 0;
				while (true)
				{
					try
					{
						Trace.Write($"TID : {Thread.CurrentThread.ManagedThreadId}\n");
						Message = $"Number: {i++}";
					}
					catch (Exception e)
					{
						Trace.WriteLine(e.Message);
					}
					await Task.Delay(100);
				}
			});
		}
	}
}
