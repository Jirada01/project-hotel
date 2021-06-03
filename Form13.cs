using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using MySql.Data.MySqlClient;

namespace Project_1_
{
    public partial class Form13 : Form
    {
        private MySqlConnection databaseConnection()
        {
            string connectionString = "datasource = 127.0.0.1;port=3306;username=root;password=;database=project;";
            MySqlConnection conn = new MySqlConnection(connectionString);
            return conn;
        }
        public Form13()
        {
            InitializeComponent();
        }
        

        private void Form13_Load(object sender, EventArgs e)
        {           
            Time.Text = DateTime.Now.ToLongTimeString();
            Date.Text = DateTime.Now.ToLongDateString();

            int w = Screen.PrimaryScreen.Bounds.Width;
            int h = Screen.PrimaryScreen.Bounds.Height;
            this.Location = new Point(0, 0);
            this.Size = new Size(w, h);
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("คุณยืนยันที่จะออกจากโปรแกรมใช่หรือไม่?",
              "ออกจากโปรแกรม", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                Application.Exit();
            }
            else if (dialog == DialogResult.No)
            {

            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("คุณยืนยันที่จะยกเลิกการสมัครใช่หรือไม่?",
            "ยกเลิกการสมัคร", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                this.Hide();
                Form12 f = new Form12();
                f.Show();
            }
            else if (dialog == DialogResult.No)
            {

            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && !char.IsControl(ch))
            {
                e.Handled = true;
                MessageBox.Show("ใส่ตัวเลขระหว่าง 0-9 เท่านั้น", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (textBox4.TextLength >= 10 && ch != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void id_staff_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && !char.IsControl(ch))
            {
                e.Handled = true;
                MessageBox.Show("ใส่ตัวเลขระหว่าง 0-9 เท่านั้น", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (id_staff_2.TextLength >= 6 && ch != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {           
            
            if (id_staff_2.Text == "" || textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox6.Text == "" || textBox4.Text == "" || combo1.SelectedIndex == -1 )
            {
                MessageBox.Show("กรุณากรอกข้อมูลให้ครบ", "กรอกข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string connectionSting = "datasource=127.0.0.1;port=3306;username=root;password=;database=project;";
                MySqlConnection conn = new MySqlConnection(connectionSting);
                conn.Open();

                String sql = "INSERT INTO `registration_staff` (id_staff,fname_staff,lname_staff,email_staff,password_staff,phone_staff,sex_staff)VALUES('" + id_staff_2.Text + "','" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox6.Text + "','" + textBox4.Text + "','" + combo1.SelectedItem + "')";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                try
                {
                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        MessageBox.Show("สมัครบัญชีผู้ใช้งานสำเร็จ");
                        this.Hide();
                        Form12 f = new Form12();
                        f.Show();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            string pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
            if (Regex.IsMatch(textBox3.Text, pattern))
            {
                errorProvider1.Clear();
            }
            else
            {
                errorProvider1.SetError(this.textBox3, "กรุณาระบุที่อยู่อีเมลที่ถูกต้อง");
                return;
            }
        }

        private void combo1_Leave(object sender, EventArgs e)
        {
            
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
