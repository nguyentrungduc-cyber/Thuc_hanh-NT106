using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab03
{
    public partial class frmBai3 : Form
    {
        public frmBai3()
        {
            InitializeComponent();
        }

        private void btnTCPServer_Click(object sender, EventArgs e)
        {
            TCP_Server tcpServer = new TCP_Server();
            tcpServer.Show(this);
        }

        private void btnTCPClient_Click(object sender, EventArgs e)
        {
            TCP_Client client = new TCP_Client();
            client.Show(this);
        }
    }
}
