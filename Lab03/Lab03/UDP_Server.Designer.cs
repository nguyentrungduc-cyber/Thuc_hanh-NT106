namespace Lab03
{
    partial class UDP_Server
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
            txtPort = new TextBox();
            label1 = new Label();
            btnListen = new Button();
            label2 = new Label();
            lvMessages = new ListView();
            Messages = new ColumnHeader();
            SuspendLayout();
            // 
            // txtPort
            // 
            txtPort.Location = new Point(143, 42);
            txtPort.Name = "txtPort";
            txtPort.Size = new Size(125, 27);
            txtPort.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(70, 45);
            label1.Name = "label1";
            label1.Size = new Size(35, 20);
            label1.TabIndex = 1;
            label1.Text = "Port";
            // 
            // btnListen
            // 
            btnListen.Location = new Point(534, 45);
            btnListen.Name = "btnListen";
            btnListen.Size = new Size(94, 29);
            btnListen.TabIndex = 2;
            btnListen.Text = "Listen";
            btnListen.UseVisualStyleBackColor = true;
            btnListen.Click += btnListen_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(70, 101);
            label2.Name = "label2";
            label2.Size = new Size(137, 20);
            label2.TabIndex = 3;
            label2.Text = "Received messages";
            // 
            // lvMessages
            // 
            lvMessages.Columns.AddRange(new ColumnHeader[] { Messages });
            lvMessages.Location = new Point(70, 124);
            lvMessages.Name = "lvMessages";
            lvMessages.Size = new Size(558, 291);
            lvMessages.TabIndex = 4;
            lvMessages.UseCompatibleStateImageBehavior = false;
            lvMessages.View = View.Details;
            // 
            // Messages
            // 
            Messages.Text = "Messages:";
            Messages.Width = 400;
            // 
            // UDP_Server
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lvMessages);
            Controls.Add(label2);
            Controls.Add(btnListen);
            Controls.Add(label1);
            Controls.Add(txtPort);
            Name = "UDP_Server";
            Text = "UDP_Server";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtPort;
        private Label label1;
        private Button btnListen;
        private Label label2;
        private ListView lvMessages;
        private ColumnHeader Messages;
    }
}