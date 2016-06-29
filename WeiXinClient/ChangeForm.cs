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

        private void button2_Click(object sender, EventArgs e)
        {
            string oid = textBox3.Text;
            if (!_login_form.get_pwd().Equals(oid))
            {
                MessageBox.Show("您输入的原始密码不匹配，请重新输入！！", "!!错误!!");
            }
            if (!_login_form.get_pwd().Equals(oid))
            {
                MessageBox.Show("您输入的原始密码不匹配，请重新输入！！", "!!错误!!");
            }





        }

       
        private void button1_Click(object sender, EventArgs e)
        {
            _login_form.Visible = true;
            this.Close();
        }

        private void change_FormClosing(object sender, FormClosingEventArgs e)
        {
            _login_form.Visible = true;
            //this.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text.Trim().Length > 0 && textBox1.Text.Trim().Length > 0 && textBox3.Text.Trim().Length > 0)
            {
                this.button1.Enabled = true;
            }
        }
    }
}
