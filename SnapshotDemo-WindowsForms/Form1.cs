using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Threading;
using Accord.Video.FFMPEG;
using System.Diagnostics;
using System.IO;
using ScreenRecorderLib;


namespace SnapshotDemo_WindowsForms
{
    public partial class Form1 : Form
    {
        private static Bitmap bmpScreenshot;
        private static Graphics gfxScreenshot;
        private bool isRecording = false;
        private Thread recordingThread;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnCapture_Click_Click(object sender, EventArgs e)
        {
            try
            {
                // Uygulama penceresinin boyutları ve konumunu alın.
                Rectangle appBounds = this.Bounds;

                // Uygulama penceresinin boyutlarında bir Bitmap nesnesi oluşturun.
                Bitmap screenshot = new Bitmap(appBounds.Width, appBounds.Height);

                // Graphics nesnesi oluşturarak uygulama penceresinin ekran görüntüsünü yakalayın.
                using (Graphics graphics = Graphics.FromImage(screenshot))
                {
                    graphics.CopyFromScreen(appBounds.Location, new Point(0, 0), appBounds.Size);
                }

                // Ekran görüntüsünü kaydetmek için dosya yolunu alın (örnek olarak masaüstüne kaydedelim).
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string fileName = "screenshot_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".png";
                string filePath = System.IO.Path.Combine(desktopPath, fileName);

                // Ekran görüntüsünü dosyaya kaydedin.
                screenshot.Save(filePath, System.Drawing.Imaging.ImageFormat.Png);

                // Kullanıcıya bildirim verin.
                MessageBox.Show("Uygulama ekranı başarıyla kaydedildi:\n" + filePath, "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // Hata durumunda kullanıcıya uyarı verin.
                MessageBox.Show("Bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnStartRecording_Click(object sender, EventArgs e)
        {
            /*if (File.Exists(@"D:\ffmpeg\test.mp4"))
            {
                File.Delete(@"D:\ffmpeg\test.mp4");
            }*/

            //StartRecording("test.mp4", 24);

        }

        private void btnStopRecording_Click(object sender, EventArgs e)
        {
            //Close();

        }
        Process process;
        /*private void StartRecording(string FileName, int Framerate)
        {
            process = new System.Diagnostics.Process();
            process.StartInfo.FileName = @"D:\ffmpeg\bin\ffmpeg.exe";
            process.EnableRaisingEvents = false;
            process.StartInfo.WorkingDirectory = @"D:\ffmpeg";
            process.StartInfo.Arguments = @"-f gdigrab -framerate" + Framerate + "-i desktop -preset ultrafast -pix_fmt yuv420p" + FileName;
            process.Start();
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = false;
        }*/

        /* public void Close()
         {
             process.Close();
         }*/

        Recorder _rec;
        void CreateRecording()
        {
            string videoPath = Path.Combine(Path.GetTempPath(), "test.mp4");
            _rec = Recorder.CreateRecorder();
            _rec.OnRecordingComplete += Rec_OnRecordingComplete;
            _rec.OnRecordingFailed += Rec_OnRecordingFailed;
            _rec.OnStatusChanged += Rec_OnStatusChanged;
            //Record to a file
            string videoPath = Path.Combine(Path.GetTempPath(), "test.mp4");
            _rec.Record(videoPath);
        }
        void EndRecording()
        {
            _rec.Stop();
        }
        private void Rec_OnRecordingComplete(object sender, RecordingCompleteEventArgs e)
        {
            //Get the file path if recorded to a file
            string path = e.FilePath;
        }
        private void Rec_OnRecordingFailed(object sender, RecordingFailedEventArgs e)
        {
            string error = e.Error;
        }
        private void Rec_OnStatusChanged(object sender, RecordingStatusEventArgs e)
        {
            RecorderStatus status = e.Status;
        }
    }
}
