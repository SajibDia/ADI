using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FirstProject
{
    public partial class frm_register : Form
    {
        //List<UserInfo> userList = new List<UserInfo>();
        Database1Entities db = new Database1Entities();

        public frm_register()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            var data = db.tblUsers.ToList();
            dataGridView1.DataSource = data;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void frm_register_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void txtconfirmpassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void chkshowpassword_CheckedChanged(object sender, EventArgs e)
        {
            if(chkshowpassword.Checked == false)
            {
                txtpassword.UseSystemPasswordChar = true;
                txtconfirmpassword.UseSystemPasswordChar = true;
            }
            else
            {
                txtpassword.UseSystemPasswordChar = false;
                txtconfirmpassword.UseSystemPasswordChar = false;
            }
        }

        private void btnsignup_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();

            string password = txtpassword.Text;
            bool validPassword = password.Length >= 8
                && password.Any(char.IsLower)
                && password.Any(char.IsUpper);

            if(!validPassword && password!="")
            {
                sb.AppendLine("Password is not valid");
            }

            if (txtfullname.Text.Trim().Length == 0)
            {
                sb.AppendLine("Please enter user's full name.");
            }

            if (txtusername.Text.Trim().Length == 0)
            {
                sb.AppendLine("Please enter username.");
            }

            if (txtpassword.Text.Trim().Length == 0)
            {
                sb.AppendLine("Please enter password.");
            }

            if (txtconfirmpassword.Text.Trim().Length == 0)
            {
                sb.AppendLine("Please enter confirm password.");
            }

            if (txtpassword.Text.Trim() != txtconfirmpassword.Text.Trim())
            {
                sb.AppendLine("Sorry, Password and Confirm Password does not match");
            }

            if (sb.ToString() != String.Empty)
            {
                MessageBox.Show(sb.ToString());
                return;
            }

            //UserInfo user = new UserInfo();

            //user.FullName = txtfullname.Text;
            //user.Username = txtusername.Text;
            //user.Password = txtpassword.Text;

            //userList.Add(user);
            //dataGridView1.DataSource = userList;

            //ClassName object = new Constructor();

            tblUser user = new tblUser();

            user.FullName = txtfullname.Text;
            user.UserName = txtusername.Text;
            user.Password = txtpassword.Text;
            user.UserType = "Customer";

            db.tblUsers.Add(user);
            db.SaveChanges();
            LoadData();

            MessageBox.Show("Data Saved Succesfully!!");
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void lnkLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            frmLogin frm = new frmLogin();
            frm.ShowDialog();
        }

        private void txtusername_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
