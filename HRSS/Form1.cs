using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutoUpdaterDotNET;
using Capture;
using Capture.Hook;
using Capture.Interface;
using ImageFormat = System.Drawing.Imaging.ImageFormat;

namespace HRSS
{
	public partial class Form1 : Form
	{
		private const int SwpNopos = 0x0002;
		private const int SwpNozorder = 0x0004;
		private const int SwpShowwindow = 0x0040;
		private const int SwpNosendchanging = 0x0400;
		private const int ScreenShotTimeoutSeconds = 15;
		private readonly string _desktopPath;
		private CaptureProcess _captureProcess;
		private bool _capturing;
		private IntPtr _hwnd;
		private NativeMethods.WindowShowStyle _style;

		private int _w0, _h0;

		public Form1()
		{
			InitializeComponent();
			FormClosing += Form_FormClosing;
			_w0 = _h0 = 0;
			_hwnd = IntPtr.Zero;
			_desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			AutoUpdater.Start("http://www.imvu-e.com/products/hrss/release.xml");
		}

		private void Form_FormClosing(object sender, FormClosingEventArgs e)
		{
			Detach();
		}

		private void AttachProcess()
		{
			var process = Process.GetProcessesByName("IMVUClient").First();

			if (process.MainWindowHandle == IntPtr.Zero)
				Debug.Print("process doesn't have a mainwindowhandle yet");

			if (HookManager.IsHooked(process.Id))
				Debug.Print($"process id {process.Id} is already hooked");

			var config = new CaptureConfig
			{
				Direct3DVersion = Direct3DVersion.AutoDetect
			};

			var captureInterface = new CaptureInterface();
			captureInterface.RemoteMessage += CaptureInterface_RemoteMessage;
			_captureProcess = new CaptureProcess(process, config, captureInterface);
		}

		/// <summary>
		///     Display messages from the target process
		/// </summary>
		/// <param name="event"></param>
		private static void CaptureInterface_RemoteMessage(MessageReceivedEventArgs @event)
		{
			Debug.Print($"{@event.MessageType} : {@event.Message}");
		}

		/// <summary>
		///     Create the screen shot request
		/// </summary>
		private void CreateScreenshotRequest()
		{
			_captureProcess.BringProcessWindowToFront();
			var rect = new Rectangle(0, 0, 0, 0); // All zerso mean full screen
			_captureProcess.CaptureInterface.BeginGetScreenshot(rect, TimeSpan.FromSeconds(ScreenShotTimeoutSeconds),
				Callback);
		}

		/// <summary>
		///     The callback for when the screenshot has been taken
		/// </summary>
		/// <param name="result"></param>
		private void Callback(IAsyncResult result)
		{
			NativeMethods.ShowWindow(_hwnd, _style);
			NativeMethods.SetWindowPos(_hwnd, IntPtr.Zero, 0, 0, _w0, _h0,
				SwpNozorder | SwpShowwindow | SwpNosendchanging | SwpNopos);

			using (var screenshot = _captureProcess.CaptureInterface.EndGetScreenshot(result))
			{
				Bitmap bitmap = null;
				_captureProcess.CaptureInterface.DisplayInGameText("Screenshot captured...");
				if (screenshot?.Data == null)
				{
					TopMostMessageBox.Show(
						$"Unable to get screenshot in {ScreenShotTimeoutSeconds} seconds. " + Environment.NewLine + " Try a smaller resolution, or ensure IMVU's 3D renderer is set to Direct3D",
						"Failure to screenshot", MessageBoxButtons.OK);
				}
				else
				{
					bitmap = screenshot.ToBitmap();
					if (checkBox1.Checked) bitmap.MakeTransparent(bitmap.GetPixel(1, 1));
					bitmap.Save(_desktopPath + "\\" + GetTimeDate() + ".png", ImageFormat.Png);
				}

				_capturing = false;

				Invoke(new MethodInvoker(() =>
				{
					groupCapture.Enabled = false;
					pictureBox1.Image?.Dispose();
					pictureBox1.Image = bitmap;
					pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
					progressBar1.Value = bitmap == null ? 0 : progressBar1.Maximum;
				}));
			}
		}

