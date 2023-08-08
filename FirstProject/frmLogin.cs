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
    public partial class frmLogin : Form
    {
        Database1Entities db = new Database1Entities();
        public frmLogin()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

       
        
        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void lnkLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            frm_register frm = new frm_register();
            frm.ShowDialog();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var data = db.tblUsers.Where(u => u.UserName == txtusername.Text && u.Password == txtpassword.Text).FirstOrDefault();

            if(data != null)
            {
                this.Hide();

                frmMainMenu frm = new frmMainMenu();
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Invalid User !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
