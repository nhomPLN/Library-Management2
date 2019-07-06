using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using BUS;

namespace Library_ManagementGUI
{
    public partial class Login : DevComponents.DotNetBar.OfficeForm
    {
        List<string> accountIDs;
        LoginBUS loginBUS;
      

        public Login()
        {
            InitializeComponent();
            
            accountIDs = new List<string>();
            loginBUS = new LoginBUS();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            if(loginBUS.IsValid(txtID.Text, txtPassWord.Text))
            {
                Form1 form = new Form1();
                form.Account_type = loginBUS.GetAccountType(txtID.Text);
                form.Show();
                this.Hide();
                
                
            }
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}