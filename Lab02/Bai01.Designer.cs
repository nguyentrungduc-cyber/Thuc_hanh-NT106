namespace Lab02
{
    partial class FrmBai01
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnReadFile = new Button();
            btnWriteFile = new Button();
            txtFileContent = new TextBox();
            SuspendLayout();
            // 
            // btnReadFile
            // 
            btnReadFile.BackColor = Color.FromArgb(192, 255, 255);
            btnReadFile.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnReadFile.ForeColor = SystemColors.ActiveCaptionText;
            btnReadFile.Location = new Point(29, 26);
            btnReadFile.Name = "btnReadFile";
            btnReadFile.Size = new Size(166, 73);
            btnReadFile.TabIndex = 0;
            btnReadFile.Text = "ĐỌC FILE";
            btnReadFile.UseVisualStyleBackColor = false;
            btnReadFile.Click += btnReadFile_Click;
            // 
            // btnWriteFile
            // 
            btnWriteFile.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnWriteFile.Location = new Point(31, 122);
            btnWriteFile.Name = "btnWriteFile";
            btnWriteFile.Size = new Size(166, 73);
            btnWriteFile.TabIndex = 1;
            btnWriteFile.Text = "GHI FILE";
            btnWriteFile.UseVisualStyleBackColor = true;
            btnWriteFile.Click += btnWriteFile_Click;
            // 
            // txtFileContent
            // 
            txtFileContent.Location = new Point(249, 26);
            txtFileContent.Multiline = true;
            txtFileContent.Name = "txtFileContent";
            txtFileContent.Size = new Size(549, 183);
            txtFileContent.TabIndex = 3;
            // 
            // FrmBai01
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(810, 225);
            Controls.Add(txtFileContent);
            Controls.Add(btnWriteFile);
            Controls.Add(btnReadFile);
            Name = "FrmBai01";
            Text = "Bai01";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnReadFile;
        private Button btnWriteFile;
        private TextBox txtFileContent;
    }
}