		public static string GetTimeDate()
		{
			return DateTime.Now.ToString("yyyyMMdd-HHmmss");
		}

		private void Inject()
		{
			if (_captureProcess != null)
				throw new Exception("Capture process already injected");

			AttachProcess();
		}

		private void Detach()
		{
			if (_captureProcess == null) return;

			HookManager.RemoveHookedProcess(_captureProcess.Process.Id);
			_captureProcess.Dispose();
			_captureProcess = null;
		}

		private void buttonCapture_Click(object sender, EventArgs e)
		{
			groupCapture.Enabled = false;
			pictureBox1.Image = null;
			timer1.Start();
			progressBar1.Maximum = 10 * ScreenShotTimeoutSeconds;
			progressBar1.Value = 1;
			progressBar1.Update();
			pictureBox1.Update();

			int w, h;
			w = h = 0;
			if (radio1x.Checked)
			{
				w = _w0;
				h = _h0;
			}

			if (radio2x.Checked)
			{
				w = _w0 * 2;
				h = _h0 * 2;
			}

			if (radio4x.Checked)
			{
				w = _w0 * 4;
				h = _h0 * 4;
			}

			if (radio8x.Checked)
			{
				w = _w0 * 8;
				h = _h0 * 8;
			}

			if (radioCustom.Checked)
			{
				w = _w0;
				h = _h0;
				var s = textCustom.Text.Split('x');
				if (s.Length >= 1) w = int.Parse(s[0]);
				if (s.Length >= 2) h = int.Parse(s[1]);
			}

			_style = NativeMethods.GetPlacement(_hwnd).showCmd;
			NativeMethods.ShowWindow(_hwnd, NativeMethods.WindowShowStyle.ShowNormal);

			NativeMethods.SetWindowPos(_hwnd, IntPtr.Zero, 0, 0, w, h,
				SwpNozorder | SwpShowwindow | SwpNosendchanging | SwpNopos);
			_capturing = true;

			Task.Factory.StartNew(CreateScreenshotRequest);
		}


		private void Timer1_Tick(object sender, EventArgs e)
		{
			if (progressBar1.Value != progressBar1.Maximum)
				progressBar1.Value++;
			else
				timer1.Stop();
		}

		private void TextCustom_TextChanged(object sender, EventArgs e)
		{
			radioCustom.Checked = true;
		}

		private void timerMonitor_Tick(object sender, EventArgs e)
		{
			if (_capturing) return;

			var processes = Process.GetProcessesByName("IMVUClient");
			if (processes.Length == 0)
			{
				labelStatus.Text = @"IMVU not running.";
				labelStatus.ForeColor = Color.Red;
				labelStatus.Update();
				groupCapture.Enabled = false;
				return;
			}

			if (processes[0].MainWindowHandle == IntPtr.Zero)
			{
				labelStatus.Text = @"IMVU in background.";
				labelStatus.ForeColor = Color.Red;
				labelStatus.Update();
				groupCapture.Enabled = false;
				return;
			}

			NativeMethods.GetWindowRect(processes[0].MainWindowHandle, out var rect);

			_w0 = rect.Width - rect.X;
			_h0 = rect.Height - rect.Y;
			if (_w0 < 200 || _h0 < 200)
			{
				labelStatus.Text = @"IMVU is minimized.";
				labelStatus.ForeColor = Color.Red;
				labelStatus.Update();
				groupCapture.Enabled = false;
				_w0 = _h0 = 0;
			}
			else
			{
				labelStatus.Text = _w0 + @"x" + _h0;
				labelStatus.ForeColor = Color.Black;
				labelStatus.Update();
				groupCapture.Enabled = true;
				if (_hwnd == processes[0].MainWindowHandle)
					return;

				Inject();
				_hwnd = processes[0].MainWindowHandle;
			}
		}
	}
}