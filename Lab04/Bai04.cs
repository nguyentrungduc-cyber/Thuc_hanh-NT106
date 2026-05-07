using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Web.WebView2.Core;

namespace Lab04
{
    public partial class Bai04 : Form
    {
        public Bai04()
        {
            InitializeComponent();
            this.Resize += new System.EventHandler(this.Form_Resize);
        }

        private void Form_Resize(object sender, EventArgs e)
        {
            webView21.Size = this.ClientSize - new System.Drawing.Size(webView21.Location);
            button3.Left = this.ClientSize.Width - button3.Width - 12;
            button2.Left = this.ClientSize.Width - button3.Width - 6 - button2.Width - 12;
            button1.Left = this.ClientSize.Width - button3.Width - 6 - button2.Width - 6 - button1.Width - 12;

            textBox1.Width = button1.Left - textBox1.Left - 12;
        }

        private void textBox1_KeyHandler(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                OpenWebsite();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenWebsite();
        }

        private void OpenWebsite()
        {
            if (webView21 != null && webView21.CoreWebView2 != null && textBox1.Text != String.Empty)
            {
                webView21.CoreWebView2.Navigate(textBox1.Text);
            }
        }

        private void OnWebViewSourceChanged(object? sender, Microsoft.Web.WebView2.Core.CoreWebView2SourceChangedEventArgs e)
        {
            textBox1.Text = webView21.Source.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string currentUrl = webView21.Source.ToString();
            webView21.CoreWebView2.Navigate($"view-source:{currentUrl}");
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string url = webView21.Source.ToString();

                if (string.IsNullOrEmpty(url))
                {
                    MessageBox.Show("Không có website.");
                    return;
                }

                // Chọn nơi lưu
                FolderBrowserDialog folderDialog = new FolderBrowserDialog();

                if (folderDialog.ShowDialog() != DialogResult.OK)
                    return;

                string saveFolder = folderDialog.SelectedPath;

                using (HttpClient client = new HttpClient())
                {
                    // Tải HTML
                    string html = await client.GetStringAsync(url);

                    HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                    doc.LoadHtml(html);

                    Uri baseUri = new Uri(url);

                    // Tạo thư mục resource
                    string resourceFolder = Path.Combine(saveFolder, "resources");

                    if (!Directory.Exists(resourceFolder))
                        Directory.CreateDirectory(resourceFolder);

                    // =========================
                    // DOWNLOAD IMG
                    // =========================
                    var imgNodes = doc.DocumentNode.SelectNodes("//img[@src]");

                    if (imgNodes != null)
                    {
                        foreach (var img in imgNodes)
                        {
                            string src = img.GetAttributeValue("src", "");

                            if (string.IsNullOrEmpty(src))
                                continue;

                            try
                            {
                                Uri imgUri = new Uri(baseUri, src);

                                string fileName = Path.GetFileName(imgUri.LocalPath);

                                if (string.IsNullOrEmpty(fileName))
                                    fileName = Guid.NewGuid().ToString() + ".img";

                                string localPath = Path.Combine(resourceFolder, fileName);

                                byte[] data = await client.GetByteArrayAsync(imgUri);

                                File.WriteAllBytes(localPath, data);

                                // đổi src local
                                img.SetAttributeValue("src", $"resources/{fileName}");
                            }
                            catch
                            {

                            }
                        }
                    }

                    // =========================
                    // DOWNLOAD CSS
                    // =========================
                    var cssNodes = doc.DocumentNode.SelectNodes("//link[@href]");

                    if (cssNodes != null)
                    {
                        foreach (var css in cssNodes)
                        {
                            string href = css.GetAttributeValue("href", "");

                            if (string.IsNullOrEmpty(href))
                                continue;

                            try
                            {
                                Uri cssUri = new Uri(baseUri, href);

                                string fileName = Path.GetFileName(cssUri.LocalPath);

                                if (string.IsNullOrEmpty(fileName))
                                    fileName = Guid.NewGuid().ToString() + ".css";

                                string localPath = Path.Combine(resourceFolder, fileName);

                                byte[] data = await client.GetByteArrayAsync(cssUri);

                                File.WriteAllBytes(localPath, data);

                                css.SetAttributeValue("href", $"resources/{fileName}");
                            }
                            catch
                            {

                            }
                        }
                    }

                    // =========================
                    // DOWNLOAD JS
                    // =========================
                    var jsNodes = doc.DocumentNode.SelectNodes("//script[@src]");

                    if (jsNodes != null)
                    {
                        foreach (var js in jsNodes)
                        {
                            string src = js.GetAttributeValue("src", "");

                            if (string.IsNullOrEmpty(src))
                                continue;

                            try
                            {
                                Uri jsUri = new Uri(baseUri, src);

                                string fileName = Path.GetFileName(jsUri.LocalPath);

                                if (string.IsNullOrEmpty(fileName))
                                    fileName = Guid.NewGuid().ToString() + ".js";

                                string localPath = Path.Combine(resourceFolder, fileName);

                                byte[] data = await client.GetByteArrayAsync(jsUri);

                                File.WriteAllBytes(localPath, data);

                                js.SetAttributeValue("src", $"resources/{fileName}");
                            }
                            catch
                            {

                            }
                        }
                    }

                    // Lưu index.html
                    string htmlPath = Path.Combine(saveFolder, "index.html");

                    File.WriteAllText(htmlPath, doc.DocumentNode.OuterHtml, Encoding.UTF8);

                    MessageBox.Show("Tải website thành công!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
