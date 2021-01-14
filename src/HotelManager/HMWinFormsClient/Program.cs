using System;
using System.Configuration;
using System.Windows.Forms;
using HMCore;

namespace HMWinFormsClient
{
	public static class Program
	{
		[STAThread]
		private static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			App.Init(ConfigurationManager.AppSettings);
			Application.ApplicationExit += (s, e) => App.Dispose();

			Application.Run(new MainForm());
		}
	}
}
