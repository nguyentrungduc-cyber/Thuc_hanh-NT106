using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab02
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void Bai01_btn_Click(object sender, EventArgs e)
        {
            Bai01 form = new Bai01();
            form.Show();
        }

        private void Bai02_btn_Click(object sender, EventArgs e)
        {
            Bai02 form = new Bai02();
            form.Show();
        }

        private void Bai03_btn_Click(object sender, EventArgs e)
        {
            Bai03 form = new Bai03();
            form.Show();
        }

        private void Bai04_btn_Click(object sender, EventArgs e)
        {
            Bai04 form = new Bai04();
            form.Show();
        }

        private void Bai05_btn_Click(object sender, EventArgs e)
        {
            Bai05 form = new Bai05();
            form.Show();
        }
    }
}
