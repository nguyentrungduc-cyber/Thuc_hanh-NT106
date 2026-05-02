namespace Lab03
{
    partial class TCP_Client
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
            btnSend = new Button();
            txtSend = new TextBox();
            txtIP = new TextBox();
            txtPort = new TextBox();
            btnConnect = new Button();
            rtbLog = new RichTextBox();
            SuspendLayout();
            // 
            // btnSend
            // 
            btnSend.Enabled = false;
            btnSend.Location = new Point(508, 243);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(120, 37);
            btnSend.TabIndex = 0;
            btnSend.Text = "Send Mesages";
            btnSend.UseVisualStyleBackColor = true;
            btnSend.Click += btnSend_Click;
            // 
            // txtSend
            // 
            txtSend.Location = new Point(51, 253);
            txtSend.Name = "txtSend";
            txtSend.Size = new Size(354, 27);
            txtSend.TabIndex = 1;
            txtSend.TextChanged += txtSend_TextChanged;
            // 
            // txtIP
            // 
            txtIP.Location = new Point(51, 51);
            txtIP.Name = "txtIP";
            txtIP.PlaceholderText = "Nhập IP";
            txtIP.Size = new Size(125, 27);
            txtIP.TabIndex = 2;
            // 
            // txtPort
            // 
            txtPort.Location = new Point(270, 51);
            txtPort.Name = "txtPort";
            txtPort.PlaceholderText = "Nhập Port";
            txtPort.Size = new Size(125, 27);
            txtPort.TabIndex = 3;
            // 
            // btnConnect
            // 
            btnConnect.Location = new Point(508, 51);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(141, 29);
            btnConnect.TabIndex = 4;
            btnConnect.Text = "Connect";
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += btnConnect_Click;
            // 
            // rtbLog
            // 
            rtbLog.Location = new Point(103, 105);
            rtbLog.Name = "rtbLog";
            rtbLog.ReadOnly = true;
            rtbLog.Size = new Size(494, 111);
            rtbLog.TabIndex = 5;
            rtbLog.Text = "";
            rtbLog.TextChanged += rtbLog_TextChanged;
            // 
            // TCP_Client
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(701, 354);
            Controls.Add(rtbLog);
            Controls.Add(btnConnect);
            Controls.Add(txtPort);
            Controls.Add(txtIP);
            Controls.Add(txtSend);
            Controls.Add(btnSend);
            Name = "TCP_Client";
            Text = "TCP_Client";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSend;
        private TextBox txtSend;
        private TextBox txtIP;
        private TextBox txtPort;
        private Button btnConnect;
        private RichTextBox rtbLog;
    }
}