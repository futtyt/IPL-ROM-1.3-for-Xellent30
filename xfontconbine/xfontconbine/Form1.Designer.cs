
namespace xfontconvine
{
    partial class MainForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.fontRomPath = new System.Windows.Forms.TextBox();
            this.ipl13RomPath = new System.Windows.Forms.TextBox();
            this.conbine = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.fontImage = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // fontRomPath
            // 
            this.fontRomPath.AllowDrop = true;
            this.fontRomPath.Location = new System.Drawing.Point(172, 13);
            this.fontRomPath.Name = "fontRomPath";
            this.fontRomPath.Size = new System.Drawing.Size(259, 25);
            this.fontRomPath.TabIndex = 1;
            this.fontRomPath.DragDrop += new System.Windows.Forms.DragEventHandler(this.fontRomPath_DragDrop);
            this.fontRomPath.DragEnter += new System.Windows.Forms.DragEventHandler(this.fontRomPath_DragEnter);
            // 
            // ipl13RomPath
            // 
            this.ipl13RomPath.AllowDrop = true;
            this.ipl13RomPath.Location = new System.Drawing.Point(172, 45);
            this.ipl13RomPath.Name = "ipl13RomPath";
            this.ipl13RomPath.Size = new System.Drawing.Size(259, 25);
            this.ipl13RomPath.TabIndex = 3;
            this.ipl13RomPath.DragDrop += new System.Windows.Forms.DragEventHandler(this.ipl13RomPath_DragDrop);
            this.ipl13RomPath.DragEnter += new System.Windows.Forms.DragEventHandler(this.ipl13RomPath_DragEnter);
            // 
            // conbine
            // 
            this.conbine.Location = new System.Drawing.Point(495, 43);
            this.conbine.Name = "conbine";
            this.conbine.Size = new System.Drawing.Size(75, 29);
            this.conbine.TabIndex = 4;
            this.conbine.Text = "合体";
            this.conbine.UseVisualStyleBackColor = true;
            this.conbine.Click += new System.EventHandler(this.conbine_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.fontRomPath);
            this.panel1.Controls.Add(this.ipl13RomPath);
            this.panel1.Controls.Add(this.conbine);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(598, 88);
            this.panel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "IPLROM30Xel.DAT";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "IPLROM.DAT";
            // 
            // fontImage
            // 
            this.fontImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fontImage.Font = new System.Drawing.Font("ＭＳ ゴシック", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.fontImage.Location = new System.Drawing.Point(0, 88);
            this.fontImage.Multiline = true;
            this.fontImage.Name = "fontImage";
            this.fontImage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.fontImage.Size = new System.Drawing.Size(598, 171);
            this.fontImage.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(598, 259);
            this.Controls.Add(this.fontImage);
            this.Controls.Add(this.panel1);
            this.Name = "MainForm";
            this.Text = "xfontconbine";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox fontRomPath;
        private System.Windows.Forms.TextBox ipl13RomPath;
        private System.Windows.Forms.Button conbine;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox fontImage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}

