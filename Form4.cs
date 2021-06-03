using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Project_1_
{
    public partial class Form4 : Form
    {
        private MySqlConnection databaseConnection()
        {
            string connectionString = " datasource=127.0.0.1;port=3306;username=root;password=;database=project;";
            MySqlConnection conn = new MySqlConnection(connectionString);
            return conn;
        }
        public Form4()
        {
            InitializeComponent();
        }
        DateTime today;
        private void showroom()
        {
            MySqlConnection conn = databaseConnection();
            DataSet ds = new DataSet();
            conn.Open();

            MySqlCommand cmd;

            cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT id,type_room,room,price FROM `room` WHERE status = \"empty\" ";

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(ds);
            conn.Close();
            dataGridView1_user.DataSource = ds.Tables[0].DefaultView;
        }
        private void typeroom()
        {
            MySqlConnection conn = databaseConnection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT DISTINCT type_room FROM `room` WHERE status = \"empty\"";
            using (var dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    comboBox2.Items.Add(dr.GetValue(0).ToString());
                }
            }



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

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "" || textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || comboBox1.SelectedIndex == -1 || textBox5.Text == "" || comboBox2.SelectedIndex == -1 || comboBox3.SelectedIndex == -1 || textBox6.Text == "" || check_in.Text == "" || check_out.Text == "" || textBox8.Text == "" || textBox7.Text == "")
            {
                MessageBox.Show("กรุณากรอกข้อมูลให้ครบ", "กรอกข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string connectionSting = "datasource=127.0.0.1;port=3306;username=root;password=;database=project;";
                MySqlConnection conn = new MySqlConnection(connectionSting);
                conn.Open();

                String sql = "INSERT INTO `booking` (fname_user,lname_user,email_user,phone_user,sex_user,Address_user,type_room,number_room,price_room,check_in_user,check_out_user,count_day,total_price_user)VALUES('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + comboBox1.SelectedItem + "','" + textBox5.Text + "','" + comboBox2.SelectedItem + "','" + comboBox3.SelectedItem + "','" + textBox6.Text + "','" + check_in.Text + "','" + check_out.Text + "','" + textBox8.Text + "','" + textBox7.Text + "')";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                try
                {
                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        MessageBox.Show("จองที่พักสำเร็จ!");
                        MySqlConnection conn2 = new MySqlConnection(connectionSting);
                        conn2.Open();
                        MySqlCommand cmd2 = conn2.CreateCommand();
                        cmd2.CommandText = $"UPDATE room SET status =\" no empty\" WHERE room = \"{comboBox3.SelectedItem.ToString()}\"";
                        cmd2.ExecuteNonQuery();
                        showroom();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            check_in.Value = DateTime.Now;
            check_out.Value = DateTime.Now;
            comboBox1.Text = string.Empty;
            comboBox2.Text = string.Empty;
            comboBox3.Text = string.Empty;


        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 f = new Form2();
            f.Show();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            showroom();
            typeroom();
            today = check_in.Value;
            


            Time.Text = DateTime.Now.ToLongTimeString();
            Date.Text = DateTime.Now.ToLongDateString();

            int w = Screen.PrimaryScreen.Bounds.Width;
            int h = Screen.PrimaryScreen.Bounds.Height;
            this.Location = new Point(0, 0);
            this.Size = new Size(w, h);
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

        private void textBox3_Leave(object sender, EventArgs e)
        {
            string pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
            if (Regex.IsMatch(textBox3.Text, pattern))
            {
                errorProvider1.Clear();
            }
            else
            {
                
                return;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_TextChanged(object sender, EventArgs e)
        {
            comboBox3.Items.Clear();
            MySqlConnection conn = databaseConnection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT room FROM `room` WHERE status = \"empty\" AND type_room = '" + comboBox2.Text + "' ";
            using (var dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    comboBox3.Items.Add(dr.GetValue(0).ToString());
                }
            }
            MySqlConnection conn2 = databaseConnection();
            conn2.Open();
            MySqlCommand cmd2 = conn2.CreateCommand();
            cmd2.CommandText = "SELECT price FROM `room` WHERE status = \"empty\" AND type_room = '" + comboBox2.Text + "' ";
            MySqlDataReader dr2 = cmd2.ExecuteReader();
            if (dr2.Read())
            {
                string price = dr2.GetValue(0).ToString();
                textBox6.Text = price;
            }


        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            DateTime date1 = check_in.Value.Date;
            DateTime date2 = check_out.Value.Date;

            TimeSpan tp = date2 - date1;
            double dateiff = tp.TotalDays;
            //int dateiff = ((TimeSpan)(date2 - date1)).Days;
            textBox8.Text = dateiff.ToString();
            int price = int.Parse(textBox6.Text);
            int day = int.Parse(textBox8.Text);
            int total = price * day;
            textBox7.Text = total.ToString();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void check_in_ValueChanged(object sender, EventArgs e)
        {            
            int res = DateTime.Compare(check_in.Value, today);
            if (res <0)
            {
                MessageBox.Show("กรูณาตรวจสอบวันจองที่พัก");
            }
        }

        private void check_out_ValueChanged(object sender, EventArgs e)
        {
           
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click_1(object sender, EventArgs e)
        {

        }

        private void dataGridView1_user_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
