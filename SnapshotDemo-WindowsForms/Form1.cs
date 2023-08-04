using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace SnapshotDemo_WindowsForms
{
    public partial class Form1 : Form
    {
        private static Bitmap bmpScreenshot;
        private static Graphics gfxScreenshot;
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
    }
}
