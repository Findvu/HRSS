using System.Drawing;
using System.Windows.Forms;

namespace HRSS
{
	public static class TopMostMessageBox
	{
		public static DialogResult Show(string message)
		{
			return Show(message, string.Empty, MessageBoxButtons.OK);
		}

		public static DialogResult Show(string message, string title)
		{
			return Show(message, title, MessageBoxButtons.OK);
		}

		public static DialogResult Show(string message, string title,
			MessageBoxButtons buttons)
		{
			// Create a host form that is a TopMost window which will be the 
			// parent of the MessageBox.
			var topmostForm = new Form
			{
				Size = new Size(1, 1), StartPosition = FormStartPosition.Manual
			};
			// We do not want anyone to see this window so position it off the 
			// visible screen and make it as small as possible
			var rect = SystemInformation.VirtualScreen;
			topmostForm.Location = new Point(rect.Bottom + 10, rect.Right + 10);
			topmostForm.Show();
			// Make this form the active form and make it TopMost
			topmostForm.Focus();
			topmostForm.BringToFront();
			topmostForm.TopMost = true;
			// Finally show the MessageBox with the form just created as its owner
			var result = MessageBox.Show(topmostForm, message, title, buttons);
			topmostForm.Dispose(); // clean it up all the way

			return result;
		}
	}
}