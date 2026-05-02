namespace Lab03
{
    partial class frmBai3
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
            btnTCPServer = new Button();
            btnTCPClient = new Button();
            SuspendLayout();
            // 
            // btnTCPServer
            // 
            btnTCPServer.Location = new Point(109, 47);
            btnTCPServer.Name = "btnTCPServer";
            btnTCPServer.Size = new Size(360, 38);
            btnTCPServer.TabIndex = 0;
            btnTCPServer.Text = "Open TCP Server";
            btnTCPServer.UseVisualStyleBackColor = true;
            btnTCPServer.Click += btnTCPServer_Click;
            // 
            // btnTCPClient
            // 
            btnTCPClient.Location = new Point(109, 141);
            btnTCPClient.Name = "btnTCPClient";
            btnTCPClient.Size = new Size(360, 38);
            btnTCPClient.TabIndex = 1;
            btnTCPClient.Text = "Open TCP Client";
            btnTCPClient.UseVisualStyleBackColor = true;
            btnTCPClient.Click += btnTCPClient_Click;
            // 
            // frmBai3
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(578, 226);
            Controls.Add(btnTCPClient);
            Controls.Add(btnTCPServer);
            Name = "frmBai3";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Bai03";
            ResumeLayout(false);
        }

        #endregion

        private Button btnTCPServer;
        private Button btnTCPClient;
    }
}