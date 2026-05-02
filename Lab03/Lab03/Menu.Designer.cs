namespace Lab03
{
    partial class Menu
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
            btnBai1 = new Button();
            btnBai2 = new Button();
            btnBai3 = new Button();
            button4 = new Button();
            SuspendLayout();
            // 
            // btnBai1
            // 
            btnBai1.Location = new Point(202, 71);
            btnBai1.Name = "btnBai1";
            btnBai1.Size = new Size(94, 29);
            btnBai1.TabIndex = 0;
            btnBai1.Text = "Bài 01";
            btnBai1.UseVisualStyleBackColor = true;
            btnBai1.Click += btnBai1_Click;
            // 
            // btnBai2
            // 
            btnBai2.Location = new Point(202, 201);
            btnBai2.Name = "btnBai2";
            btnBai2.Size = new Size(94, 29);
            btnBai2.TabIndex = 1;
            btnBai2.Text = "Bài 02";
            btnBai2.UseVisualStyleBackColor = true;
            btnBai2.Click += btnBai2_Click;
            // 
            // btnBai3
            // 
            btnBai3.Location = new Point(453, 201);
            btnBai3.Name = "btnBai3";
            btnBai3.Size = new Size(94, 29);
            btnBai3.TabIndex = 2;
            btnBai3.Text = "Bài 03";
            btnBai3.UseVisualStyleBackColor = true;
            btnBai3.Click += btnBai3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(453, 71);
            button4.Name = "button4";
            button4.Size = new Size(94, 29);
            button4.TabIndex = 3;
            button4.Text = "button4";
            button4.UseVisualStyleBackColor = true;
            // 
            // Menu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button4);
            Controls.Add(btnBai3);
            Controls.Add(btnBai2);
            Controls.Add(btnBai1);
            Name = "Menu";
            Text = "Menu";
            ResumeLayout(false);
        }

        #endregion

        private Button btnBai1;
        private Button btnBai2;
        private Button btnBai3;
        private Button button4;
    }
}
