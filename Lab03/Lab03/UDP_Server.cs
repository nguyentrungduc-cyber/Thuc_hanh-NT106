using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Lab03
{
    public partial class UDP_Server : Form
    {
        // Khai báo biến UdpClient ở ngoài để có thể đóng khi cần thiết
        private UdpClient udpServer;

        public UDP_Server()
        {
            InitializeComponent();
        }

        public void StartListening()
        {
            try
            {
                // 1. Xử lý Input Port an toàn bằng TryParse
                if (!int.TryParse(txtPort.Text, out int port))
                {
                    MessageBox.Show("Cổng (Port) không hợp lệ!");
                    return;
                }

                // 2. Khởi tạo UdpClient
                udpServer = new UdpClient(port);
                IPEndPoint remoteEP = new IPEndPoint(IPAddress.Any, 0);

                while (true)
                {
                    try
                    {
                        // 3. Đợi nhận dữ liệu
                        byte[] data = udpServer.Receive(ref remoteEP);
                        string message = Encoding.UTF8.GetString(data);

                        // 4. Update giao diện an toàn (Invoke)
                        this.Invoke(new MethodInvoker(delegate {
                            string time = DateTime.Now.ToString("HH:mm:ss");
                            string fullMess = $"[{time}] {remoteEP.Address}: {message}";
                            lvMessages.Items.Add(new ListViewItem(fullMess));

                            // Tự động cuộn xuống dòng mới nhất
                            lvMessages.Items[lvMessages.Items.Count - 1].EnsureVisible();
                        }));
                    }
                    catch (SocketException ex)
                    {
                        // Xử lý lỗi khi Socket bị đóng đột ngột
                        if (ex.SocketErrorCode == SocketError.Interrupted) break;
                        throw;
                    }
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi hệ thống hoặc lỗi Port đã bị chiếm dụng (AddressAlreadyInUse)
                MessageBox.Show("Lỗi Server: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Reset lại trạng thái nút bấm nếu có lỗi xảy ra
                this.Invoke(new MethodInvoker(delegate {
                    btnListen.Enabled = true;
                    btnListen.Text = "Listen";
                }));
            }
        }

        private void btnListen_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra input trống
            if (string.IsNullOrWhiteSpace(txtPort.Text))
            {
                MessageBox.Show("Vui lòng nhập Port!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Kiểm tra Port hợp lệ (0 - 65535)
            if (int.TryParse(txtPort.Text, out int port))
            {
                if (port < 0 || port > 65535)
                {
                    MessageBox.Show("Port phải nằm trong khoảng 0 - 65535");
                    return;
                }
            }

            // 3. Khởi chạy luồng
            Thread serverThread = new Thread(new ThreadStart(StartListening));
            serverThread.IsBackground = true;
            serverThread.Start();

            btnListen.Enabled = false;
            btnListen.Text = "Listening...";
        }
    }
}