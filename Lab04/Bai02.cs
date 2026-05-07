using System;
using System.Drawing;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab04
{
    public partial class Bai02 : Form
    {
        private static readonly HttpClient client = new HttpClient();
        private CancellationTokenSource cts;

        private Panel topPanel;
        private Label lblStatus;

        public Bai02()
        {
            InitializeComponent();
            InitUI();
        }

        // =========================
        // MODERN UI SETUP (FIXED LAYOUT)
        // =========================
        private void InitUI()
        {
            // FORM
            this.BackColor = Color.FromArgb(24, 26, 30);
            this.MinimumSize = new Size(800, 500);
            this.Text = "POST Tool - Modern UI";

            // ================= TOP PANEL =================
            topPanel = new Panel();
            topPanel.Dock = DockStyle.Top;
            topPanel.Height = 95;
            topPanel.BackColor = Color.FromArgb(32, 34, 37);
            this.Controls.Add(topPanel);

            // ================= URL =================
            txtURL.Parent = topPanel;
            txtURL.Location = new Point(15, 15);
            txtURL.Size = new Size(520, 28);

            txtURL.BackColor = Color.FromArgb(40, 42, 48);
            txtURL.ForeColor = Color.Gainsboro;
            txtURL.BorderStyle = BorderStyle.FixedSingle;
            txtURL.Font = new Font("Segoe UI", 10);

            txtURL.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;

            // ================= DATA =================
            txtData.Parent = topPanel;
            txtData.Location = new Point(15, 50);
            txtData.Size = new Size(520, 28);

            txtData.BackColor = Color.FromArgb(40, 42, 48);
            txtData.ForeColor = Color.Gainsboro;
            txtData.BorderStyle = BorderStyle.FixedSingle;
            txtData.Font = new Font("Segoe UI", 10);

            txtData.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;

            // ================= BUTTON =================
            btnPost.Parent = topPanel;
            btnPost.Location = new Point(550, 25);
            btnPost.Size = new Size(110, 40);
            btnPost.Text = "POST";

            btnPost.BackColor = Color.FromArgb(88, 101, 242);
            btnPost.ForeColor = Color.White;
            btnPost.FlatStyle = FlatStyle.Flat;
            btnPost.FlatAppearance.BorderSize = 0;
            btnPost.Cursor = Cursors.Hand;

            btnPost.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            btnPost.MouseEnter += (s, e) =>
                btnPost.BackColor = Color.FromArgb(108, 122, 255);

            btnPost.MouseLeave += (s, e) =>
                btnPost.BackColor = Color.FromArgb(88, 101, 242);

            // ================= STATUS =================
            lblStatus = new Label();
            lblStatus.Parent = topPanel;
            lblStatus.Location = new Point(680, 35);
            lblStatus.AutoSize = true;
            lblStatus.Text = "Ready";
            lblStatus.ForeColor = Color.Silver;
            lblStatus.Font = new Font("Segoe UI", 9);

            lblStatus.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            // ================= RESPONSE BOX =================
            rtbResponse.Dock = DockStyle.Fill;

            rtbResponse.BackColor = Color.FromArgb(30, 32, 36);
            rtbResponse.ForeColor = Color.Gainsboro;
            rtbResponse.Font = new Font("Consolas", 10);
            rtbResponse.BorderStyle = BorderStyle.None;

            // 🔥 FIX QUAN TRỌNG: ORDER CONTROLS (TRÁNH CHE UI)
            this.Controls.Add(rtbResponse);
            this.Controls.Add(topPanel);
        }

        // =========================
        // POST REQUEST (ASYNC)
        // =========================
        private async Task<string> PostAsync(string url, string data, CancellationToken token)
        {
            var content = new StringContent(
                data,
                Encoding.UTF8,
                "application/x-www-form-urlencoded"
            );

            HttpResponseMessage response = await client.PostAsync(url, content, token);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }

        // =========================
        // CLICK EVENT
        // =========================
        private async void btnPost_Click(object sender, EventArgs e)
        {
            string url = txtURL.Text.Trim();
            string postData = txtData.Text.Trim();

            if (string.IsNullOrWhiteSpace(url) || string.IsNullOrWhiteSpace(postData))
            {
                MessageBox.Show("Nhập đủ URL + DATA 😆");
                return;
            }

            if (!Uri.TryCreate(url, UriKind.Absolute, out Uri validUrl))
            {
                MessageBox.Show("URL không hợp lệ!");
                return;
            }

            try
            {
                btnPost.Enabled = false;

                lblStatus.Text = "Sending...";
                lblStatus.ForeColor = Color.Yellow;

                rtbResponse.Text = "Processing request...";

                cts?.Cancel();
                cts = new CancellationTokenSource();

                string result = await PostAsync(validUrl.ToString(), postData, cts.Token);

                rtbResponse.Text = result;

                lblStatus.Text = "Success ✔";
                lblStatus.ForeColor = Color.LightGreen;
            }
            catch (TaskCanceledException)
            {
                lblStatus.Text = "Cancelled";
                lblStatus.ForeColor = Color.Orange;
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show("HTTP Error: " + ex.Message);
                lblStatus.Text = "Error";
                lblStatus.ForeColor = Color.IndianRed;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                lblStatus.Text = "Error";
                lblStatus.ForeColor = Color.IndianRed;
            }
            finally
            {
                btnPost.Enabled = true;
            }
        }

        private void Bai02_FormClosing(object sender, FormClosingEventArgs e)
        {
            cts?.Cancel();
            client.Dispose();
        }
    }
}