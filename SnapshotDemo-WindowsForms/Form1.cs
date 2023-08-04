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
            if (!isRecording)
            {
                isRecording = true;
                btnStartRecording.Enabled = false;
                btnStopRecording.Enabled = true;

                recordingThread = new Thread(StartRecording);
                recordingThread.Start();
            }

        }

        private void btnStopRecording_Click(object sender, EventArgs e)
        {
            if (isRecording)
            {
                isRecording = false;
                btnStopRecording.Enabled = false;
                btnStartRecording.Enabled = true;
            }

        }

        private void StartRecording()
        {
            try
            {
                Rectangle appBounds = this.Bounds;
                Size size = appBounds.Size;
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string fileName = "screencast_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".avi";
                string filePath = System.IO.Path.Combine(desktopPath, fileName);

                // VideoCapture cihazını oluşturun.
                var captureDevice = new Accord.Video.DirectShow.ScreenCaptureStream(size.Width, size.Height);

                // Video kayıt ayarlarını yapılandırın.
                var writer = new VideoFileWriter();
                writer.Width = size.Width;
                writer.Height = size.Height;
                writer.VideoCodec = Accord.Video.FFMPEG.VideoCodec.MPEG4;
                writer.VideoOptions.BitRate = 5000000;
                writer.VideoOptions.FramesPerSecond = 30;

                // Video dosyasını oluşturun.
                writer.Open(filePath, size.Width, size.Height);

                while (isRecording)
                {
                    // Ekran görüntüsü alın.
                    Bitmap screenshot = new Bitmap(size.Width, size.Height);
                    using (Graphics graphics = Graphics.FromImage(screenshot))
                    {
                        graphics.CopyFromScreen(appBounds.Location, new Point(0, 0), size);
                    }

                    // Ekran görüntüsünü video dosyasına ekleyin.
                    writer.WriteVideoFrame(screenshot);

                    // Belirli bir zaman aralığıyla kayıt yapın (eğer gerekliyse).
                    // Thread.Sleep(33); // 33ms => 30 FPS, 1000ms / 30 FPS ≈ 33ms
                }

                // Video dosyasını kapatın.
                writer.Close();

                // Kullanıcıya bildirim verin.
                MessageBox.Show("Ekran kaydı başarıyla tamamlandı:\n" + filePath, "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // Hata durumunda kullanıcıya uyarı verin.
                MessageBox.Show("Bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
