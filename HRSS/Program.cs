using System;
using System.Threading;
using System.Windows.Forms;

namespace HRSS
{
	internal static class Program
	{
		private static Form _form;

		/// <summary>
		///     The main entry point for the application.
		/// </summary>
		[STAThread]
		private static void Main()
		{
			Thread.GetDomain().UnhandledException +=
				(sender, eventArgs) => Exiting((Exception)eventArgs.ExceptionObject);
			AppDomain.CurrentDomain.ProcessExit +=
				(sender, eventArgs) => Exiting(null);

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			_form = new Form1();
			Application.Run(_form);
		}

		private static void Exiting(Exception ex)
		{
			if (ex != null)
			{
				ErrLog.settings.apikey = "insert-your-errlog.io-api-key-here";
				ErrLog.logger.log(ex);
			}
			_form.Close();

		}
	}
}