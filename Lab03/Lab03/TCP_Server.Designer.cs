namespace Lab03
{
    partial class TCP_Server
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
            btnListen = new Button();
            txtPort = new TextBox();
            label1 = new Label();
            lvLog = new ListView();
            columnHeader1 = new ColumnHeader();
            SuspendLayout();
            // 
            // btnListen
            // 
            btnListen.Location = new Point(606, 49);
            btnListen.Name = "btnListen";
            btnListen.Size = new Size(94, 29);
            btnListen.TabIndex = 0;
            btnListen.Text = "Listen";
            btnListen.UseVisualStyleBackColor = true;
            btnListen.Click += btnListen_Click;
            // 
            // txtPort
            // 
            txtPort.Location = new Point(107, 51);
            txtPort.Name = "txtPort";
            txtPort.PlaceholderText = "Nhập Port";
            txtPort.Size = new Size(440, 27);
            txtPort.TabIndex = 1;
            txtPort.TextChanged += txtPort_TextChanged_1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(66, 54);
            label1.Name = "label1";
            label1.Size = new Size(35, 20);
            label1.TabIndex = 2;
            label1.Text = "Port";
            // 
            // lvLog
            // 
            lvLog.Columns.AddRange(new ColumnHeader[] { columnHeader1 });
            lvLog.Location = new Point(107, 95);
            lvLog.Name = "lvLog";
            lvLog.Size = new Size(593, 320);
            lvLog.TabIndex = 3;
            lvLog.UseCompatibleStateImageBehavior = false;
            lvLog.View = View.Details;
            lvLog.SelectedIndexChanged += lvLog_SelectedIndexChanged;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Message";
            columnHeader1.Width = 500;
            // 
            // TCP_Server
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lvLog);
            Controls.Add(label1);
            Controls.Add(txtPort);
            Controls.Add(btnListen);
            Name = "TCP_Server";
            Text = "TCP_Server";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnListen;
        private TextBox txtPort;
        private Label label1;
        private ListView lvLog;
        private ColumnHeader columnHeader1;
    }
}