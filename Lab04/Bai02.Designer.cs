namespace Lab04
{
    partial class Bai02
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
            btnPost = new Button();
            txtData = new TextBox();
            rtbResponse = new RichTextBox();
            SuspendLayout();
            // 
            // txtURL
            // 
            txtURL.Location = new Point(12, 22);
            txtURL.Name = "txtURL";
            txtURL.Size = new Size(611, 27);
            txtURL.TabIndex = 0;
            // 
            // btnPost
            // 
            btnPost.Location = new Point(694, 22);
            btnPost.Name = "btnPost";
            btnPost.Size = new Size(94, 29);
            btnPost.TabIndex = 1;
            btnPost.Text = "POST";
            btnPost.UseVisualStyleBackColor = true;
            btnPost.Click += btnPost_Click;
            // 
            // txtData
            // 
            txtData.Location = new Point(12, 72);
            txtData.Name = "txtData";
            txtData.Size = new Size(611, 27);
            txtData.TabIndex = 2;
            // 
            // rtbResponse
            // 
            rtbResponse.Location = new Point(12, 105);
            rtbResponse.Name = "rtbResponse";
            rtbResponse.Size = new Size(776, 333);
            rtbResponse.TabIndex = 3;
            rtbResponse.Text = "";
            // 
            // Bai02
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(rtbResponse);
            Controls.Add(txtData);
            Controls.Add(btnPost);
            Controls.Add(txtURL);
            Name = "Bai02";
            Text = "Bai02";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtURL;
        private Button btnPost;
        private TextBox txtData;
        private RichTextBox rtbResponse;
    }
}