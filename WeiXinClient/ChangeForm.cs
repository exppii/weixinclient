using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WeixinClient
{
    public partial class change : Form
    {
        public change(LoginForm login_form)
        {
            InitializeComponent();
            _login_form = login_form;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }


        private LoginForm _login_form;


        private void change_FormClosing(object sender, FormClosingEventArgs e)
        {
            _login_form.Visible = true;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (newPwdTextBox.Text.Trim().Length > 0 && oldPwdtextBox.Text.Trim().Length > 0)
            {
                this.ChangePwd.Enabled = true;
            }
        }

        private void Return_Click(object sender, EventArgs e)
        {
            _login_form.Visible = true;
            this.Close();
        }

        private void chagnePwd_Click(object sender, EventArgs e)
        {
            if(!_login_form.verifyPasswd(oldPwdtextBox.Text))
            {
                MessageBox.Show("您输入的初始密码不匹配，请重新输入！！", "!!错误!!");
            }
            else if (newPwdTextBox.Text.Length < 6 || !_login_form.saveNewAdmin(newPwdTextBox.Text))
            {
                MessageBox.Show("更新密码失败，请重新输入！！", "!!错误!!");
            } else
            {
                _login_form.Visible = true;
                this.Close();
            }
            
        }
    }
}
