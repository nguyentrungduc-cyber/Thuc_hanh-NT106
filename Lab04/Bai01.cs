using System;
using System.Drawing;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab04
{
    public partial class Bai01 : Form
    {
        private static readonly HttpClient client = new HttpClient();
        private CancellationTokenSource cts;

        private Panel topPanel;
        private Label lblStatus;

        public Bai01()
        {
            InitializeComponent();
            InitUI();
        }

        // =========================
        // MODERN UI SETUP (FIXED)
        // =========================
        private void InitUI()
        {
            // FORM
            this.BackColor = Color.FromArgb(24, 26, 30);
            this.MinimumSize = new Size(750, 450);
            this.Text = "Web Viewer - Modern UI";

            // ================= TOP PANEL =================
            topPanel = new Panel();
            topPanel.Dock = DockStyle.Top;
            topPanel.Height = 65;
            topPanel.BackColor = Color.FromArgb(32, 34, 37);

            // ⚠️ QUAN TRỌNG: add TOP trước
            this.Controls.Add(topPanel);

            // ================= URL TEXTBOX =================
            txtURL.Parent = topPanel;
            txtURL.Location = new Point(15, 18);
            txtURL.Size = new Size(520, 28);

            txtURL.BackColor = Color.FromArgb(40, 42, 48);
            txtURL.ForeColor = Color.Gainsboro;
            txtURL.BorderStyle = BorderStyle.FixedSingle;
            txtURL.Font = new Font("Segoe UI", 10);

            txtURL.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;

            // ================= BUTTON =================
            btnGet.Parent = topPanel;
            btnGet.Location = new Point(545, 16);
            btnGet.Size = new Size(100, 32);
            btnGet.Text = "GET";

            btnGet.BackColor = Color.FromArgb(88, 101, 242);
            btnGet.ForeColor = Color.White;
            btnGet.FlatStyle = FlatStyle.Flat;
            btnGet.FlatAppearance.BorderSize = 0;
            btnGet.Cursor = Cursors.Hand;

            btnGet.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            btnGet.MouseEnter += (s, e) =>
                btnGet.BackColor = Color.FromArgb(108, 122, 255);

            btnGet.MouseLeave += (s, e) =>
                btnGet.BackColor = Color.FromArgb(88, 101, 242);

            // ================= STATUS =================
            lblStatus = new Label();
            lblStatus.Parent = topPanel;
            lblStatus.Location = new Point(660, 24);
            lblStatus.AutoSize = true;
            lblStatus.Text = "Ready";
            lblStatus.ForeColor = Color.Silver;
            lblStatus.Font = new Font("Segoe UI", 9);

            lblStatus.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            topPanel.Controls.Add(lblStatus);

            // ================= RICHTEXTBOX =================
            rtbSource.Dock = DockStyle.Fill;

            rtbSource.BackColor = Color.FromArgb(30, 32, 36);
            rtbSource.ForeColor = Color.Gainsboro;
            rtbSource.Font = new Font("Consolas", 10);
            rtbSource.BorderStyle = BorderStyle.None;

            // ⚠️ FIX QUAN TRỌNG: ADD SAU TOPPANEL
            this.Controls.Add(rtbSource);
        }

        // =========================
        // GET HTML
        // =========================
        private async Task<string> GetHtmlAsync(string url, CancellationToken token)
        {
            HttpResponseMessage response = await client.GetAsync(url, token);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }

        // =========================
        // CLICK EVENT
        // =========================
        private async void btnGet_Click(object sender, EventArgs e)
        {
            string url = txtURL.Text.Trim();

            if (string.IsNullOrWhiteSpace(url))
            {
                MessageBox.Show("Nhập URL đi 😆");
                return;
            }

            if (!Uri.TryCreate(url, UriKind.Absolute, out Uri validUrl))
            {
                MessageBox.Show("URL không hợp lệ!");
                return;
            }

            try
            {
                btnGet.Enabled = false;

                lblStatus.Text = "Loading...";
                lblStatus.ForeColor = Color.LightGray;

                rtbSource.Text = "Loading...";

                cts?.Cancel();
                cts = new CancellationTokenSource();

                string html = await GetHtmlAsync(validUrl.ToString(), cts.Token);

                rtbSource.Text = html;

                lblStatus.Text = "Done ✔";
                lblStatus.ForeColor = Color.LightGreen;
            }
            catch (TaskCanceledException)
            {
                lblStatus.Text = "Cancelled";
                lblStatus.ForeColor = Color.Orange;
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"HTTP Error: {ex.Message}");
                lblStatus.Text = "Error";
                lblStatus.ForeColor = Color.IndianRed;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
                lblStatus.Text = "Error";
                lblStatus.ForeColor = Color.IndianRed;
            }
            finally
            {
                btnGet.Enabled = true;
            }
        }

        private void Bai01_FormClosing(object sender, FormClosingEventArgs e)
        {
            cts?.Cancel();
            client.Dispose();
        }
    }
}