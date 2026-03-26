namespace Lab02
{
    public partial class FrmBai01 : Form
    {
        public FrmBai01()
        {
            InitializeComponent();
        }

        private void btnReadFile_Click(object sender, EventArgs e)
        {
            try
            {
                using FileStream fs = new FileStream("input.txt", FileMode.Open, FileAccess.Read);
                using StreamReader sr = new StreamReader(fs);
                {
                    txtFileContent.Text = sr.ReadToEnd();
                } // using sẽ tự động đóng StreamReader và FileStream sau khi hoàn thành khối lệnh
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("File not found");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnWriteFile_Click(object sender, EventArgs e)
        {
            FileStream sw = new FileStream("output.txt", FileMode.OpenOrCreate, FileAccess.Write);
            using StreamWriter writer = new StreamWriter(sw);
            {
                string content = txtFileContent.Text.ToUpper();
                writer.Write(content);
            } // using sẽ tự động đóng StreamWriter và FileStream sau khi hoàn thành khối lệnh

        }
    }
}
