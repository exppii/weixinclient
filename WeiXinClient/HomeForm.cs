using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

using System.Data.SQLite;

using CefSharp;
using CefSharp.WinForms;

namespace WeixinClient
{
    public partial class HomeForm : Form
    {
        public HomeForm(string dbPath)
        {
            InitializeComponent();
            InitDB(dbPath);
            InitTable();
            InitBrowser();
        }


        private void InitDB(string dbPath)
        {

            dbConn = new SQLiteConnection(string.Format("Data Source={0};Version=3;", dbPath));

        }

        private void InitTable()
        {
            try
            {
                dbConn.Open();
                SQLiteCommand comm = new SQLiteCommand("Select account, pwd,comment From user where isadmin = 0", dbConn);
                using (SQLiteDataReader read = comm.ExecuteReader())
                {
                    while (read.Read())
                    {
                        
                        dataGridView1.Rows.Add(new object[] {
                        read.GetValue(read.GetOrdinal("account")),  // Or column name like this
                        read.GetValue(read.GetOrdinal("pwd")),
                        read.GetValue(read.GetOrdinal("comment"))
                         });
                    }
                }

                dbConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        private ChromiumWebBrowser browser;
        private void InitBrowser()
        {
            Cef.Initialize(new CefSettings());
            browser = new ChromiumWebBrowser("https://mp.weixin.qq.com/");
            //this.webBrowser1.Controls.Add(browser);
            this.webpanel.Controls.Add(browser);
            browser.Dock = DockStyle.Fill;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string account = this.textBox1.Text;
            string pwd = this.textBox2.Text;
            string sql = string.Format(@"insert into user (account, pwd) values ('{0}', '{1}')", account, pwd);

            dbConn.Open();
            SQLiteCommand command = new SQLiteCommand(sql, dbConn);
            command.ExecuteNonQuery();
            dbConn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dbConn.Open();
            //DataSet data = new DataSet();
            //SQLiteDataAdapter adapter = new SQLiteDataAdapter("Select account, pwd,comment From user", dbConn);

            //adapter.Fill(data);
            //dataGridView1.DataSource = data.Tables[0].DefaultView;
            try
            {
                
                SQLiteCommand comm = new SQLiteCommand("Select account, pwd,comment From user", dbConn);
                using (SQLiteDataReader read = comm.ExecuteReader())
                {
                    while (read.Read())
                    {
                        //string comment = read.GetValue(read.GetOrdinal("comment")).ToString();
                        //if (string.Empty == comment)
                        //{

                        //}
                        dataGridView1.Rows.Add(new object[] {
                        //read.GetValue(0),  // U can use column index
                        read.GetValue(read.GetOrdinal("account")),  // Or column name like this
                        read.GetValue(read.GetOrdinal("pwd")),
                        read.GetValue(read.GetOrdinal("comment"))
                         });
                    }
                }

                dbConn.Close();
            } catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
           

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if(row.Selected)
                {
                
                    this.textBox1.Text = row.Cells[0].Value.ToString();
                    this.textBox2.Text = row.Cells[1].Value.ToString();
                }
            }

            
            
        }

        private void login_Click(object sender, EventArgs e)
        {

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Selected)
                {

                    var acc = row.Cells[0].Value.ToString();
                    var pwd = row.Cells[1].Value.ToString();

                    if (browser.Address == "https://mp.weixin.qq.com/")
                    {
                        browser.ExecuteScriptAsync(string.Format("document.getElementById('account').value = '{0}'",acc));
                        System.Threading.Thread.Sleep(100);
                        browser.ExecuteScriptAsync(string.Format("document.getElementById('pwd').value = '{0}'", pwd));
                        System.Threading.Thread.Sleep(50);
                        browser.ExecuteScriptAsync("document.getElementById('loginBt').click()");
                    }
                    else
                    {
                        browser.ExecuteScriptAsync("alert('请退出当前登录帐号！！！'，'错误')");
                    }
                }

               
            }




            

        }

        private void logout_Click(object sender, EventArgs e)
        {
            browser.ExecuteScriptAsync("document.getElementById('logout').click()");
            System.Threading.Thread.Sleep(200);
            browser.Load("https://mp.weixin.qq.com/");
            System.Threading.Thread.Sleep(100);
        }
    }
}
