namespace TPtest
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_open = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_readPix = new System.Windows.Forms.Button();
            this.btn_changePix = new System.Windows.Forms.Button();
            this.btn_hideText = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_showText = new System.Windows.Forms.Button();
            this.inputText = new System.Windows.Forms.TextBox();
            this.btn_hintImg = new System.Windows.Forms.Button();
            this.btn_showImg = new System.Windows.Forms.Button();
            this.input_key = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_open
            // 
            this.btn_open.Location = new System.Drawing.Point(13, 13);
            this.btn_open.Name = "btn_open";
            this.btn_open.Size = new System.Drawing.Size(100, 30);
            this.btn_open.TabIndex = 0;
            this.btn_open.Text = "打开图像";
            this.btn_open.UseVisualStyleBackColor = true;
            this.btn_open.Click += new System.EventHandler(this.btn_open_Click);
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(119, 13);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(100, 30);
            this.btn_save.TabIndex = 1;
            this.btn_save.Text = "保存图像";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // btn_readPix
            // 
            this.btn_readPix.Location = new System.Drawing.Point(225, 13);
            this.btn_readPix.Name = "btn_readPix";
            this.btn_readPix.Size = new System.Drawing.Size(100, 30);
            this.btn_readPix.TabIndex = 2;
            this.btn_readPix.Text = "读取像素";
            this.btn_readPix.UseVisualStyleBackColor = true;
            this.btn_readPix.Click += new System.EventHandler(this.btn_readPix_Click);
            // 
            // btn_changePix
            // 
            this.btn_changePix.Location = new System.Drawing.Point(331, 13);
            this.btn_changePix.Name = "btn_changePix";
            this.btn_changePix.Size = new System.Drawing.Size(100, 30);
            this.btn_changePix.TabIndex = 3;
            this.btn_changePix.Text = "修改像素";
            this.btn_changePix.UseVisualStyleBackColor = true;
            this.btn_changePix.Click += new System.EventHandler(this.btn_changePix_Click);
            // 
            // btn_hideText
            // 
            this.btn_hideText.Location = new System.Drawing.Point(13, 50);
            this.btn_hideText.Name = "btn_hideText";
            this.btn_hideText.Size = new System.Drawing.Size(100, 30);
            this.btn_hideText.TabIndex = 4;
            this.btn_hideText.Text = "隐藏文本";
            this.btn_hideText.UseVisualStyleBackColor = true;
            this.btn_hideText.Click += new System.EventHandler(this.btn_hideText_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(484, 12);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(503, 767);
            this.richTextBox1.TabIndex = 5;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(13, 234);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(436, 545);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // btn_showText
            // 
            this.btn_showText.Location = new System.Drawing.Point(119, 50);
            this.btn_showText.Name = "btn_showText";
            this.btn_showText.Size = new System.Drawing.Size(100, 30);
            this.btn_showText.TabIndex = 7;
            this.btn_showText.Text = "解密文本";
            this.btn_showText.UseVisualStyleBackColor = true;
            this.btn_showText.Click += new System.EventHandler(this.btn_showText_Click);
            // 
            // inputText
            // 
            this.inputText.Location = new System.Drawing.Point(13, 132);
            this.inputText.Name = "inputText";
            this.inputText.Size = new System.Drawing.Size(436, 25);
            this.inputText.TabIndex = 8;
            this.inputText.Text = "请输入需要隐藏的文本信息";
            this.inputText.TextChanged += new System.EventHandler(this.inputText_TextChanged);
            // 
            // btn_hintImg
            // 
            this.btn_hintImg.Location = new System.Drawing.Point(225, 50);
            this.btn_hintImg.Name = "btn_hintImg";
            this.btn_hintImg.Size = new System.Drawing.Size(100, 30);
            this.btn_hintImg.TabIndex = 9;
            this.btn_hintImg.Text = "隐藏图片";
            this.btn_hintImg.UseVisualStyleBackColor = true;
            this.btn_hintImg.Click += new System.EventHandler(this.btn_hintImg_Click);
            // 
            // btn_showImg
            // 
            this.btn_showImg.Location = new System.Drawing.Point(331, 50);
            this.btn_showImg.Name = "btn_showImg";
            this.btn_showImg.Size = new System.Drawing.Size(100, 30);
            this.btn_showImg.TabIndex = 10;
            this.btn_showImg.Text = "显示图片";
            this.btn_showImg.UseVisualStyleBackColor = true;
            this.btn_showImg.Click += new System.EventHandler(this.btn_showImg_Click);
            // 
            // input_key
            // 
            this.input_key.Location = new System.Drawing.Point(259, 173);
            this.input_key.MaxLength = 1;
            this.input_key.Name = "input_key";
            this.input_key.Size = new System.Drawing.Size(190, 25);
            this.input_key.TabIndex = 11;
            this.input_key.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.input_key.TextChanged += new System.EventHandler(this.input_key_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 179);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(217, 15);
            this.label1.TabIndex = 12;
            this.label1.Text = "请输入秘钥（一个字符长度）：";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(999, 791);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.input_key);
            this.Controls.Add(this.btn_showImg);
            this.Controls.Add(this.btn_hintImg);
            this.Controls.Add(this.inputText);
            this.Controls.Add(this.btn_showText);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.btn_hideText);
            this.Controls.Add(this.btn_changePix);
            this.Controls.Add(this.btn_readPix);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.btn_open);
            this.Name = "Form1";
            this.Text = "加解密";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_open;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_readPix;
        private System.Windows.Forms.Button btn_changePix;
        private System.Windows.Forms.Button btn_hideText;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn_showText;
        private System.Windows.Forms.TextBox inputText;
        private System.Windows.Forms.Button btn_hintImg;
        private System.Windows.Forms.Button btn_showImg;
        private System.Windows.Forms.TextBox input_key;
        private System.Windows.Forms.Label label1;
    }
}

