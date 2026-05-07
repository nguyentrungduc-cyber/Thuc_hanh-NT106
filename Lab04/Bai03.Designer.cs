namespace Lab4
{
    partial class Bai03
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            rtbHTML = new RichTextBox();
            txtURL = new TextBox();
            btnDownload = new Button();
            txtPath = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(292, 9);
            label1.Name = "label1";
            label1.Size = new Size(96, 31);
            label1.TabIndex = 2;
            label1.Text = "Bài 03";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // rtbHTML
            // 
            rtbHTML.Location = new Point(39, 153);
            rtbHTML.Name = "rtbHTML";
            rtbHTML.ReadOnly = true;
            rtbHTML.Size = new Size(628, 386);
            rtbHTML.TabIndex = 7;
            rtbHTML.Text = "";
            // 
            // txtURL
            // 
            txtURL.Location = new Point(39, 74);
            txtURL.Name = "txtURL";
            txtURL.Size = new Size(507, 27);
            txtURL.TabIndex = 6;
            txtURL.Text = "https://uit.edu.vn/";
            // 
            // btnDownload
            // 
            btnDownload.Location = new Point(562, 74);
            btnDownload.Name = "btnDownload";
            btnDownload.Size = new Size(106, 58);
            btnDownload.TabIndex = 5;
            btnDownload.Text = "Download";
            btnDownload.UseVisualStyleBackColor = true;
            btnDownload.Click += btnDownload_Click;
            // 
            // txtPath
            // 
            txtPath.Location = new Point(39, 106);
            txtPath.Name = "txtPath";
            txtPath.Size = new Size(507, 27);
            txtPath.TabIndex = 8;
            txtPath.Text = "C:/Users/ADMIN/Downloads/uit.html";
            // 
            // Bai03
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(711, 551);
            Controls.Add(txtPath);
            Controls.Add(rtbHTML);
            Controls.Add(txtURL);
            Controls.Add(btnDownload);
            Controls.Add(label1);
            Name = "Bai03";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Bai03";
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox rtbHTML;
        private System.Windows.Forms.TextBox txtURL;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.TextBox txtPath;
    }
}