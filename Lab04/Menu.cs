using Lab4;
using System.Security.Cryptography;

namespace Lab04
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bai01 frm = new Bai01();
            frm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Bai02 frm = new Bai02();
            frm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Bai03 frm = new Bai03();
            frm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Bai04 frm = new Bai04();
            frm.Show();
        }
    }
}
