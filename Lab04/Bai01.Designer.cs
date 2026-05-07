namespace Lab04
{
    partial class Bai01
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
            txtURL = new TextBox();
            btnGet = new Button();
            rtbSource = new RichTextBox();
            SuspendLayout();
            // 
            // txtURL
            // 
            txtURL.Location = new Point(23, 40);
            txtURL.Name = "txtURL";
            txtURL.Size = new Size(533, 27);
            txtURL.TabIndex = 0;
            // 
            // btnGet
            // 
            btnGet.Location = new Point(694, 39);
            btnGet.Name = "btnGet";
            btnGet.Size = new Size(94, 29);
            btnGet.TabIndex = 1;
            btnGet.Text = "GET";
            btnGet.UseVisualStyleBackColor = true;
            btnGet.Click += btnGet_Click;
            // 
            // rtbSource
            // 
            rtbSource.Location = new Point(23, 83);
            rtbSource.Name = "rtbSource";
            rtbSource.Size = new Size(765, 355);
            rtbSource.TabIndex = 2;
            rtbSource.Text = "";
            // 
            // Bai01
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(rtbSource);
            Controls.Add(btnGet);
            Controls.Add(txtURL);
            Name = "Bai01";
            Text = "Bai01";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtURL;
        private Button btnGet;
        private RichTextBox rtbSource;
    }
}