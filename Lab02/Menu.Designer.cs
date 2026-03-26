namespace Lab02
{
    partial class Menu
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
            Bai01_btn = new Button();
            Bai02_btn = new Button();
            Bai03_btn = new Button();
            Bai04_btn = new Button();
            Bai05_btn = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            SuspendLayout();
            // 
            // Bai01_btn
            // 
            Bai01_btn.Location = new Point(174, 130);
            Bai01_btn.Name = "Bai01_btn";
            Bai01_btn.Size = new Size(94, 29);
            Bai01_btn.TabIndex = 0;
            Bai01_btn.Text = "Bài 1";
            Bai01_btn.UseVisualStyleBackColor = true;
            Bai01_btn.Click += Bai01_btn_Click;
            // 
            // Bai02_btn
            // 
            Bai02_btn.Location = new Point(174, 165);
            Bai02_btn.Name = "Bai02_btn";
            Bai02_btn.Size = new Size(94, 29);
            Bai02_btn.TabIndex = 1;
            Bai02_btn.Text = "Bài 2";
            Bai02_btn.UseVisualStyleBackColor = true;
            Bai02_btn.Click += Bai02_btn_Click;
            // 
            // Bai03_btn
            // 
            Bai03_btn.Location = new Point(174, 200);
            Bai03_btn.Name = "Bai03_btn";
            Bai03_btn.Size = new Size(94, 29);
            Bai03_btn.TabIndex = 2;
            Bai03_btn.Text = "Bài 3";
            Bai03_btn.UseVisualStyleBackColor = true;
            Bai03_btn.Click += Bai03_btn_Click;
            // 
            // Bai04_btn
            // 
            Bai04_btn.Location = new Point(174, 235);
            Bai04_btn.Name = "Bai04_btn";
            Bai04_btn.Size = new Size(94, 29);
            Bai04_btn.TabIndex = 3;
            Bai04_btn.Text = "Bài 4";
            Bai04_btn.UseVisualStyleBackColor = true;
            Bai04_btn.Click += Bai04_btn_Click;
            // 
            // Bai05_btn
            // 
            Bai05_btn.Location = new Point(174, 270);
            Bai05_btn.Name = "Bai05_btn";
            Bai05_btn.Size = new Size(94, 29);
            Bai05_btn.TabIndex = 4;
            Bai05_btn.Text = "Bài 5";
            Bai05_btn.UseVisualStyleBackColor = true;
            Bai05_btn.Click += Bai05_btn_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(364, 134);
            label1.Name = "label1";
            label1.Size = new Size(104, 20);
            label1.TabIndex = 5;
            label1.Text = "Ghi và đọc file";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(364, 169);
            label2.Name = "label2";
            label2.Size = new Size(150, 20);
            label2.TabIndex = 6;
            label2.Text = "Đọc thông tin tệp .txt";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(364, 204);
            label3.Name = "label3";
            label3.Size = new Size(182, 20);
            label3.TabIndex = 7;
            label3.Text = "Ghi và đọc file (Nâng cao)";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(364, 239);
            label4.Name = "label4";
            label4.Size = new Size(252, 20);
            label4.TabIndex = 8;
            label4.Text = "Ghi và đọc file dùng BinaryFormatter";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(364, 274);
            label5.Name = "label5";
            label5.Size = new Size(106, 20);
            label5.TabIndex = 9;
            label5.Text = "Duyệt thư mục";
            // 
            // Menu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(Bai05_btn);
            Controls.Add(Bai04_btn);
            Controls.Add(Bai03_btn);
            Controls.Add(Bai02_btn);
            Controls.Add(Bai01_btn);
            Name = "Menu";
            Text = "Menu";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Bai01_btn;
        private Button Bai02_btn;
        private Button Bai03_btn;
        private Button Bai04_btn;
        private Button Bai05_btn;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
    }
}