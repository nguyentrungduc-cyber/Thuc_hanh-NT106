using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Net.Sockets;
using System.Threading;
using System.Net;

namespace Lab03
{
    public partial class TCP_Client : Form
    {
        TcpClient client;
        NetworkStream stream;

        public TCP_Client()
        {
            InitializeComponent();
        }

        // Sự kiện khi nhấn nút Connect: lấy IP và Port, kiểm tra định dạng, tạo luồng ,sau đó kết nối
        private void btnConnect_Click(object sender, EventArgs e)
        {
            // Lấy IP và Port từ TextBox và loại bỏ khoảng trắng
            string ipString = txtIP.Text.Trim();
            string portString = txtPort.Text.Trim();

            // 1. Kiểm tra định dạng IP
            bool isValidIP = System.Net.IPAddress.TryParse(ipString, out var ipAddress);

            // 2. Kiểm tra định dạng Port
            bool isValidPort = int.TryParse(portString, out int port);

            if (isValidIP && isValidPort)
            {
                // Nếu cả 2 đều đúng thì mới tiến hành kết nối
                Thread connectThread = new Thread(() => ConnectToServer(ipString, port)); // Tạo luồng mới để kết nối tránh treo UI
                connectThread.IsBackground = true; // Đặt luồng kết nối thành background để tự động đóng khi form đóng
                connectThread.Start();
            }
            else
            {
                // Thông báo lỗi cụ thể cho người dùng
                string errorMsg = "";
                if (!isValidIP) errorMsg += "Định dạng IP không đúng (VD: 127.0.0.1).\n";
                if (!isValidPort) errorMsg += "Cổng Port phải là số nguyên.";

                MessageBox.Show(errorMsg, "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Hàm này dùng để thêm log vào RichTextBox với màu sắc tùy chọn
        private void AppendLog(string message, Color color)
        {
            // Kiểm tra nếu đang ở Thread khác thì phải dùng Invoke
            if (rtbLog.InvokeRequired)
            {
                rtbLog.Invoke(new MethodInvoker(() => AppendLog(message, color)));
            }
            else
            {
                // Thêm thời gian vào đầu dòng cho chuyên nghiệp
                string time = DateTime.Now.ToString("HH:mm:ss");

                rtbLog.SelectionStart = rtbLog.TextLength; // Đặt con trỏ vào cuối text để giải quyết khi người dùng để con trỏ ở log khác cuối
                rtbLog.SelectionLength = 0; // Không chọn gì cả giúp giải quyết nếu đang copy thì có tin nhắn đến
                rtbLog.SelectionColor = color; // Đổi màu chữ

                rtbLog.AppendText($"[{time}] {message}\n");

                rtbLog.SelectionColor = rtbLog.ForeColor; // Trả lại màu mặc định
                rtbLog.ScrollToCaret(); // Tự động cuộn xuống dòng mới nhất nếu có nhiều log
            }
        }

        // Hàm kết nối tới server: tạo đối tượng TcpClient, kết nối, ghi log thành công hoặc lỗi
        private void ConnectToServer(string ip, int port)
        {
            try
            {
                AppendLog($"Đang kết nối tới {ip}:{port}...", Color.Black);

                client = new TcpClient(); // Tạo đối tượng TcpClient mới
                client.Connect(ip, port); // Kết nối tới server

                // Ghi log thành công thay vì hiện MessageBox
                AppendLog("Kết nối thành công!", Color.Green);

                // Mở nút gửi tin nhắn (phải dùng Invoke vì động vào Button ở luồng chính)
                this.Invoke(new MethodInvoker(() => btnSend.Enabled = true));
            }
            catch (Exception ex)
            {
                // Ghi log lỗi màu đỏ
                AppendLog("Lỗi: " + ex.Message, Color.Red);
            }
        }

        // Black Sheep
        private void rtbLog_TextChanged(object sender, EventArgs e)
        {
            // Hàm AppendLog quá xịn xò nên không cần làm gì thêm ở đây
        }

        // Sự kiện khi Text trong TextBox gửi tin nhắn thay đổi, bật/tắt nút gửi
        private void txtSend_TextChanged(object sender, EventArgs e)
        {
            // Bật/tắt nút gửi dựa trên nội dung TextBox
            btnSend.Enabled = !string.IsNullOrWhiteSpace(txtSend.Text);
        }

        // Sự kiện khi nhấn nút Send
        private void btnSend_Click(object sender, EventArgs e)
        {
            if (client != null && client.Connected)
            {
                NetworkStream stream = client.GetStream(); // Lấy luồng dữ liệu từ client
                string message = txtSend.Text + "\n"; // Luật ngầm là mỗi tin nhắn sẽ kết thúc bằng ký tự xuống dòng để server dễ dàng phân biệt
                byte[] data = Encoding.UTF8.GetBytes(message); // Chuyển chữ thành mảng byte
                stream.Write(data, 0, data.Length); // Đẩy dữ liệu vào đường ống
                txtSend.Clear();
            }
        }
    }
}
