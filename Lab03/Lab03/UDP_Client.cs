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

namespace Lab03
{
    public partial class UDP_Client : Form
    {
        public UDP_Client()
        {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra đầu vào (Handle Input)
            if (string.IsNullOrWhiteSpace(txtIP.Text) || string.IsNullOrWhiteSpace(txtPort.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ IP và Port!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra xem Port có phải là số không
            if (!int.TryParse(txtPort.Text, out int port))
            {
                MessageBox.Show("Cổng (Port) phải là một số nguyên hợp lệ!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 2. Gửi dữ liệu và xử lý lỗi (Exception Handling)
            try
            {
                // Khởi tạo UdpClient
                UdpClient udpClient = new UdpClient();

                // Chuyển nội dung tin nhắn sang mảng byte (dùng UTF8 để hỗ trợ tiếng Việt)
                byte[] sendBytes = Encoding.UTF8.GetBytes(txtMessage.Text);

                // Gửi dữ liệu tới địa chỉ IP và Port đã nhập
                // Nếu IP nhập sai định dạng (ví dụ: "abc"), dòng này sẽ gây ra ngoại lệ
                udpClient.Send(sendBytes, sendBytes.Length, txtIP.Text, port);

                // Thông báo hoặc xóa nội dung sau khi gửi (tùy chọn)
                // MessageBox.Show("Đã gửi tin nhắn!");
                txtMessage.Clear();

                // Giải phóng tài nguyên
                udpClient.Close();
            }
            catch (SocketException ex)
            {
                // Lỗi liên quan đến mạng/socket (ví dụ: sai định dạng IP)
                MessageBox.Show($"Lỗi Socket: {ex.Message}", "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // Các lỗi không lường trước khác
                MessageBox.Show($"Lỗi không xác định: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}