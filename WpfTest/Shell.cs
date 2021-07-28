using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace WpfTest
{
	// test
	public class Shell : Application
	{
		/// <summary>
		/// InitializeComponent
		/// </summary>
		public void InitializeComponent()
		{
			StartupUri = new Uri("MainWindow.xaml", System.UriKind.Relative);
		}

		/// <summary>
		/// Application Entry Point.
		/// </summary>
		[System.STAThreadAttribute()]
		public static void Main()
		{
			Shell app = new Shell();
			app.InitializeComponent();
			app.Run();
		}
	}
}
