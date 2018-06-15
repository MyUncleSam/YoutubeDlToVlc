using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace YoutubeDlToVlc
{
	public partial class Form1 : Form
	{
		private readonly DirectoryInfo MyPath = new DirectoryInfo(Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath));
		private DirectoryInfo YoutubeDlPath = null;
		private FileInfo YoutubeDlFile = null;
		private FileInfo VlcFile = null;

		private List<string> PossibleVlcLocations = new List<string>()
		{
			@"C:\Program Files\VideoLAN\VLC\vlc.exe",
			@"C:\Program Files (x86)\VideoLAN\VLC\vlc.exe"
		};

		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Shown(object sender, EventArgs e)
		{
			YoutubeDlPath = new DirectoryInfo(System.IO.Path.Combine(MyPath.FullName, "youtube-dl"));
			YoutubeDlFile = new FileInfo(string.Format(@"{0}/youtube-dl.exe", YoutubeDlPath.FullName));

			if(!YoutubeDlPath.Exists)
			{
				YoutubeDlPath.Create();
			}

			if(!YoutubeDlFile.Exists || YoutubeDlFile.Length <= 0)
			{
				ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
				WebClient wc = new WebClient();
				wc.DownloadFile("https://yt-dl.org/downloads/2018.06.14/youtube-dl.exe", YoutubeDlFile.FullName);
			}

			// always start update procedure at next step
			using (Process p = new Process())
			{
				ProcessStartInfo psi = new ProcessStartInfo(YoutubeDlFile.FullName, "--update");
				psi.WorkingDirectory = YoutubeDlPath.FullName;
				p.StartInfo = psi;
				p.Start();
				p.WaitForExit();
			}

			// try get vlc path
			if(!string.IsNullOrWhiteSpace(Properties.Settings.Default.VlcPath))
			{
				VlcFile = new FileInfo(Properties.Settings.Default.VlcPath);
				if(!VlcFile.Exists)
				{
					VlcFile = null;
				}
			}

			if(VlcFile == null)
			{
				foreach (string posPath in PossibleVlcLocations)
				{
					if(File.Exists(posPath))
					{
						VlcFile = new FileInfo(posPath);
						break;
					}
				}
			}

			if(VlcFile != null)
			{
				fcVlc.SelectedFile = VlcFile.FullName;
			}

			tbStream.Text = Properties.Settings.Default.LastStream;

			// last but not least - enable the form
			this.Enabled = true;
		}

		private void btnStartStream_Click(object sender, EventArgs e)
		{
			try
			{
				this.Enabled = false;

				if (VlcFile == null)
				{
					MessageBox.Show("VLC not found, please provide it!!!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
					return;
				}

				if (string.IsNullOrWhiteSpace(tbStream.Text))
				{
					MessageBox.Show("Please provide a valid stream page!!!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
					return;
				}

				FileInfo ffmpegFile = new FileInfo(string.Format("{0}/ffmpeg.exe", Path.Combine(MyPath.FullName, "ffmpeg", "bin")));
				if(!ffmpegFile.Exists)
				{
					MessageBox.Show("FFMPEG not found - please download the package and put it into the 'ffmpeg' folder (see readme in it!)!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
					Process.Start(Path.Combine(MyPath.FullName, "ffmpeg"));
					Process.Start("https://ffmpeg.zeranoe.com/builds/");
					return;
				}

				FileInfo batPath = new FileInfo(string.Format(@"{0}/{1}.bat", YoutubeDlPath.FullName, Guid.NewGuid().ToString("N")));
				File.WriteAllText(batPath.FullName, string.Format("\"{0}\" \"{1}\" --ffmpeg-location \"{2}\" -o -| \"{3}\" -", YoutubeDlFile.FullName, tbStream.Text, ffmpegFile.FullName, VlcFile.FullName));

				Process run = new Process();
				run.StartInfo.WorkingDirectory = YoutubeDlPath.FullName;
				run.StartInfo.FileName = batPath.FullName;
				run.Start();
			}
			catch (Exception ex)
			{
				MessageBox.Show(string.Format("Error:{0}{1}", Environment.NewLine, ex.ToString()), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
			}
			finally
			{
				this.Enabled = true;
			}
		}

		private void Cmd_ErrorDataReceived(object sender, DataReceivedEventArgs e)
		{
			Console.WriteLine(e.Data);
		}

		private void Cmd_OutputDataReceived(object sender, DataReceivedEventArgs e)
		{
			Console.WriteLine(e.Data);
		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			Properties.Settings.Default.LastStream = tbStream.Text;
			Properties.Settings.Default.VlcPath = fcVlc.SelectedFile;
			Properties.Settings.Default.Save();

			foreach(FileInfo f in YoutubeDlPath.GetFiles("*.bat", SearchOption.TopDirectoryOnly))
			{
				try
				{
					f.Delete();
				}
				catch { }
			}
		}
	}
}
