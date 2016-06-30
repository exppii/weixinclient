using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WeiXinClient
{
    public partial class MyNotifyForm : Form
    {
        public MyNotifyForm(string message, string title, Point point)
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.StartPosition = FormStartPosition.Manual;
            label1.Text = message;
            this.Text = title;
            this.Location = point;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
