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
    public partial class Form3 : Form
    {
        private MySqlConnection databaseConnection()
        {
            string connectionString = "datasource = 127.0.0.1;port=3306;username=root;password=;database=project;";
            MySqlConnection conn = new MySqlConnection(connectionString);
            return conn;
        }
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            int w = Screen.PrimaryScreen.Bounds.Width;
            int h = Screen.PrimaryScreen.Bounds.Height;
            this.Location = new Point(0, 0);
            this.Size = new Size(w, h);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {           
            DialogResult dialog = MessageBox.Show("คุณยืนยันที่จะยกเลิกการสมัครใช่หรือไม่?",
            "ยกเลิกการสมัคร", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                this.Hide();
                Form1 f = new Form1();
                f.Show();
            }
            else if (dialog == DialogResult.No)
            {

            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
           
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && !char.IsControl(ch))
            {
                e.Handled = true;
                MessageBox.Show("ใส่ตัวเลขระหว่าง 0-9 เท่านั้น", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (textBox3.TextLength >= 10 && ch !=(char)Keys.Back)           
            {
                e.Handled = true;
            }

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if(textBox2.Text == "" || textBox1.Text =="" || textBox3.Text =="" || textBox4.Text == "" || textBox5.Text == "")
            {
                MessageBox.Show("กรุณากรอกข้อมูลให้ครบ", "กรอกข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string connectionSting = "datasource=127.0.0.1;port=3306;username=root;password=;database=project;";
                MySqlConnection conn = new MySqlConnection(connectionSting);
                conn.Open();

                String sql = "INSERT INTO `registration_user` (fname,lname,phone,email,password)VALUES('" + textBox2.Text + "','" + textBox1.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "')";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                try
                {
                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        MessageBox.Show("สมัครบัญชีผู้สำเร็จแล้ว");
                        this.Hide();
                        Form1 f = new Form1();
                        f.Show();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            
            

        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Hide();


        }

        private void textBox6_KeyUp(object sender, KeyEventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_Leave(object sender, EventArgs e)
        {

            string pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
            if (Regex.IsMatch(textBox4.Text, pattern))
            {
                errorProvider1.Clear();
            }
            else
            {
                errorProvider1.SetError(this.textBox4, "กรุณาระบุที่อยู่อีเมลที่ถูกต้อง");
                return ;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
