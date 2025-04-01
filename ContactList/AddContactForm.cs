using System;
using System.Windows.Forms;

namespace ContactList
{
    public partial class AddContactForm : Form
    {
        public AddContactForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Lấy dữ liệu từ TextBox
            string fullName = txtFullName.Text.Trim();
            string phoneNumber = txtPhoneNumber.Text.Trim();

            // Kiểm tra xem người dùng đã nhập đầy đủ thông tin chưa
            if (string.IsNullOrWhiteSpace(fullName) || string.IsNullOrWhiteSpace(phoneNumber))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ họ tên và số điện thoại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra định dạng số điện thoại (chỉ chứa số)
            if (!long.TryParse(phoneNumber, out _))
            {
                MessageBox.Show("Số điện thoại không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Lưu thông tin vào danh sách liên hệ trong MainForm
            if (Owner is MainForm mainForm)
            {
                mainForm.AddContact(fullName, phoneNumber);
            }

            MessageBox.Show("Liên hệ đã được lưu!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Đóng Form sau khi lưu thành công
            this.Close();
        }
    }
}
