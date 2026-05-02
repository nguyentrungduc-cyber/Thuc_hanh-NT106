using System;
using System.Text;
using System.Windows.Forms;
using System.Net;  
using System.Net.Sockets; 
using System.Threading;

namespace Lab03
{
    public partial class TCP_Server : Form
    {
        // Khai báo Socket và Thread ở ngoài để có thể đóng/ngắt từ xa
        private Socket listenerSocket = null;
        private Thread listenThread = null;

        public TCP_Server()
        {
            InitializeComponent();
        }

        // Sự kiện khi nhấn nút Listen
        private void btnListen_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtPort.Text, out int port))
            {
                MessageBox.Show("Vui lòng nhập Port hợp lệ!");
                return;
            }

            // Đổi trạng thái nút
            btnListen.Enabled = false;
            btnListen.Text = "Listening...";

            // Chạy luồng lắng nghe
            listenThread = new Thread(() => StartServer(port));
            listenThread.IsBackground = true;
            listenThread.Start();
        }


        private void StartServer(int port)
        {
            listenerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                IPEndPoint ipep = new IPEndPoint(IPAddress.Any, port);
                listenerSocket.Bind(ipep);
                listenerSocket.Listen(10);

                this.Invoke(new MethodInvoker(delegate
                {
                    lvLog.Items.Add(new ListViewItem($"Server started on port {port}..."));
                }));

                while (true)
                {
                    Socket clientSocket = listenerSocket.Accept();

                    this.Invoke(new MethodInvoker(delegate
                    {
                        lvLog.Items.Add(new ListViewItem("New client connected: " + clientSocket.RemoteEndPoint.ToString()));
                    }));

                    Thread clientThread = new Thread(() => HandleClient(clientSocket));
                    clientThread.IsBackground = true;
                    clientThread.Start();
                }
            }
            catch (SocketException)
            {
                // Khi Socket bị đóng do đổi Port, luồng này sẽ kết thúc êm đẹp
            }
            catch (Exception ex)
            {
                this.Invoke(new MethodInvoker(delegate
                {
                    lvLog.Items.Add(new ListViewItem("Error: " + ex.Message));
                }));
            }
        }

        private void HandleClient(Socket clientSocket)
        {
            string clientInfo = clientSocket.RemoteEndPoint.ToString();
            try
            {
                while (clientSocket.Connected)
                {
                    string text = "";
                    do
                    {
                        byte[] buffer = new byte[1];
                        int bytesRecv = clientSocket.Receive(buffer);
                        if (bytesRecv == 0) break;
                        text += Encoding.UTF8.GetString(buffer);
                    } while (!text.EndsWith("\n"));

                    if (!string.IsNullOrEmpty(text))
                    {
                        this.Invoke(new MethodInvoker(delegate
                        {
                            lvLog.Items.Add(new ListViewItem(text.Trim()));
                        }));
                    }
                }
            }
            catch { }
            finally
            {
                clientSocket.Close();
            }
        }

        private void txtPort_TextChanged_1(object sender, EventArgs e)
        {
            // 1. Làm nút sáng lại để nhấn lần nữa
            btnListen.Enabled = true;
            btnListen.Text = "Listen";

            // 2. Đóng Socket cũ nếu đang chạy để giải phóng Port
            try
            {
                if (listenerSocket != null)
                {
                    listenerSocket.Close();
                    listenerSocket = null;
                }
            }
            catch { }
        }

        private void lvLog_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}