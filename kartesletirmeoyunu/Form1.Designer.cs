namespace kartesletirmeoyunu
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.errorProviderkadi = new System.Windows.Forms.ErrorProvider(this.components);
            this.kAdiTextbox = new System.Windows.Forms.TextBox();
            this.kartboyutCmb = new System.Windows.Forms.ComboBox();
            this.temaCmb = new System.Windows.Forms.ComboBox();
            this.kullaniciAdiLbl = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cikisBtn = new System.Windows.Forms.Button();
            this.girisBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderkadi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // errorProviderkadi
            // 
            this.errorProviderkadi.ContainerControl = this;
            // 
            // kAdiTextbox
            // 
            this.kAdiTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.kAdiTextbox.Location = new System.Drawing.Point(91, 176);
            this.kAdiTextbox.MaxLength = 12;
            this.kAdiTextbox.Multiline = true;
            this.kAdiTextbox.Name = "kAdiTextbox";
            this.kAdiTextbox.Size = new System.Drawing.Size(334, 58);
            this.kAdiTextbox.TabIndex = 6;
            this.kAdiTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // kartboyutCmb
            // 
            this.kartboyutCmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.kartboyutCmb.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.kartboyutCmb.ForeColor = System.Drawing.Color.DarkGreen;
            this.kartboyutCmb.FormattingEnabled = true;
            this.kartboyutCmb.Items.AddRange(new object[] {
            "2x4",
            "2x5",
            "3x4",
            "4x4",
            "4x5"});
            this.kartboyutCmb.Location = new System.Drawing.Point(93, 322);
            this.kartboyutCmb.Name = "kartboyutCmb";
            this.kartboyutCmb.Size = new System.Drawing.Size(121, 34);
            this.kartboyutCmb.TabIndex = 9;
            // 
            // temaCmb
            // 
            this.temaCmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.temaCmb.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.temaCmb.ForeColor = System.Drawing.Color.DarkGreen;
            this.temaCmb.FormattingEnabled = true;
            this.temaCmb.Items.AddRange(new object[] {
            "Hayvanlar",
            "Meslekler",
            "Nesneler",
            "Renkler",
            "Emojiler"});
            this.temaCmb.Location = new System.Drawing.Point(273, 322);
            this.temaCmb.Name = "temaCmb";
            this.temaCmb.Size = new System.Drawing.Size(154, 34);
            this.temaCmb.TabIndex = 10;
            // 
            // kullaniciAdiLbl
            // 
            this.kullaniciAdiLbl.AutoSize = true;
            this.kullaniciAdiLbl.BackColor = System.Drawing.Color.Transparent;
            this.kullaniciAdiLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.kullaniciAdiLbl.ForeColor = System.Drawing.Color.DarkGreen;
            this.kullaniciAdiLbl.Location = new System.Drawing.Point(299, 273);
            this.kullaniciAdiLbl.Name = "kullaniciAdiLbl";
            this.kullaniciAdiLbl.Size = new System.Drawing.Size(97, 32);
            this.kullaniciAdiLbl.TabIndex = 46;
            this.kullaniciAdiLbl.Text = "TEMA";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.ForeColor = System.Drawing.Color.DarkGreen;
            this.label4.Location = new System.Drawing.Point(94, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(331, 32);
            this.label4.TabIndex = 47;
            this.label4.Text = "Kullanıcı Adınızı Giriniz\r\n";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.ForeColor = System.Drawing.Color.DarkGreen;
            this.label5.Location = new System.Drawing.Point(96, 273);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 32);
            this.label5.TabIndex = 48;
            this.label5.Text = "BOYUT";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(27, 28);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(463, 95);
            this.pictureBox1.TabIndex = 49;
            this.pictureBox1.TabStop = false;
            // 
            // cikisBtn
            // 
            this.cikisBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cikisBtn.BackgroundImage")));
            this.cikisBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cikisBtn.Location = new System.Drawing.Point(305, 397);
            this.cikisBtn.Name = "cikisBtn";
            this.cikisBtn.Size = new System.Drawing.Size(120, 120);
            this.cikisBtn.TabIndex = 8;
            this.cikisBtn.UseVisualStyleBackColor = true;
            this.cikisBtn.Click += new System.EventHandler(this.cikisBtn_Click);
            // 
            // girisBtn
            // 
            this.girisBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("girisBtn.BackgroundImage")));
            this.girisBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.girisBtn.Location = new System.Drawing.Point(91, 397);
            this.girisBtn.Name = "girisBtn";
            this.girisBtn.Size = new System.Drawing.Size(120, 120);
            this.girisBtn.TabIndex = 7;
            this.girisBtn.UseVisualStyleBackColor = true;
            this.girisBtn.Click += new System.EventHandler(this.girisBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(520, 557);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.kullaniciAdiLbl);
            this.Controls.Add(this.temaCmb);
            this.Controls.Add(this.kartboyutCmb);
            this.Controls.Add(this.cikisBtn);
            this.Controls.Add(this.girisBtn);
            this.Controls.Add(this.kAdiTextbox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KART EŞLEŞTİRME OYUNU ↬ by EFECAN DEMİR";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderkadi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ErrorProvider errorProviderkadi;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label kullaniciAdiLbl;
        private System.Windows.Forms.ComboBox temaCmb;
        private System.Windows.Forms.ComboBox kartboyutCmb;
        private System.Windows.Forms.Button cikisBtn;
        private System.Windows.Forms.Button girisBtn;
        private System.Windows.Forms.TextBox kAdiTextbox;
    }
}

