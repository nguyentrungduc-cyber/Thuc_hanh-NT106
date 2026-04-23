using System.Net.Sockets;
using System.Net;


namespace Lab03
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }
        private void btnBai1_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Tạo thực thể cho Form Server và hiển thị
                UDP_Server server = new UDP_Server();
                server.Show();

                // 2. Tạo thực thể cho Form Client và hiển thị
                UDP_Client client = new UDP_Client();
                client.Show();

                // Gợi ý: Bạn có thể đặt vị trí 2 form khác nhau để không bị đè lên nhau
                // client.StartPosition = FormStartPosition.Manual;
                // client.Location = new System.Drawing.Point(this.Location.X + 400, this.Location.Y);
            }
            catch (Exception ex)
            {
                // HANDLE EXCEPTION: Xử lý nếu có lỗi khi khởi tạo Form
                MessageBox.Show("Lỗi khi mở Bài 1: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
