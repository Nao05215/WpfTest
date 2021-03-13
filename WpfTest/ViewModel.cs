using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;

namespace WpfTest
{
	public class ViewModel
	{
		private Worker _Worker;

		public ReadOnlyReactivePropertySlim<string> Message { get; }

		public ViewModel()
		{
			_Worker = new Worker();

			Message = _Worker
				.ObserveProperty(x => x.Message)
				.ToReadOnlyReactivePropertySlim();

			_Worker.Begin1();
		}
	}
}
