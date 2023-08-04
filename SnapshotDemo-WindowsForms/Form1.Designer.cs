namespace SnapshotDemo_WindowsForms
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCapture_Click = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCapture_Click
            // 
            this.btnCapture_Click.Location = new System.Drawing.Point(274, 162);
            this.btnCapture_Click.Name = "btnCapture_Click";
            this.btnCapture_Click.Size = new System.Drawing.Size(179, 79);
            this.btnCapture_Click.TabIndex = 0;
            this.btnCapture_Click.Text = "Take Screenshots";
            this.btnCapture_Click.UseVisualStyleBackColor = true;
            this.btnCapture_Click.Click += new System.EventHandler(this.btnCapture_Click_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnCapture_Click);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCapture_Click;
    }
}

