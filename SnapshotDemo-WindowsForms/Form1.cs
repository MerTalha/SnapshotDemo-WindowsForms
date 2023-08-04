using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using System.IO;
using VisioForge.Types.OutputFormat;

namespace SnapshotDemo_WindowsForms
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        // Button click event to capture the application window as a screenshot
        private void btnCapture_Click_Click(object sender, EventArgs e)
        {
            try
            {
                string folderPath = @"C:\snapshots";
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
                string folderPath1 = @"C:\snapshots\Screenshots";
                if (!Directory.Exists(folderPath1))
                {
                    Directory.CreateDirectory(folderPath1);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                // Get the application window's bounds.
                Rectangle appBounds = this.Bounds;

                // Create a Bitmap object with the size of the application window.
                Bitmap screenshot = new Bitmap(appBounds.Width, appBounds.Height);

                // Capture the screenshot of the application window using a Graphics object.
                using (Graphics graphics = Graphics.FromImage(screenshot))
                {
                    graphics.CopyFromScreen(appBounds.Location, new Point(0, 0), appBounds.Size);
                }

                // Get the file path to save the screenshot (let's save it on the desktop for example).
                string desktopPath = @"C:\snapshots\Screenshots";
                string fileName = "screenshot_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".png";
                string filePath = System.IO.Path.Combine(desktopPath, fileName);

                // Save the screenshot to the file.
                screenshot.Save(filePath, System.Drawing.Imaging.ImageFormat.Png);

                // Notify the user.
                MessageBox.Show("Application screen was successfully saved:\n" + filePath, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // Show a warning message in case of an error.
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Button click event to start video recording of the screen
        private async void btnStartRecording_Click(object sender, EventArgs e)
        {
            try
            {
                string folderPath = @"C:\snapshots";
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
                string folderPath1 = @"C:\snapshots\Video_Records";
                if (!Directory.Exists(folderPath1))
                {
                    Directory.CreateDirectory(folderPath1);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            videoCapture1.Screen_Capture_Source = new VisioForge.Types.Sources.ScreenCaptureSourceSettings() { FullScreen = true };

            videoCapture1.Audio_PlayAudio = videoCapture1.Audio_RecordAudio = false;


            videoCapture1.Output_Format = new VFMP4HWOutput();
            videoCapture1.Output_Filename = @"C:\snapshots\Video_Records" + "\\output " + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".mp4";

            videoCapture1.Mode = VisioForge.Types.VFVideoCaptureMode.ScreenCapture;

            await videoCapture1.StartAsync();
        }

        // Button click event to stop video recording
        private async void btnStopRecording_Click(object sender, EventArgs e)
        {
            await videoCapture1.StopAsync();
        }

        // Button click event to open the folder where snapshots and videos are saved
        private void btnOpenFolder_Click(object sender, EventArgs e)
        {
            try
            {
                string folderPath = @"C:\snapshots";
                if (Directory.Exists(folderPath))
                {
                    Process.Start(folderPath);
                }
                else
                {
                    MessageBox.Show("Folder not found: " + folderPath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
