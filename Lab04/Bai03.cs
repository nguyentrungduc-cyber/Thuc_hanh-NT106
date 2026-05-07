using HtmlAgilityPack; // thư viện web
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab4
{
    public partial class Bai03 : Form
    {
        public Bai03()
        {
            InitializeComponent();
        }

        // Kiểm tra và chuẩn hóa URL
        private string NormalSource(string URL)
        {
            // Thêm giao thức mặc định nếu không có
            if (!URL.StartsWith("http://") && !URL.StartsWith("https://"))
            {
                URL = "https://" + URL;
                return URL;
            }
            return URL;

        }
        private string getSource(string URL)
        {

            try  
            {
                URL = NormalSource(URL);

                HtmlWeb web = new HtmlWeb(); // xử lý việc gửi yêu cầu HTTP và nhận kết quả trả về một cách tự động
                HtmlAgilityPack.HtmlDocument content = new HtmlAgilityPack.HtmlDocument(); // Khởi tạo và tải nội dung trực tiếp
                content = web.Load(URL); // Gửi yêu cầu đến URL và trả về toàn bộ cấu trúc của trang web đó dưới dạng một đối tượng HtmlDocument: (như cây DOM, các node, thẻ div, class...)
                string s = content.Text;
                return s;  // Trả về nội dung HTML của trang
            }
            catch (UriFormatException)
            {
                return "URL không hợp lệ!";
            }
            catch (System.Net.WebException)
            {
                return "Không thể kết nối đến URL!";
            }
            catch (Exception)
            {
                return "Đã xảy ra lỗi khi tải nội dung!";
            }
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            string url = NormalSource(txtURL.Text);
            string htmlContent = getSource(url); // Gán vào biến để không phải gọi hàm 2 lần

            // Kiểm tra xem kết quả trả về có phải là 1 trong 3 lỗi hay không
            if (htmlContent == "URL không hợp lệ!" ||
                htmlContent == "Không thể kết nối đến URL!" ||
                htmlContent == "Đã xảy ra lỗi khi tải nội dung!")
            {
                MessageBox.Show(htmlContent, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                using (WebClient myClient = new WebClient())
                {
                    // 1. Tải file về máy trước
                    myClient.DownloadFile(url, txtPath.Text);

                    // 2. Sau khi tải xong, đọc nội dung từ file vừa lưu để hiển thị lên RichTextBox
                    string content = File.ReadAllText(txtPath.Text);

                    MessageBox.Show("Tải về thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    rtbHTML.Text = content;
                }
            }
        }
    }
}
